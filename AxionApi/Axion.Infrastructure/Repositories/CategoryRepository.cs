using AxionApi.Domain.Interfaces;
using AxionApi.Domain.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axion.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly string _connectionString;

    public CategoryRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<Category> CreateAsync(Category category)
    {
        string query = "INSERT INTO Categories (Name, Description, Image) VALUES (@Name, @Description, @Image); SELECT CAST(SCOPE_IDENTITY() as int);";
        using SqlConnection connection = new SqlConnection(_connectionString);
        var id = await connection.ExecuteScalarAsync<int>(query, category);
        category.Id = id; // Asigna el ID generado
        return category;
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        string query = "SELECT * FROM Categories";
        using SqlConnection connection = new SqlConnection(_connectionString);
        return await connection.QueryAsync<Category>(query);
    }

    public async Task<Category> GetByIdAsync(int id)
    {
        string query = "SELECT * FROM Categories WHERE Id = @Id";
        using SqlConnection connection = new SqlConnection(_connectionString);
        return await connection.QueryFirstOrDefaultAsync<Category>(query, new { Id = id });
    }

    public async Task UpdateAsync(Category category)
    {
        string query = "UPDATE Categories SET Name = @Name, Description = @Description, Image = @Image WHERE Id = @Id";
        using SqlConnection connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync(query, category);
    }

    public async Task DeleteAsync(int id)
    {
        string query = "DELETE FROM Categories WHERE Id = @Id";
        using SqlConnection connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync(query, new { Id = id });
    }
}
