using AxionApi.Domain.DTOs;
using AxionApi.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateCategory([FromForm] CategoryCreateDto request)
    {
        string imagePath = await SaveImage(request.Image);
        var category = await _categoryService.CreateCategory(request, imagePath);
        return Ok("Category created successfully.");
    }

    [HttpGet]
    [Route("all")]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await _categoryService.GetCategories();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategory(int id)
    {
        var category = await _categoryService.GetCategory(id);
        if (category == null) return NotFound("Category not found.");
        return Ok(category);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(int id, [FromForm] CategoryUpdateDto request)
    {
        string imagePath = null;

        if (request.Image != null)
        {
            // Lógica para manejar la imagen (eliminar la antigua, guardar la nueva)
            imagePath = await SaveImage(request.Image);
        }

        await _categoryService.UpdateCategory(id, request, imagePath);
        return Ok("Category updated successfully.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        await _categoryService.DeleteCategory(id);
        return Ok("Category deleted successfully.");
    }

    private async Task<string> SaveImage(IFormFile image)
    {
        if (image == null) return null;

        // Generar nombre único para la imagen
        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);

        // Definir la ruta donde se guardará la imagen
        string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

        // Verificar si el directorio existe, si no, crearlo
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        // Ruta completa donde se guardará la imagen
        string imageSavePath = Path.Combine(directoryPath, fileName);

        // Guardar la imagen en el servidor
        using FileStream stream = new FileStream(imageSavePath, FileMode.Create);
        await image.CopyToAsync(stream);

        // Guardar la ruta relativa de la imagen
        return "/images/" + fileName;
    }
}