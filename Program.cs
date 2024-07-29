using EntityFrameworkCoreJwtTokenAuth.Interfaces;
using EntityFrameworkCoreJwtTokenAuth.Services;
using Library.App.Interfaces;
using Library.App.Interfaces.Users;
using Library.App.Services;
using Library.Data;
using Library.Utils;
using Library.App.Interfaces.Users;
using Library.App.Services;
using Library.App.Services;
using Microsoft.EntityFrameworkCore;
using Library.App.Services.Email;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<BaseContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("mySqlConnection"),
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")
    )
);
builder.Services.AddScoped<IMailerSendService, MailerSendService>();
builder.Services.AddScoped<IUsersServices, UsersService>();
builder.Services.AddScoped<Bcrypt>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();