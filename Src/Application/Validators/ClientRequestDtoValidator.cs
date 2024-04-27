using Application.DTOs;
using FluentValidation;

namespace Application.Validators;

public class ClientRequestDtoValidator : AbstractValidator<ClientRequestDto>
{
    public ClientRequestDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .MaximumLength(100)
            .WithMessage("Name must not exceed 100 characters");
        RuleFor(x => x.TelephoneNumber)
            .NotEmpty()
            .WithMessage("TelephoneNumber is required")
            .MaximumLength(20)
            .WithMessage("TelephoneNumber must not exceed 20 characters");
    }
    
}