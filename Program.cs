
using EcoDenuncia.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace EcoDenuncia
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

            builder.Services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API EcoDenuncia",
                    Version = "v1",
                    Description = "API EcoDenúncia - Global Solution 2025\n\n" +
                    "Integrantes:\n"+
                    "• Larissa Muniz (RM557197) \n" +
                    "• João Victor Michaeli (RM555678) \n" +
                    "• Henrique Garcia (RM558062) ",
                    Contact = new OpenApiContact
                    {
                        Name = "Larissa Muniz",
                        Email = "larissampmuniz@gmail.com"
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                // Inclui comentários XML para o Swagger
                swagger.IncludeXmlComments(xmlPath);
            });

            // Configura o DbContext para Oracle (ou outro banco que usar)
            builder.Services.AddDbContext<EcoDenunciaContext>(options =>
            {
                options.UseOracle(builder.Configuration.GetConnectionString("Oracle"));
                // Se usar SQL Server, troque para:
                // options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServer"));
            });

            var app = builder.Build();

            // Middleware pipeline
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
