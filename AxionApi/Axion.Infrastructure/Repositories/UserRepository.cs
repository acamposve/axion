using AxionApi.Domain.Interfaces;
using AxionApi.Domain.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Axion.Infrastructure.Repositories;

public class UserRepository : BaseRepository, IUserRepository
{
    private readonly IConfiguration _config;

    public UserRepository(IConfiguration config) : base(config)
    {
    }

    public async Task<User> GetByPhoneNumberAsync(string phoneNumber)
    {
        string query = "SELECT * FROM Users WHERE PhoneNumber = @PhoneNumber";
        using SqlConnection connection = CreateConnection(); // Uso del método heredado
        return await connection.QueryFirstOrDefaultAsync<User>(query, new { PhoneNumber = phoneNumber });
    }

    public async Task AddAsync(User user)
    {
        string query = "INSERT INTO Users (FirstName, LastName, PhoneNumber, Address, PasswordHash) VALUES (@FirstName, @LastName, @PhoneNumber, @Address, @PasswordHash)";
        using SqlConnection connection = CreateConnection(); // Uso del método heredado
        await connection.ExecuteAsync(query, new
        {
            user.FirstName,
            user.LastName,
            user.PhoneNumber,
            Address = user.Address,
            user.PasswordHash
        });
    }
}
