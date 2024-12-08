using AxionApi.Domain.Interfaces;
using AxionApi.Domain.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Axion.Infrastructure.Repositories;

public class AdminRepository : BaseRepository, IAdminRepository
{
    private readonly IConfiguration _config;
    public AdminRepository(IConfiguration config) : base(config)
    {
            
    }


    public async Task<Admin> CreateAsync(Admin admin)
    {
        using SqlConnection connection = CreateConnection(); // Uso del método heredado
        string query = "INSERT INTO Admins (Nombre, Login, Password, Celular) VALUES (@Nombre, @Login, @Password, @Celular); SELECT CAST(SCOPE_IDENTITY() as int);";
        var id = await connection.ExecuteScalarAsync<int>(query, new { admin.Nombre, admin.Login, admin.Password, admin.Celular });
        admin.Id = id; // Asignar el ID generado
        return admin;
    }

    public async Task<IEnumerable<Admin>> GetAllAsync()
    {
        using SqlConnection connection = CreateConnection(); // Uso del método heredado
        string query = "SELECT * FROM Admins";
        return await connection.QueryAsync<Admin>(query);
    }

    public async Task<Admin> GetByIdAsync(int id)
    {
        using SqlConnection connection = CreateConnection(); // Uso del método heredado
        string query = "SELECT * FROM Admins WHERE Id = @Id";
        return await connection.QueryFirstOrDefaultAsync<Admin>(query, new { Id = id });
    }

    public async Task UpdateAsync(Admin admin)
    {
        using SqlConnection connection = CreateConnection(); // Uso del método heredado
        string query = "UPDATE Admins SET Nombre = @Nombre, Login = @Login, Password = @Password, Celular = @Celular WHERE Id = @Id";
        await connection.ExecuteAsync(query, new { admin.Nombre, admin.Login, admin.Password, admin.Celular, Id = admin.Id });
    }

    public async Task DeleteAsync(int id)
    {
        using SqlConnection connection = CreateConnection(); // Uso del método heredado
        string query = "DELETE FROM Admins WHERE Id = @Id";
        await connection.ExecuteAsync(query, new { Id = id });
    }

    public async Task<Admin> GetByLoginAsync(string login)
    {
        using SqlConnection connection = CreateConnection(); // Uso del método heredado
        string query = "SELECT * FROM Admins WHERE Login = @Login";
        return await connection.QueryFirstOrDefaultAsync<Admin>(query, new { Login = login });
    }
}
