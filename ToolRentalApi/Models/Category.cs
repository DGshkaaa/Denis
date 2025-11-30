using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace ToolRentalApi.Models;

public class Category
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonIgnoreIfDefault]    
    [JsonIgnore]
    public string? Id { get; set; }  

    [BsonElement("name")]
    public string Name { get; set; } = string.Empty;
}