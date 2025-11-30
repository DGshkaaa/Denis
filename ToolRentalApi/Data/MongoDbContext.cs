using MongoDB.Driver;
using ToolRentalApi.Models;

namespace ToolRentalApi.Data;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext()
    {

        var client = new MongoClient("mongodb://localhost:27017");
        _database = client.GetDatabase("ToolRentalDb");
    }

    public IMongoDatabase Database => _database;

    public IMongoCollection<User> Users => _database.GetCollection<User>("users");
    public IMongoCollection<Category> Categories => _database.GetCollection<Category>("categories");
    public IMongoCollection<Tool> Tools => _database.GetCollection<Tool>("tools");
    public IMongoCollection<Rental> Rentals => _database.GetCollection<Rental>("rentals");
}