using AxionApi.Domain.DTOs;
using AxionApi.Domain.Interfaces;
using AxionApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axion.Application;

public class RegisterUser
{
    private readonly IUserRepository _userRepository;

    public RegisterUser(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<string> Execute(UserRegisterDto request)
    {
        // Verificar si las contraseñas coinciden
        if (request.Password != request.ConfirmPassword)
        {
            return "Passwords do not match."; // Puedes lanzar una excepción también
        }

        // Verificar si el usuario ya existe (por número de teléfono)
        User existingUser = await _userRepository.GetByPhoneNumberAsync(request.PhoneNumber);
        if (existingUser != null)
        {
            return "User already exists."; // Puedes lanzar una excepción también
        }

        // Crear un nuevo usuario
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
        User newUser =User.Create(request.FirstName, request.LastName, request.PhoneNumber, request.Street + ", " + request.Number, passwordHash);



        // Lógica para registrar al usuario en la base de datos
        await _userRepository.AddAsync(newUser); // Agregamos este método a la interfaz

        return "User registered successfully.";
    }
}
