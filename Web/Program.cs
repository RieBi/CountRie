using Application;
using Application.Services.BattleManagement;
using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthorization();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.Password = new()
    {
        RequireDigit = false,
        RequiredLength = 10,
        RequireLowercase = false,
        RequireNonAlphanumeric = false,
        RequireUppercase = false,
    };
})
    .AddEntityFrameworkStores<DataContext>();

var authBuilder = builder.Services.AddAuthentication();
var googleConfigSection = builder.Configuration.GetSection("Authentication:Google");
var (googleClientId, googleClientSecret) = (googleConfigSection["ClientId"], googleConfigSection["ClientSecret"]);

if (googleClientId is not null && googleClientSecret is not null)
{
    authBuilder.AddGoogle(options =>
    {
        options.ClientId = googleClientId;
        options.ClientSecret = googleClientSecret;
    });
}

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreConnection")));

builder.Services.AddAutoMapper(
    typeof(Application.MappingProfiles),
    typeof(Web.MappingProfiles)
    );

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(MappingProfiles)));

builder.Services.AddScoped<IDataSeeder, DataSeeder>();
builder.Services.AddScoped<IBattleService, BattleService>();

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetService<IDataSeeder>();
    seeder?.ApplySeeding();
}

await app.RunAsync();
