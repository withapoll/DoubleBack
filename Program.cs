using Microsoft.EntityFrameworkCore;
using DoubleBack.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<DoubleBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("localdb")));
var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
