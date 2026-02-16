using Microsoft.EntityFrameworkCore;
using PeminjamanRuangApi.Data;
using PeminjamanRuangApi.Services; // Sesuaikan dengan nama folder 'Service' di gambar kamu

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(
            builder.Configuration.GetConnectionString("DefaultConnection")
        )
    )
);

// Tambahkan baris ini agar Service bisa digunakan di Controller
builder.Services.AddScoped<IPeminjamanService, PeminjamanService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 1. Letakkan CORS di sini agar diizinkan oleh browser
app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

// app.UseHttpsRedirection(); 
app.UseCors("AllowAll"); // Harus dipasang sebelum UseAuthorization
app.UseAuthorization();
app.MapControllers();
app.Run();