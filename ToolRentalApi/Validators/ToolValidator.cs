using FluentValidation;
using ToolRentalApi.Models;

namespace ToolRentalApi.Validators;

public class ToolValidator : AbstractValidator<Tool>
{
    public ToolValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MinimumLength(3);
        RuleFor(x => x.PricePerDay).GreaterThan(0);
        RuleFor(x => x.OwnerUserId).NotEmpty();     
        RuleFor(x => x.CategoryId).NotEmpty();      
    }
}