using AxionApi.Domain.DTOs;
using AxionApi.Domain.Interfaces;
using AxionApi.Domain.Models;

namespace Axion.Application;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<string> CreateProduct(ProductCreateDto request)
    {
        string imagePath = await _productRepository.SaveImage(request.Image);
        await _productRepository.CreateProduct(request, imagePath);
        return "Product created successfully.";
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await _productRepository.GetProducts();
    }

    public async Task<Product> GetProduct(int id)
    {
        return await _productRepository.GetProduct(id);
    }

    public async Task<string> UpdateProduct(int id, ProductUpdateDto request)
    {
        var product = await _productRepository.GetProduct(id);
        if (product == null)
        {
            return "Product not found.";
        }

        if (request.Image != null)
        {
            await _productRepository.DeleteImage(product.Image);
            product.Image = await _productRepository.SaveImage(request.Image);
        }

        await _productRepository.UpdateProduct(id, request, product);
        return "Product updated successfully.";
    }

    public async Task<string> DeleteProduct(int id)
    {
        var product = await _productRepository.GetProduct(id);
        if (product == null)
        {
            return "Product not found.";
        }

        await _productRepository.DeleteImage(product.Image);
        await _productRepository.DeleteProduct(id);
        return "Product deleted successfully.";
    }
}
