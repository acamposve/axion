using AxionApi.Domain.DTOs;
using AxionApi.Domain.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AxionApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    private readonly string _connectionString;

    public AdminController(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAdmin([FromBody] Admin admin)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        admin.Password = HashPassword(admin.Password);
        string query = "INSERT INTO Admins (Nombre, Login, Password, Celular) VALUES (@Nombre, @Login, @Password, @Celular)";
        await connection.ExecuteAsync(query, new { admin.Nombre, admin.Login, admin.Password, admin.Celular });
        return Ok(new
        {
            message = "Administrador creado exitosamente"
        });
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetAdmins()
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        string query = "SELECT * FROM Admins";
        return Ok(await connection.QueryAsync<Admin>(query));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAdmin(int id)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        string query = "SELECT * FROM Admins WHERE Id = @Id";
        Admin admin = await connection.QueryFirstOrDefaultAsync<Admin>(query, new
        {
            Id = id
        });
        if (admin == null)
        {
            return NotFound();
        }
        return Ok(admin);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateAdmin(int id, [FromBody] Admin admin)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        if (!string.IsNullOrEmpty(admin.Password))
        {
            admin.Password = HashPassword(admin.Password);
        }
        string query = "UPDATE Admins SET Nombre = @Nombre, Login = @Login, Password = @Password, Celular = @Celular WHERE Id = @Id";
        await connection.ExecuteAsync(query, new
        {
            Nombre = admin.Nombre,
            Login = admin.Login,
            Password = admin.Password,
            Celular = admin.Celular,
            Id = id
        });
        return Ok(new
        {
            message = "Administrador actualizado exitosamente"
        });
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteAdmin(int id)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        string query = "DELETE FROM Admins WHERE Id = @Id";
        await connection.ExecuteAsync(query, new
        {
            Id = id
        });
        return Ok(new
        {
            message = "Administrador eliminado exitosamente"
        });
    }

    private string HashPassword(string password)
    {
        using SHA256 sha256Hash = SHA256.Create();
        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
        StringBuilder builder = new StringBuilder();
        byte[] array = bytes;
        foreach (byte b in array)
        {
            builder.Append(b.ToString("x2"));
        }
        return builder.ToString();
    }

    [HttpPost("login")]
    public async Task<IActionResult> AdminLogin([FromBody] AdminLoginDto adminLoginDto)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        string query = "SELECT * FROM Admins WHERE Login = @Login";
        Admin admin = await connection.QueryFirstOrDefaultAsync<Admin>(query, new { adminLoginDto.Login });
        if (admin == null)
        {
            return Unauthorized(new
            {
                message = "Administrador no encontrado"
            });
        }
        if (admin.Password != HashPassword(adminLoginDto.Password))
        {
            return Unauthorized(new
            {
                message = "Contraseña incorrecta"
            });
        }
        string token = GenerateJwtToken(admin);
        return Ok(new
        {
            message = "Login exitoso",
            token = token
        });
    }

    private string GenerateJwtToken(Admin admin)
    {
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        byte[] key = Encoding.UTF8.GetBytes("#EstaEsUnaClaveDe32Bytes12345678@");
        SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor();
        securityTokenDescriptor.Subject = new ClaimsIdentity(new Claim[3]
        {
            new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", admin.Id.ToString()),
            new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", admin.Login),
            new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Admin")
        });
        securityTokenDescriptor.Expires = DateTime.UtcNow.AddHours(1.0);
        securityTokenDescriptor.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), "HS256");
        SecurityTokenDescriptor tokenDescriptor = securityTokenDescriptor;
        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
