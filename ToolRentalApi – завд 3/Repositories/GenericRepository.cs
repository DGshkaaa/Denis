using MongoDB.Bson;
using MongoDB.Driver;
using ToolRentalApi.Data;
using ToolRentalApi.Repositories.Interfaces;

namespace ToolRentalApi.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly IMongoCollection<T> _collection;

    public GenericRepository(MongoDbContext context)
    {
        var collectionName = typeof(T).Name.ToLowerInvariant() + "s";
        _collection = context.Database.GetCollection<T>(collectionName);
    }
    public IMongoCollection<T> GetCollection() => _collection;
    public async Task<List<T>> GetAllAsync() =>
        await _collection.Find(_ => true).ToListAsync();

    public async Task<T?> GetByIdAsync(string id)
    {
        if (!ObjectId.TryParse(id, out var objectId))
            return null;

        var filter = Builders<T>.Filter.Eq("_id", objectId);
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<T> CreateAsync(T entity)
    {
        await _collection.InsertOneAsync(entity);
        return entity;
    }

    public async Task UpdateAsync(string id, T entity)
    {
        if (!ObjectId.TryParse(id, out var objectId))
            throw new ArgumentException("Invalid ObjectId format");

        var filter = Builders<T>.Filter.Eq("_id", objectId);
        var result = await _collection.ReplaceOneAsync(filter, entity);

        if (result.MatchedCount == 0)
            throw new KeyNotFoundException($"Entity with id {id} not found");
    }

    public async Task DeleteAsync(string id)
    {
        if (!ObjectId.TryParse(id, out var objectId))
            throw new ArgumentException("Invalid ObjectId format");

        var filter = Builders<T>.Filter.Eq("_id", objectId);
        await _collection.DeleteOneAsync(filter);
    }
}