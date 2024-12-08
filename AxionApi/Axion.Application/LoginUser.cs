using AxionApi.Domain.DTOs;
using AxionApi.Domain.Interfaces;
using AxionApi.Domain.Models;

namespace Axion.Application;

public class LoginUser
{
    private readonly IUserRepository _userRepository;

    public LoginUser(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<LoginResponseDto> Execute(UserLoginDto request)
    {
        User user = await _userRepository.GetByPhoneNumberAsync(request.PhoneNumber);
        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
        {
            return null; // O puedes lanzar una excepción
        }

        return new LoginResponseDto
        {
            Message = "Login successful.",
            FullName = user.FirstName // Asegúrate de que el modelo User tenga una propiedad FullName
        };
    }
}
