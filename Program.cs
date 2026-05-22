using AlunosCrudApiCSharp.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseMySql(
                builder.Configuration.GetConnectionString("DefaultConnection"),
                ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection")));
        });

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
        });

// Swagger removido: endpoints API explorer e geração de Swagger eliminados

        var app = builder.Build();

// Swagger removido: middleware UseSwagger/UseSwaggerUI eliminado

        app.UseCors("AllowAll");
        app.UseAuthorization();

        try
        {
            app.MapControllers();
        }
        catch (ReflectionTypeLoadException ex)
        {
            foreach (Exception inner in ex.LoaderExceptions)
            {
                Console.WriteLine(inner.Message);
            }
        }


        app.MapGet("/api/health", () => Results.Ok("API is healthy"));

        app.Run();
    }
}