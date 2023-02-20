using FluentValidation;
using Common.Application.Validation.FluentValidations;

namespace Shop.Application.Users.Edit
{
    public class EditUserCommandValidator:AbstractValidator<EditUserCommand>
    {
        public EditUserCommandValidator()
        {
            RuleFor(r => r.AvatarFile)
             .JustValidFile();

            RuleFor(r => r.Email)
                .EmailAddress().WithMessage("ایمیل معتبر نیست");

            RuleFor(r => r.Password)
                .MinimumLength(4);
        }
    }
}
