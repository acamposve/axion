using AxionApi.Domain.Models;

namespace AxionApi.Domain.Interfaces;

public interface IAdminRepository
{
    Task<Admin> CreateAsync(Admin admin);
    Task<IEnumerable<Admin>> GetAllAsync();
    Task<Admin> GetByIdAsync(int id);
    Task UpdateAsync(Admin admin);
    Task DeleteAsync(int id);
    Task<Admin> GetByLoginAsync(string login);
}
