namespace ToolRentalApi.Models.Dto;

public record RegisterRequest(
    string Name,
    string Email,
    string Phone,
    string Password
);