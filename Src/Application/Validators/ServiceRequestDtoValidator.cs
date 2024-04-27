using Application.DTOs;
using FluentValidation;

namespace Application.Validators;

public class ServiceRequestDtoValidator : AbstractValidator<ServiceRequestDto>
{
    public ServiceRequestDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .MaximumLength(255)
            .WithMessage("Name must not exceed 255 characters");
        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description is required")
            .MaximumLength(255)
            .WithMessage("Description must not exceed 255 characters");
        RuleFor(x => x.Icon)
            .NotEmpty()
            .WithMessage("Icon is required")
            .MaximumLength(255)
            .WithMessage("Icon must not exceed 255 characters");
        RuleFor(x => x.Price)
            .NotEmpty()
            .WithMessage("Price is required");
        RuleFor(x => x.TimeInMinutes)
            .NotEmpty()
            .WithMessage("TimeInMinutes is required");
        RuleFor(x => x.Active)
            .NotEmpty()
            .WithMessage("Active is required");
    }
}

// public string Name { get; set; }
// public string Description { get; set; }
// public string Icon { get; set; }
// public uint Price { get; set; }
// public uint TimeInMinutes { get; set; }
// public ActiveEnum Active { get; set; }