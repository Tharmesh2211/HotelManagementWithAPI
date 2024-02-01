using HotelContracts.IService;
using HotelEntities.Data;
using HotelRepositories.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<HotelContext>(optionsAction: options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("connectDB")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IHotel, HotelRepository>();
builder.Services.AddScoped<IRoom, RoomRepository>();
builder.Services.AddScoped<ICustomer, CustomerRepository>();
builder.Services.AddScoped<ICheckOut, CheckOutRepository>();


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
