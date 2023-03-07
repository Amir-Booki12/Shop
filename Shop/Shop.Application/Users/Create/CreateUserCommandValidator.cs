using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Users.Create
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(r => r.PhoneNumber)
                .NotEmpty().WithMessage(ValidationMessages.required("شماره تلفن"))
                .NotNull()
                .EmailAddress();


            RuleFor(r => r.Email)
                .NotEmpty().WithMessage(ValidationMessages.required("رمز عبور"))
                .NotNull()
                .MinimumLength(4);
        }
    }
}
