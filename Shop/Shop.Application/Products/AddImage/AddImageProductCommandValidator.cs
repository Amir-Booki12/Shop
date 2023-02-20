using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Products.AddImage
{
    internal class AddImageProductCommandValidator:AbstractValidator<AddImageProductCommand>
    {
        public AddImageProductCommandValidator()
        {
            RuleFor(r => r.ImageFile)
                .NotEmpty().WithMessage(ValidationMessages.required("عکس"))
                .JustImageFile();

            RuleFor(r => r.Sequence)
                .GreaterThanOrEqualTo(0);
        }
    }
}
