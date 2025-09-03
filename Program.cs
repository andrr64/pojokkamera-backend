using pojokkamera_backend.Data;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;
Env.Load();

// Refaktor: fungsi untuk membuat connection string dan register DbContext
void InitDb(WebApplicationBuilder builder)
{
    // Ambil variabel environment
    var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
    var dbName = Environment.GetEnvironmentVariable("DB_DATABASE");
    var dbUser = Environment.GetEnvironmentVariable("DB_USERNAME");
    var dbPass = Environment.GetEnvironmentVariable("DB_PASSWORD");

    // Buat connection string
    var connectionString = $"Host={dbHost};Database={dbName};Username={dbUser};Password={dbPass}";

    // Daftarkan DbContext
    builder.Services.AddDbContext<PojokKameraDbContext>(options =>
        options.UseNpgsql(connectionString)
    );
}

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

// Panggil fungsi
InitDb(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Nonaktifkan sementara untuk development untuk menghindari masalah 404
// app.UseHttpsRedirection();

app.MapControllers();

app.Run();
