
using AutoMapper;
using FM.Application.IService;
using FM.Application.Service;
using FM.Domain.Entities;
using FM.Infrastructure.IRepository;
using FM.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace FM.API
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

            var connectionString = builder.Configuration.GetConnectionString("OracleConn");

            //Đăng ký AppDbContext vào DI Container
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseOracle(connectionString));

            //Dependency Injection
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();

            builder.Services.AddAutoMapper(typeof(MappingProfile));

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
