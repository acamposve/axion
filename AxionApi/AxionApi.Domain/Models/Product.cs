namespace AxionApi.Domain.Models;

public class Product
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Image { get; set; }

    public int CategoryId { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public bool IsFeatured { get; set; }
}
