using Common.Application.Validation.FluentValidations;
using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.SiteEntities.Sliders.Create
{
    public class CreateSliderCommandValidator:AbstractValidator<CreateSliderCommand>
    {
        public CreateSliderCommandValidator()
        {
            RuleFor(r => r.ImageFile)
               .JustImageFile()
               .NotNull().WithMessage(ValidationMessages.required("عکس"));

            RuleFor(r => r.Link)
                .NotNull()
                .NotEmpty().WithMessage(ValidationMessages.required("لینک"));

            RuleFor(r => r.Title)
               .NotNull()
               .NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
        }
    }
}
