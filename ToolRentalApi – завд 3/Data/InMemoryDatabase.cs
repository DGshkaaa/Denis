using MongoDB.Bson;
using ToolRentalApi.Models;

namespace ToolRentalApi.Data;

public static class InMemoryDatabase
{
    public static List<User> Users { get; } = new()
    {
        new() { Id = ObjectId.GenerateNewId().ToString(), Name = "Іван Петренко", Email = "ivan@gmail.com", Phone = "+380671234567" },
        new() { Id = ObjectId.GenerateNewId().ToString(), Name = "Олена Коваль", Email = "olena@gmail.com", Phone = "+380951112233" },
        new User
    {
        Id = ObjectId.GenerateNewId().ToString(),
        Name = "Admin",
        Email = "admin@toolrental.com",
        Phone = "+380991234567",
        Role = "Admin",
        PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin123!")  // ? обов’язково!
    },
    };

    public static List<Category> Categories { get; } = new()
    {
        new() { Id = ObjectId.GenerateNewId().ToString(), Name = "Електроінструмент" },
        new() { Id = ObjectId.GenerateNewId().ToString(), Name = "3D-друк" },
        new() { Id = ObjectId.GenerateNewId().ToString(), Name = "Шиття" }
    };

    public static List<Tool> Tools { get; } = new()
    {

        new()
        {
            Id = ObjectId.GenerateNewId().ToString(),
            OwnerUserId = Users[0].Id,     
            CategoryId = Categories[0].Id,  
            Name = "Дриль Bosch",
            PricePerDay = 400,
            Status = ToolStatus.Available
        },
        new()
        {
            Id = ObjectId.GenerateNewId().ToString(),
            OwnerUserId = Users[1].Id,
            CategoryId = Categories[1].Id,
            Name = "3D-принтер Ender 3",
            PricePerDay = 900
        }
    };

    public static List<Rental> Rentals { get; } = new()
    {
        new()
        {
            Id = ObjectId.GenerateNewId().ToString(),
            ToolId = Tools[0].Id,
            RenterUserId = Users[1].Id,
            StartDate = DateTime.Today.AddDays(-2),
            EndDate = DateTime.Today.AddDays(5),
            TotalPrice = 2800
        }
    };
}