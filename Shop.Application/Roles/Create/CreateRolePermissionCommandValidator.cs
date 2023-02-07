using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Roles.Create
{
    public class CreateRolePermissionCommandValidator : AbstractValidator<CreateRolePermissionCommand>
    {
        public CreateRolePermissionCommandValidator()
        {
            RuleFor(r => r.Title)
                .NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
        }
    }
}
