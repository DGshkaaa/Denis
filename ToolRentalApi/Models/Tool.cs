using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace ToolRentalApi.Models;

public enum ToolStatus { Available, Rented, Maintenance }

public class Tool
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonIgnoreIfDefault]     
    [JsonIgnore]               
    public string? Id { get; set; } = null;  

    [BsonElement("ownerUserId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string OwnerUserId { get; set; } = string.Empty;

    [BsonElement("categoryId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string CategoryId { get; set; } = string.Empty;

    [BsonElement("name")]
    public string Name { get; set; } = string.Empty;

    [BsonElement("description")]
    public string? Description { get; set; }

    [BsonElement("pricePerDay")]
    public decimal PricePerDay { get; set; }

    [BsonElement("status")]
    public ToolStatus Status { get; set; } = ToolStatus.Available;
}