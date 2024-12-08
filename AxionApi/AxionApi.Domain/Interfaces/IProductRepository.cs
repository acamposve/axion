using AxionApi.Domain.DTOs;
using AxionApi.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace AxionApi.Domain.Interfaces;

public interface IProductRepository
{
    Task<string> SaveImage(IFormFile image);
    Task DeleteImage(string imagePath);
    Task CreateProduct(ProductCreateDto request, string imagePath);
    Task<IEnumerable<Product>> GetProducts();
    Task<Product> GetProduct(int id);
    Task UpdateProduct(int id, ProductUpdateDto request, Product product);
    Task DeleteProduct(int id);
}
