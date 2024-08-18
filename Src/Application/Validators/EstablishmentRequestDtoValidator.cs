using Application.DTOs;
using FluentValidation;

namespace Application.Validators;

public class EstablishmentRequestDtoValidator : AbstractValidator<EstablishmentRequestDto>
{
    public EstablishmentRequestDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required");
        RuleFor(x => x.Cover)
            .NotEmpty()
            .WithMessage("Cover is required");
        RuleFor(x => x.Permalink)
            .NotEmpty()
            .WithMessage("Permalink is required");
        RuleFor(x => x.Address)
            .NotEmpty()
            .WithMessage("Address is required");
        RuleFor(x => x.TelephoneNumber)
            .NotEmpty()
            .WithMessage("TelephoneNumber is required");
    }

}