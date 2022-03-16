using Ecommerce.Application;
using Ecommerce.Domain.Entities.Identity;
using Ecommerce.Persistence;
using Ecommerce.Persistence.Data.Seeds;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.EcommerceApplicationInstalation();
builder.Services.EcommercePersistenceEFInstalation(config);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();

    try
    {
        var context = services.GetRequiredService<EcommerceContext>();
        var userManager = services.GetRequiredService<UserManager<User>>();
        var roleManager = services.GetRequiredService<RoleManager<Role>>();

        context.Database.MigrateAsync().Wait();
        UsersAndRolesSeed.SeedUsersAndRolesAsync(userManager, roleManager).Wait();
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
