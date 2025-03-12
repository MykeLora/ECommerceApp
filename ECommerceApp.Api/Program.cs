
using ECommerceApp.Application.Contracts;
using ECommerceApp.Application.Mapping;
using ECommerceApp.Application.Services.Products;
using ECommerceApp.Persistence.Context;
using ECommerceApp.Persistence.Interfaces.Products;
using ECommerceApp.Persistence.Repositories.Products;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ECommerceApp.Ioc.Dependencies.Product;
using ECommerceApp.Ioc.Dependencies.Context;


public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        #region "App Dependencies"

        builder.Services.AddProductDependencies();

        builder.Services.AddContextDependencies(builder.Configuration.GetConnectionString("DefaultConnection"));


        #endregion

        //Regirter services AutoMapper
        builder.Services.AddAutoMapper(typeof(GeneralProfile));

        builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            // This will use the property names as defined in the C# model
            options.JsonSerializerOptions.PropertyNamingPolicy = null;
        });

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

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