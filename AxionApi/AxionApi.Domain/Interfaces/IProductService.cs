using AxionApi.Domain.DTOs;
using AxionApi.Domain.Models;

namespace AxionApi.Domain.Interfaces;

public interface IProductService
{
    Task<string> CreateProduct(ProductCreateDto request);
    Task<IEnumerable<Product>> GetProducts();
    Task<Product> GetProduct(int id);
    Task<string> UpdateProduct(int id, ProductUpdateDto request);
    Task<string> DeleteProduct(int id);
}
