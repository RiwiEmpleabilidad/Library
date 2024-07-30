using Library.App.Interfaces.Books;
using Library.App.Interfaces.Jwt;
using EntityFrameworkCoreJwtTokenAuth.Interfaces;
using EntityFrameworkCoreJwtTokenAuth.Services;
using Library.App.Interfaces;
using Library.App.Interfaces.Users;
using Library.App.Services;
using Library.App.Services.Books;
using Library.App.Services.Jwt;
using Library.Data;
using Library.Utils;
using Microsoft.EntityFrameworkCore;
using Library.App.Services.Email;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Library.App.Interfaces.Loans;
using Library.App.Services.Loans;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddDbContext<BaseContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("mySqlConnection"),
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")
    )
);

builder.Services.AddScoped<IBookService, BooksServices>();
builder.Services.AddScoped<IMailerSendService, MailerSendService>();
builder.Services.AddScoped<IUsersServices, UsersService>();
builder.Services.AddScoped<Bcrypt>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<ILoanServices, LoanServices>();

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(configure =>
{
    configure.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = @Environment.GetEnvironmentVariable("jwtVar"),
        ValidAudience = @Environment.GetEnvironmentVariable("jwtVar"),
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("3C7A6C4E2754B9A31F225E201C02D82E"))
    };
});

builder.Services.AddHttpClient();

var app = builder.Build();

app.UseCors("AllowAnyOrigin");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();