using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Users.ShargWallet
{
    public class ShargeWalletCommandValidator:AbstractValidator<ShargeWalletCommand>
    {
        public ShargeWalletCommandValidator()
        {
            RuleFor(r => r.Description)
                .NotEmpty().WithMessage(ValidationMessages.required("توضیحات"));

            RuleFor(r => r.Price)
                .GreaterThanOrEqualTo(1000);

                
                
        }
    }
}
