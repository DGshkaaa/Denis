using ToolRentalApi.Models;
using ToolRentalApi.Repositories.Interfaces;
using ToolRentalApi.Services.Interfaces;

namespace ToolRentalApi.Services;

public class ToolService : IToolService
{
    private readonly IGenericRepository<Tool> _repo;

    public ToolService(IGenericRepository<Tool> repo) => _repo = repo;

    public Task<List<Tool>> GetAllAsync() => _repo.GetAllAsync();
    public Task<Tool?> GetByIdAsync(string id) => _repo.GetByIdAsync(id);
    public Task<Tool> CreateAsync(Tool tool) => _repo.CreateAsync(tool);
    public Task UpdateAsync(string id, Tool tool) => _repo.UpdateAsync(id, tool);
    public Task DeleteAsync(string id) => _repo.DeleteAsync(id);
}