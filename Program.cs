using Microsoft.EntityFrameworkCore;
using DoubleBack.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<DoubleBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("localdb")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("VueCorsPolicy", builder =>
    {
        builder
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
        .WithOrigins("http://localhost:8080");
    });
});

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.UseCors("VueCorsPolicy");

app.Run();
