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
        RuleFor(x => x.Rating)
            .NotEmpty()
            .WithMessage("Rating is required");
        RuleFor(x => x.HasWifi)
            .NotEmpty()
            .WithMessage("HasWifi is required");
        RuleFor(x => x.AccessibleForDisabledPeople)
            .NotEmpty()
            .WithMessage("AccessibleForDisabledPeople is required");
        RuleFor(x => x.HasParkPlace)
            .NotNull()
            .WithMessage("HasParkPlace is required");
        RuleFor(x => x.AcceptGender)
            .NotEmpty()
            .WithMessage("AcceptGender is required");
        RuleFor(x => x.AcceptCreditCard)
            .NotEmpty()
            .WithMessage("AcceptCreditCard is required");
        RuleFor(x => x.AcceptPix)
            .NotEmpty()
            .WithMessage("AcceptPix is required");
        RuleFor(x => x.Active)
            .NotEmpty()
            .WithMessage("Active is required");
    }

}