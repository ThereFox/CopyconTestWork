using App;
using DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddMvc();

builder.Services
    .AddDAL(ex => ex.UseNpgsql(builder.Configuration.GetConnectionString("Database")))
    //.AddFakeDAL()
    .AddApp();

var app = builder.Build();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseRouting();

 app.MapControllerRoute(
     name: "default",
     pattern: "{controller=Book}/{action=Index}/");

app.Run();