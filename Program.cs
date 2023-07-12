using Microsoft.EntityFrameworkCore;
using UrubuDoPix.Data;
using UrubuDoPix.Repositorios;
using UrubuDoPix.Repositorios.Interfaces;

namespace UrubuDoPix
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
            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<UrubuDoPixDBContext>(
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))

                );

            builder.Services.AddScoped<InvestimentosPix, InvestimentoRepositorio>();
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