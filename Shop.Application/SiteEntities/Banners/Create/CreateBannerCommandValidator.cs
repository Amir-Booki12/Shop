using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.SiteEntities.Banners.Create
{
    public class CreateBannerCommandValidator:AbstractValidator<CreateBannerCommand>
    {
        public CreateBannerCommandValidator()
        {
            RuleFor(r => r.ImageFile)
                .JustImageFile()
                .NotNull().WithMessage(ValidationMessages.required("عکس"));

            RuleFor(r => r.Link)
                .NotNull()
                .NotEmpty().WithMessage(ValidationMessages.required("لینک"));
                
        }
    }
}
