using pojokkamera_backend.Data;
using pojokkamera_backend.Services;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using Microsoft.OpenApi.Models;

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

// Tambahkan Swagger/OpenAPI service untuk .NET 8
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Pojok Kamera API",
        Version = "v1",
        Description = "API untuk backend Pojok Kamera"
    });
});

builder.Services.AddControllers().
    AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase; // SomeKey -> someKey
    });

// CORS
builder.Services.AddCors(options =>
{
options.AddPolicy("AllowFrontend",
    policy =>
    {
        policy.WithOrigins("http://localhost:3000") // frontend Next.js
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); // kalau pakai cookie auth
    });
});


// Panggil fungsi register DbContext
InitDb(builder);

// Daftarkan service custom
builder.Services.AddScoped<AuthService>();
// kalau nanti ada service lain, tinggal tambahin:
// builder.Services.AddScoped<UserService>();
// builder.Services.AddScoped<OrderService>();

var app = builder.Build();

// Configure Swagger hanya di Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pojok Kamera API v1");
    });
}

// Nonaktifkan sementara HTTPS redirection jika perlu
// app.UseHttpsRedirection();
app.UseCors("AllowFrontend");
app.UseAuthorization();
app.MapControllers();

app.Run();