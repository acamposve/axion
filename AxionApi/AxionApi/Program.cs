using Axion.Application;
using Axion.Infrastructure.Repositories;
using AxionApi;
using AxionApi.Domain.Interfaces;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<RegisterUser>(); // Asegúrate de que este tipo existe y está implementado
builder.Services.AddScoped<LoginUser>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(delegate (CorsOptions options)
{
    options.AddPolicy("AllowSpecificOrigins", delegate (CorsPolicyBuilder policy)
    {
        policy.WithOrigins("http://localhost:8080", "http://localhost:8100", "https://presenciavirtual.net", "http://presenciavirtual.net")
              .AllowAnyHeader()
              .AllowAnyMethod()
                            .SetIsOriginAllowedToAllowWildcardSubdomains()
              .WithExposedHeaders("Access-Control-Allow-Origin");
    });
});
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).Enrich.FromLogContext().WriteTo.Console().CreateLogger();
builder.Host.UseSerilog();
WebApplication app = builder.Build();
app.UseMiddleware<LoggingMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowSpecificOrigins");
app.UseSerilogRequestLogging();

app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();
app.Run();
