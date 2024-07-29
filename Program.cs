<<<<<<< HEAD
using Library.App.Interfaces.Books;
using Library.App.Interfaces.Users;
using Library.App.Services;
using Library.App.Services.Books;
=======
using Library.App.Interfaces.Jwt;
using Library.App.Interfaces.Users;
using Library.App.Services;
using Library.App.Services.Jwt;
>>>>>>> 3bb3a63c33c3bb4040a9c9d56f1e5bb0a4eff87a
using Library.Data;
using Library.Utils;
using Microsoft.EntityFrameworkCore;

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

builder.Services.AddScoped<IBookService, BooksServices>();

builder.Services.AddScoped<IUsersServices, UsersService>();
builder.Services.AddScoped<Bcrypt>();
builder.Services.AddScoped<IJwtService, JwtService>();

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