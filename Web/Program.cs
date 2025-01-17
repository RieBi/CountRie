using Application;
using Application.Services.BattleManagement;
using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Application.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using Application.Services.UserManagement;

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
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<DataContext>();

builder.Services.AddExternalAuthorizationProviders(builder.Configuration);

builder.Services.AddControllersWithViews()
    .AddRazorOptions(o =>
    {
        o.ViewLocationFormats.Add("/Views/Partial/{0}" + RazorViewEngine.ViewExtension);
    });

builder.Services.AddDbContext<DataContext>(options =>
{
    string? connectionString;
    if (builder.Environment.IsDevelopment())
        connectionString = builder.Configuration.GetConnectionString("PostgreConnection");
    else
        connectionString = builder.Configuration.GetConnectionString("PostgreConnectionRelease");

    options.UseNpgsql(connectionString);
});

builder.Services.AddAutoMapper(
    typeof(Application.MappingProfiles),
    typeof(Web.MappingProfiles)
    );

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(MappingProfiles)));

builder.Services.AddScoped<IDataSeeder, DataSeeder>();
builder.Services.AddScoped<IBattleService, BattleService>();
builder.Services.AddScoped<IUserInfoService, UserInfoService>();

builder.Services.AddRazorPages();

builder.Services.AddAuthorizationHandlers();

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
