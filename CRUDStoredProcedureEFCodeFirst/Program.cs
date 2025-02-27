using CRUDStoredProcedureEFCodeFirst.Models;
using CRUDStoredProcedureEFCodeFirst.Repository.Contract;
using CRUDStoredProcedureEFCodeFirst.Repository.Services;
using CRUDStoredProcedureEFCodeFirst.StudentDbOperation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IStudent, StudentService>();
builder.Services.AddScoped<StudentDbContext>();
builder.Services.AddScoped<StudentOperation>();

builder.Services.AddDbContext<StudentDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

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
    pattern: "{controller=Student}/{action=Index}/{id?}");

app.Run();
