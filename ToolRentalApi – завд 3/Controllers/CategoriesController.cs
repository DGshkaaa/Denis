using Microsoft.AspNetCore.Mvc;
using ToolRentalApi.Models;
using ToolRentalApi.Services.Interfaces;

namespace ToolRentalApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _service;

    public CategoriesController(ICategoryService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<Category>>> Get()
        => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> Get(string id)
    {
        var category = await _service.GetByIdAsync(id);
        return category is null ? NotFound() : Ok(category);
    }

    [HttpPost]
    public async Task<ActionResult<Category>> Create([FromBody] Category category)
    {
        if (string.IsNullOrWhiteSpace(category.Name) || category.Name.Length < 2)
            return BadRequest("Назва категорії має бути мінімум 2 символи");

        var created = await _service.CreateAsync(category);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] Category category)
    {
        if (string.IsNullOrWhiteSpace(category.Name) || category.Name.Length < 2)
            return BadRequest("Назва категорії має бути мінімум 2 символи");

        var existing = await _service.GetByIdAsync(id);
        if (existing is null) return NotFound();

        category.Id = id; // важливо! MongoDB оновлює за Id
        await _service.UpdateAsync(id, category);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var existing = await _service.GetByIdAsync(id);
        if (existing is null) return NotFound();

        await _service.DeleteAsync(id);
        return NoContent();
    }
}