using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace ToolRentalApi.Models;

public enum RentalStatus { Active, Completed, Canceled }

public class Rental
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonIgnoreIfDefault]    
    [JsonIgnore]
    public string? Id { get; set; }  

    [BsonElement("toolId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string ToolId { get; set; } = string.Empty;

    [BsonElement("renterUserId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string RenterUserId { get; set; } = string.Empty;

    [BsonElement("startDate")]
    public DateTime StartDate { get; set; }

    [BsonElement("endDate")]
    public DateTime EndDate { get; set; }

    [BsonElement("totalPrice")]
    public decimal TotalPrice { get; set; }

    [BsonElement("status")]
    public RentalStatus Status { get; set; } = RentalStatus.Active;

    [BsonElement("createdAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}