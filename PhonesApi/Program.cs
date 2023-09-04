using Microsoft.EntityFrameworkCore;
using PhonesApi.Model;
using PhonesApi.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration 
    .GetConnectionString("PhonesApiDBConnection") ??
    throw new InvalidOperationException("Connection string'PhonesApiDBConnection' not found.");

builder.Services.AddDbContext<PhonesDbContext>(options =>
    options.UseSqlite(connectionString));

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

app.UseAuthorization();

app.MapControllers();

app.Run();
