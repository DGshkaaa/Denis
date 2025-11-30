using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace ToolRentalApi.Models;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonIgnoreIfDefault]           
    [JsonIgnore]                    
    public string? Id { get; set; } 

    [BsonElement("name")]
    public string Name { get; set; } = string.Empty;

    [BsonElement("email")]
    public string Email { get; set; } = string.Empty;

    [BsonElement("phone")]
    public string Phone { get; set; } = string.Empty;

    [BsonElement("passwordHash")]
    [BsonIgnoreIfDefault]
    [JsonIgnore]
    public string? PasswordHash { get; set; } 

    [BsonElement("role")]
    [BsonIgnoreIfDefault]
    [JsonIgnore]
    public string Role { get; set; } = "User";
}