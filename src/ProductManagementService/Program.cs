using ProductManagementService.Data.DataAccess;
using Npgsql;
using Microsoft.Extensions.DependencyInjection;
using ProductManagementService.Communication;
using ProductManagementService.Services;
using LogModel;
using ProductManagementService.Communication;

namespace ProductManagementService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //var connectionString = 

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<RequestWorker>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddSingleton<RmqSender>();
            builder.Services.AddHostedService<RmqReceiver>();
            builder.Services.AddSingleton<ILogSender, LogProductManagementSender>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}