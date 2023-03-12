using EFCore6UpdateDelete.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);


//ccMw624v6BTh2M

// Add services to the container.
builder.Services.AddDbContext<ContactDbContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection"))
    .LogTo(Console.WriteLine,LogLevel.Information));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
