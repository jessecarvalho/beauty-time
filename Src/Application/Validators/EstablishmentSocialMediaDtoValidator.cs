using Application.DTOs;
using FluentValidation;

namespace Application.Validators;

public class EstablishmentSocialMediaDtoValidator : AbstractValidator<EstablishmentSocialMediaRequestDto>
{
    public EstablishmentSocialMediaDtoValidator()
    {
        RuleFor(x => x.SocialMedia)
            .NotEmpty()
            .WithMessage("SocialMedia is required");
        RuleFor(x => x.EstablishmentId)
            .NotEmpty()
            .WithMessage("BarberShopId is required");
        RuleFor(x => x.Link)
            .NotEmpty()
            .WithMessage("Link is required");
    }
    
}
