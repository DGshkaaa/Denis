using ToolRentalApi.Models;

namespace ToolRentalApi.Services.Interfaces;

public interface IRentalService
{
    Task<List<Rental>> GetAllAsync();
    Task<Rental?> GetByIdAsync(string id);
    Task<Rental> CreateAsync(Rental rental);
    Task UpdateAsync(string id, Rental rental);
    Task DeleteAsync(string id);
}