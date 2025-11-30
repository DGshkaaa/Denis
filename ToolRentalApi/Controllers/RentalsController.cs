using Microsoft.AspNetCore.Mvc;
using ToolRentalApi.Models;
using ToolRentalApi.Services.Interfaces;
using FluentValidation;

namespace ToolRentalApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RentalsController : ControllerBase
{
    private readonly IRentalService _service;
    private readonly IValidator<Rental> _validator;

 

    public RentalsController(IRentalService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<Rental>>> Get()
        => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<Rental>> Get(string id)
    {
        var rental = await _service.GetByIdAsync(id);
        return rental is null ? NotFound() : Ok(rental);
    }

    [HttpPost]
    public async Task<ActionResult<Rental>> Create([FromBody] Rental rental)
    {
        var validationResult = await _validator.ValidateAsync(rental);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));

        var created = await _service.CreateAsync(rental);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] Rental rental)
    {
        var validationResult = await _validator.ValidateAsync(rental);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));

        var existing = await _service.GetByIdAsync(id);
        if (existing is null) return NotFound();

        rental.Id = id; // важливо для ReplaceOne в MongoDB
        await _service.UpdateAsync(id, rental);
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