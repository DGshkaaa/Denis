using BCrypt.Net;
using MongoDB.Driver;
using ToolRentalApi.Models;
using ToolRentalApi.Repositories.Interfaces;
using ToolRentalApi.Services.Interfaces;

namespace ToolRentalApi.Services;

public class UserService : IUserService
{
    private readonly IGenericRepository<User> _repo;

    public UserService(IGenericRepository<User> repo)
    {
        _repo = repo;
    }

    public Task<List<User>> GetAllAsync() => _repo.GetAllAsync();
    public Task<User?> GetByIdAsync(string id) => _repo.GetByIdAsync(id);
    public Task<User> CreateAsync(User user) => _repo.CreateAsync(user);
    public Task UpdateAsync(string id, User user) => _repo.UpdateAsync(id, user);
    public Task DeleteAsync(string id) => _repo.DeleteAsync(id);

    public async Task<User?> GetByEmailAsync(string email)
    {
        var filter = Builders<User>.Filter.Eq("email", email.ToLowerInvariant());
        return await _repo.GetCollection().Find(filter).FirstOrDefaultAsync();
    }

    public async Task<User> CreateWithPasswordAsync(User user, string plainPassword)
    {
        if (string.IsNullOrWhiteSpace(plainPassword))
            throw new ArgumentException("Пароль обов'язковий");

        user.Email = user.Email.ToLowerInvariant();
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(plainPassword);
        user.Role ??= "User";

        return await _repo.CreateAsync(user);
    }
}