using AxionApi.Domain.DTOs;

namespace AxionApi.Domain.Interfaces;

public interface IAdminService
{
    Task<AdminResponseDto> CreateAdmin(AdminCreateDto adminCreateDto);
    Task<IEnumerable<AdminDto>> GetAdmins();
    Task<AdminDto> GetAdmin(int id);
    Task<AdminResponseDto> UpdateAdmin(int id, AdminCreateDto adminUpdateDto);
    Task<AdminResponseDto> DeleteAdmin(int id);
    Task<AdminResponseDto> AdminLogin(AdminLoginDto adminLoginDto);
}
