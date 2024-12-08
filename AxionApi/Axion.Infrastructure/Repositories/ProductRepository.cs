using AxionApi.Domain.DTOs;
using AxionApi.Domain.Interfaces;
using AxionApi.Domain.Models;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Axion.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly IConfiguration _config;

    public ProductRepository(IConfiguration config)
    {
        _config = config;
    }

    public async Task<string> SaveImage(IFormFile image)
    {
        if (image == null) return null;

        string fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
        string imageSavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
        using (var stream = new FileStream(imageSavePath, FileMode.Create))
        {
            await image.CopyToAsync(stream);
        }

        return "/images/" + fileName;
    }

    public async Task DeleteImage(string imagePath)
    {
        if (!string.IsNullOrEmpty(imagePath))
        {
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imagePath.TrimStart('/'));
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
        }
    }

    public async Task CreateProduct(ProductCreateDto request, string imagePath)
    {
        string query = "INSERT INTO Products (Name, Image, CategoryId, Description, Price, IsFeatured) VALUES (@Name, @Image, @CategoryId, @Description, @Price, @IsFeatured)";
        using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        await connection.ExecuteAsync(query, new
        {
            request.Name,
            Image = imagePath,
            request.CategoryId,
            request.Description,
            request.Price,
            request.IsFeatured
        });
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        const string query = "SELECT * FROM Products";
        using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        return await connection.QueryAsync<Product>(query);
    }

    public async Task<Product> GetProduct(int id)
    {
        const string query = "SELECT * FROM Products WHERE Id = @Id";
        using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        return await connection.QueryFirstOrDefaultAsync<Product>(query, new { Id = id });
    }

    public async Task UpdateProduct(int id, ProductUpdateDto request, Product product)
    {
        product.Name = request.Name ?? product.Name;
        product.Description = request.Description ?? product.Description;
        product.Price = request.Price ?? product.Price;
        product.IsFeatured = request.IsFeatured ?? product.IsFeatured;
        product.CategoryId = request.CategoryId ?? product.CategoryId;

        var updateQuery = "UPDATE Products SET Name = @Name, Description = @Description, Image = @Image, Price = @Price, IsFeatured = @IsFeatured, CategoryId = @CategoryId WHERE Id = @Id";
        using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        await connection.ExecuteAsync(updateQuery, new
        {
            product.Name,
            product.Description,
            product.Image,
            product.Price,
            product.IsFeatured,
            product.CategoryId,
            Id = id
        });
    }

    public async Task DeleteProduct(int id)
    {
        const string deleteQuery = "DELETE FROM Products WHERE Id = @Id";
        using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        await connection.ExecuteAsync(deleteQuery, new { Id = id });
    }
}
