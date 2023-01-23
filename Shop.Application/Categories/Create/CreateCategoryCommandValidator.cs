using Common.Application.Validation;
using FluentValidation;
using Shop.Application.Categories.Create;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(r => r.Title)
            .NotNull()
            .NotEmpty().WithMessage(ValidationMessages.required("عنوان"));

        RuleFor(r => r.Slug)
            .NotNull()
        .NotEmpty().WithMessage(ValidationMessages.required("slug"));

    }
}