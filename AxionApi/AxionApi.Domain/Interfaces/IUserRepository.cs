using AxionApi.Domain.Models;

namespace AxionApi.Domain.Interfaces;

public interface IUserRepository
{
    Task<User> GetByPhoneNumberAsync(string phoneNumber);
    Task AddAsync(User user); // Nuevo método para agregar usuario
}
