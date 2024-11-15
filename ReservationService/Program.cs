using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using ReservationService.Data;
using ReservationService.Data.Entities;
using ReservationService.Data.Repositories;

string connectionString = "server=localhost;User=sa;Password=Grzegorz12345;TrustServerCertificate=true;Database=ReservationService;";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContextPool<AppDbContext>(opt => opt.UseSqlServer(connectionString));

builder.Services.AddControllers();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAppointmentTypeRepository, AppointmentTypesRepository>();


var app = builder.Build();

app.MapControllers();

app.Run();


