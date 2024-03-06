using Microsoft.EntityFrameworkCore;
using WebApiSistemaGestion.database;
using WebApiSistemaGestion.service;

namespace WebApiSistemaGestion
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ProductoService>();
            builder.Services.AddScoped<UsuarioService>();

            builder.Services.AddDbContext<CoderContext>(options =>
            {
                options.UseSqlServer("Server=DESKTOP-3CED13T\\SQLEXPRESS; Database=coderhouse; Trusted_Connection=True;");
            });

        var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}