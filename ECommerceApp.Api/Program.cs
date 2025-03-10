
using ECommerceApp.Application.Contracts;
using ECommerceApp.Application.Mapping;
using ECommerceApp.Application.Services.Products;
using ECommerceApp.Persistence.Context;
using ECommerceApp.Persistence.Interfaces.Products;
using ECommerceApp.Persistence.Repositories.Products;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;


public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        //Regirter services AutoMapper
        builder.Services.AddAutoMapper(typeof(GeneralProfile));


        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddTransient<IProductService, ProductService>();



        builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            // This will use the property names as defined in the C# model
            options.JsonSerializerOptions.PropertyNamingPolicy = null;
        });

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Configure EF Core with SQL Server
        builder.Services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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