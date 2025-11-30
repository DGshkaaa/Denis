using ToolRentalApi.Models;

namespace ToolRentalApi.Services.Interfaces;

public interface IToolService
{
    Task<List<Tool>> GetAllAsync();
    Task<Tool?> GetByIdAsync(string id);
    Task<Tool> CreateAsync(Tool tool);
    Task UpdateAsync(string id, Tool tool);
    Task DeleteAsync(string id);
}