using AxionApi.Domain.DTOs;
using AxionApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axion.Application
{
    public class AdminService : IAdminService
    {
        private readonly IUserRepository _userRepository;

        public AdminService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<AdminResponseDto> AdminLogin(AdminLoginDto adminLoginDto)
        {
            throw new NotImplementedException();
        }

        public async Task<AdminResponseDto> CreateAdmin(AdminCreateDto adminCreateDto)
        {
            throw new NotImplementedException();
        }

        public Task<AdminResponseDto> DeleteAdmin(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AdminDto> GetAdmin(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AdminDto>> GetAdmins()
        {
            throw new NotImplementedException();
        }

        public Task<AdminResponseDto> UpdateAdmin(int id, AdminCreateDto adminUpdateDto)
        {
            throw new NotImplementedException();
        }

        // Implementa otros métodos
    }
}
