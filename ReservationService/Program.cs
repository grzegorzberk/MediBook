using Microsoft.EntityFrameworkCore;
using ReservationService.Data;
using ReservationService.Data.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;

string connectionString = "server=localhost;User=sa;Password=Grzegorz12345;TrustServerCertificate=true;Database=ReservationService;";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/api/users/login";
        options.LogoutPath = "/api/users/logout";
        options.Cookie.HttpOnly = true;
        options.Cookie.SameSite = SameSiteMode.Lax;
        options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        options.SlidingExpiration = true;
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        });
});


builder.Services.AddDbContextPool<AppDbContext>(opt => opt.UseSqlServer(connectionString));

builder.Services.AddControllers();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAppointmentTypeRepository, AppointmentTypesRepository>();


var app = builder.Build();

app.MapControllers();

app.UseCors("AllowReactApp");
app.UseAuthentication();
app.UseAuthorization();

app.Run();


