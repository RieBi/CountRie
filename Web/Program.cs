using Application;
using Application.Services.BattleManagement;
using Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreConnection")));

builder.Services.AddAutoMapper(typeof(MappingProfiles));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(MappingProfiles)));

builder.Services.AddScoped<IDataSeeder, DataSeeder>();
builder.Services.AddScoped<IBattleService, BattleService>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetService<IDataSeeder>();
    seeder?.ApplySeeding();
}

await app.RunAsync();
