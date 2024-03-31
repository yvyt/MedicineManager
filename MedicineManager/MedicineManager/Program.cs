
using AutoMapper;
using MedicineManager.Data;
using MedicineManager.Services.Customer;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<medicineContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("MedicineDbContext")));

builder.Services.AddScoped<UserServices>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<CityRepository>();
builder.Services.AddScoped<DistrictRepository>();
builder.Services.AddScoped<WardRepository>();
builder.Services.AddScoped<AddressServices>();
builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<CityServices>();
builder.Services.AddScoped<DistrictService>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
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
