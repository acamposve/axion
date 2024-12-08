using AxionApi.Domain.DTOs;
using AxionApi.Domain.Interfaces;
using AxionApi.Domain.Models;

namespace Axion.Application;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Category> CreateCategory(CategoryCreateDto categoryCreateDto, string imagePath)
    {
        var category = new Category
        {
            Name = categoryCreateDto.Name,
            Description = categoryCreateDto.Description,
            Image = imagePath
        };
        return await _categoryRepository.CreateAsync(category);
    }

    public async Task<IEnumerable<Category>> GetCategories()
    {
        return await _categoryRepository.GetAllAsync();
    }

    public async Task<Category> GetCategory(int id)
    {
        return await _categoryRepository.GetByIdAsync(id);
    }

    public async Task UpdateCategory(int id, CategoryUpdateDto categoryUpdateDto, string imagePath)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category == null) throw new Exception("Category not found.");

        category.Name = categoryUpdateDto.Name ?? category.Name;
        category.Description = categoryUpdateDto.Description ?? category.Description;
        if (imagePath != null) category.Image = imagePath;

        await _categoryRepository.UpdateAsync(category);
    }

    public async Task DeleteCategory(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category == null) throw new Exception("Category not found.");
        await _categoryRepository.DeleteAsync(id);
    }
}
