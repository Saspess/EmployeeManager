using Application.IoC;
using Persistence.IoC;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureDbContext();
builder.Services.ConfigureUnitOfWork();

builder.Services.AddAutoMapper(Assembly.Load("Application"));
builder.Services.ConfigureFluentValidation();

builder.Services.ConfigureServiceManager();

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

app.Run();
