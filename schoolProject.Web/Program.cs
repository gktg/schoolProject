using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using schoolProject.Domain.Entities;
using schoolProject.Domain.Enums;
using schoolProject.Insfastructure.Tools;
using schoolProject.Persistence;
using schoolProject.Persistence.Contexts;
using System.Reflection.Emit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddMvc();
builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//ServiceRegistration
builder.Services.AddPersistenceServices();



builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.SlidingExpiration = true;
    options.Cookie.Name = "MyAppCookie";
    options.AccessDeniedPath = "/";
});

var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    using (IServiceScope scope = app.Services.CreateScope())
//    {
//        SchoolDbContext dbContext = scope.ServiceProvider.GetRequiredService<SchoolDbContext>();
//        dbContext.Database.EnsureDeleted();
//        dbContext.Database.EnsureCreated();
//        dbContext.Database.Migrate();
//        Seed(dbContext);
//    }
//}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();


void Seed(SchoolDbContext context)
{
    Random generator = new Random();

    var student = new Student
    {
        ID = Guid.NewGuid(),
        StudentId = "20161701042",
        Name = "Göktuð",
        Surname = "Türkan",
        Email = "goktug.turkan5@gmail.com",
        PhoneNumber = "5388828249",
        Password = HashPass.hashPass("awd.12345"),
        CreatedDate = DateTime.Now,
        Status = DataStatus.Inserted,
        Role = Role.Student,

    };

    context.Students.Add(student);
    context.SaveChanges();


    var teacher = new Teacher
    {
        ID = Guid.NewGuid(),
        TeacherId = generator.Next(0, 1000000).ToString("D6"),
        Name = "Göktuð",
        Surname = "Türkan",
        Email = "goktug.turkan6@gmail.com",
        PhoneNumber = "5388828249",
        Password = HashPass.hashPass("awd.12345"),
        CreatedDate = DateTime.Now,
        Status = DataStatus.Inserted,
        Role = Role.Teacher,

    };

    context.Teachers.Add(teacher);
    context.SaveChanges();
}