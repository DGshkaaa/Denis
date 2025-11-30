using FluentValidation;
using ToolRentalApi.Models;

namespace ToolRentalApi.Validators;

public class RentalValidator : AbstractValidator<Rental>
{
    public RentalValidator()
    {
        RuleFor(x => x.ToolId).NotEmpty();
        RuleFor(x => x.RenterUserId).NotEmpty();
        RuleFor(x => x.EndDate).GreaterThan(x => x.StartDate);
    }
}