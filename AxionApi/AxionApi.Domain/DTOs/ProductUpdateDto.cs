using Microsoft.AspNetCore.Http;

namespace AxionApi.Domain.DTOs;

public class ProductUpdateDto
{
    public string Name { get; set; }

    public IFormFile Image { get; set; }

    public int? CategoryId { get; set; }

    public string Description { get; set; }

    public decimal? Price { get; set; }

    public bool? IsFeatured { get; set; }
}
