using ToolRentalApi.Models;

namespace ToolRentalApi.Services.Interfaces;

public interface IUserService
{
    Task<List<User>> GetAllAsync();
    Task<User?> GetByIdAsync(string id);
    Task<User> CreateAsync(User user);
    Task UpdateAsync(string id, User user);
    Task DeleteAsync(string id);

    Task<User?> GetByEmailAsync(string email);
    Task<User> CreateWithPasswordAsync(User user, string plainPassword);
}