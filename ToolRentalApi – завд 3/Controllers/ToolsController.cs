using Microsoft.AspNetCore.Mvc;
using ToolRentalApi.Models;
using ToolRentalApi.Services.Interfaces;

namespace ToolRentalApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToolsController : ControllerBase
{
    private readonly IToolService _service;

    public ToolsController(IToolService service) => _service = service;

    [HttpGet]
    public async Task<ActionResult<List<Tool>>> Get() =>
        Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<Tool>> Get(string id)
    {
        var tool = await _service.GetByIdAsync(id);
        return tool == null ? NotFound() : Ok(tool);
    }

    [HttpPost]
    public async Task<ActionResult<Tool>> Post([FromBody] Tool tool)
    {
        var created = await _service.CreateAsync(tool);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, [FromBody] Tool tool)
    {
        await _service.UpdateAsync(id, tool);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}