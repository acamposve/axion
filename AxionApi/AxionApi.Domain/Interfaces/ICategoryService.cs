using AxionApi.Domain.DTOs;
using AxionApi.Domain.Models;

namespace AxionApi.Domain.Interfaces;

public interface ICategoryService
{
    Task<Category> CreateCategory(CategoryCreateDto categoryCreateDto, string imagePath);

    Task<IEnumerable<Category>> GetCategories();

    Task<Category> GetCategory(int id);

    Task UpdateCategory(int id, CategoryUpdateDto categoryUpdateDto, string imagePath);

    Task DeleteCategory(int id);
}
