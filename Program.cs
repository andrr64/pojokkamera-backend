using pojokkamera_backend.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// === TAMBAHKAN BARIS INI untuk mendaftarkan service controller ===
builder.Services.AddControllers();

// 1. Ambil Connection String dari appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. Daftarkan DbContext sebagai service
builder.Services.AddDbContext<PojokKameraDbContext>(options =>
    options.UseNpgsql(connectionString)
);

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Nonaktifkan sementara untuk development untuk menghindari masalah 404
// app.UseHttpsRedirection();

// === TAMBAHKAN BARIS INI untuk memetakan rute dari controller ===
app.MapControllers();

app.Run();