using Application.DTOs;
using FluentValidation;

namespace Application.Validators;

public class AppointmentRequestDtoValidator : AbstractValidator<AppointmentRequestDto>
{
    public AppointmentRequestDtoValidator()
    {
        RuleFor(x => x.EstablishmentId)
            .NotEmpty()
            .WithMessage("BarberShopId is required");
    }
}