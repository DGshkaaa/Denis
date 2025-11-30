using ToolRentalApi.Models;
using ToolRentalApi.Repositories.Interfaces;
using ToolRentalApi.Services.Interfaces;

namespace ToolRentalApi.Services;

public class CategoryService : ICategoryService
{
    private readonly IGenericRepository<Category> _repo;

    public CategoryService(IGenericRepository<Category> repo) => _repo = repo;

    public Task<List<Category>> GetAllAsync() => _repo.GetAllAsync();
    public Task<Category?> GetByIdAsync(string id) => _repo.GetByIdAsync(id);
    public Task<Category> CreateAsync(Category category) => _repo.CreateAsync(category);
    public Task UpdateAsync(string id, Category category) => _repo.UpdateAsync(id, category);
    public Task DeleteAsync(string id) => _repo.DeleteAsync(id);
}