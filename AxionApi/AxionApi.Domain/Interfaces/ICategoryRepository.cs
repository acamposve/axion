using AxionApi.Domain.Models;

namespace AxionApi.Domain.Interfaces;

public interface ICategoryRepository
{
    Task<Category> CreateAsync(Category category);
    Task<IEnumerable<Category>> GetAllAsync();
    Task<Category> GetByIdAsync(int id);
    Task UpdateAsync(Category category);
    Task DeleteAsync(int id);
}
