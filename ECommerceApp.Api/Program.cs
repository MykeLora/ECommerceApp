using ECommerceApp.Application.Interfaces;
using ECommerceApp.Application.Services;
using ECommerceApp.Persistence.Base;
using ECommerceApp.Persistence.Context;
using ECommerceApp.Persistence.Interfaces.Customers;
using ECommerceApp.Persistence.Interfaces.Products;
using ECommerceApp.Persistence.Repositories.Customers;
using ECommerceApp.Persistence.Repositories.Products;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        // Service for the Repository
        builder.Services.AddScoped<IProductRepository, ProductRepository>();

        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

        builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

        // Add services Application

        builder.Services.AddTransient<CategoryService>();


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