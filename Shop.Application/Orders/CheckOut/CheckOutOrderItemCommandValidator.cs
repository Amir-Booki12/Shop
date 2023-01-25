using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Orders.CheckOut
{
    public class CheckOutOrderItemCommandValidator:AbstractValidator<CheckOutOrderItemCommand>
    {
        public CheckOutOrderItemCommandValidator()
        {
            RuleFor(r => r.Name)
                .NotNull()
                .NotEmpty().WithMessage(ValidationMessages.required("نام"));

            RuleFor(r => r.Family)
               .NotNull()
               .NotEmpty().WithMessage(ValidationMessages.required("نام خانوادگی"));


            RuleFor(r => r.City)
               .NotNull()
               .NotEmpty().WithMessage(ValidationMessages.required("شهر"));


            RuleFor(r => r.Shire)
               .NotNull()
               .NotEmpty().WithMessage(ValidationMessages.required("استان"));


            RuleFor(r => r.PostAdress)
               .NotNull()
               .NotEmpty().WithMessage(ValidationMessages.required("آدرس پستی"));

            RuleFor(r => r.PostalCode)
               .NotNull()
               .NotEmpty().WithMessage(ValidationMessages.required("کد پستی"));

            RuleFor(r => r.PostAdress)
               .NotNull()
               .NotEmpty().WithMessage(ValidationMessages.required("آدرس پستی"));


            RuleFor(r => r.NationalCode)
               .NotNull()
               .NotEmpty().WithMessage(ValidationMessages.required(" کدملی"))
               .MaximumLength(11).WithMessage("کدملی معتبر نیست")
               .MinimumLength(11).WithMessage("کدملی معتبر نیست")
               .ValidNationalId();

            RuleFor(r => r.PhoneNumber)
               .NotNull()
               .NotEmpty().WithMessage(ValidationMessages.required(" شماره تلفن"))
               .MaximumLength(11).WithMessage("شماره تلفن معتبر نیست")
               .MinimumLength(11).WithMessage("شماره تلفن معتبر نیست");
        }
    }
}
