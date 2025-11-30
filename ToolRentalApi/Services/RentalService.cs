using ToolRentalApi.Models;
using ToolRentalApi.Repositories.Interfaces;
using ToolRentalApi.Services.Interfaces;

namespace ToolRentalApi.Services;

public class RentalService : IRentalService
{
    private readonly IGenericRepository<Rental> _repo;

    public RentalService(IGenericRepository<Rental> repo) => _repo = repo;

    public Task<List<Rental>> GetAllAsync() => _repo.GetAllAsync();
    public Task<Rental?> GetByIdAsync(string id) => _repo.GetByIdAsync(id);
    public Task<Rental> CreateAsync(Rental rental) => _repo.CreateAsync(rental);
    public Task UpdateAsync(string id, Rental rental) => _repo.UpdateAsync(id, rental);
    public Task DeleteAsync(string id) => _repo.DeleteAsync(id);
}