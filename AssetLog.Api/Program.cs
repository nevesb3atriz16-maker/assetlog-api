using Microsoft.EntityFrameworkCore;
using AssetLog.Api.Data;
using AssetLog.Api.Repositories;
using AssetLog.Api.Services;
using AssetLog.Api.Services.TrackingService;
using AssetLog.Api.Repositories.TrackingRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<ITrackingRepository, TrackingRepository>();
builder.Services.AddScoped<ITrackingService, TrackingService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();