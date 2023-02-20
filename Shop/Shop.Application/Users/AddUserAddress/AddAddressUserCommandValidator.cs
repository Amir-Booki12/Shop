using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Users.AddUserAddress
{
    public class AddAddressUserCommandValidator:AbstractValidator<AddAddressUserCommand>
    {
        public AddAddressUserCommandValidator()
        {
            RuleFor(r => r.Shire)
                .NotEmpty().WithMessage(ValidationMessages.required("استان"));

            RuleFor(r => r.City)
               .NotEmpty().WithMessage(ValidationMessages.required("شهر"));

            RuleFor(r => r.Name)
               .NotEmpty().WithMessage(ValidationMessages.required("نام"));

            RuleFor(r => r.Family)
               .NotEmpty().WithMessage(ValidationMessages.required("نام خانوادگی"));

            RuleFor(r => r.NationalCode)
               .NotEmpty().WithMessage(ValidationMessages.required("کدملی"))
               .ValidNationalId();

            RuleFor(r => r.PostAdress)
               .NotEmpty().WithMessage(ValidationMessages.required("آدرس پستی"));

            RuleFor(r => r.PostalCode)
               .NotEmpty().WithMessage(ValidationMessages.required("کد پستی"));
        }
    }
}
