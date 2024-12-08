using Microsoft.AspNetCore.Http;

namespace AxionApi.Domain.DTOs;

public class CategoryCreateDto
{
    public string Name { get; set; }

    public string Description { get; set; }

    public IFormFile Image { get; set; }
}
