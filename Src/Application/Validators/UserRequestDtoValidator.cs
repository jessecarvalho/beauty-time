using Application.DTOs.User;
using FluentValidation;

namespace Application.Validators;

public class UserRequestDtoValidator : AbstractValidator<UserRequestDto>
{

    public UserRequestDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .MaximumLength(255)
            .WithMessage("Name must not exceed 255 characters");
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required")
            .MaximumLength(255)
            .WithMessage("Email must not exceed 255 characters");
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required")
            .MaximumLength(255)
            .WithMessage("Password must not exceed 255 characters");
        RuleFor(x => x.TelephoneNumber)
            .NotEmpty()
            .WithMessage("Telephone number is required")
            .MaximumLength(255)
            .WithMessage("Telephone must not exceed 255 characters");

    }
    
}