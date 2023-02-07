using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Roles.Edit
{
    public class EditRolePermissionCommandValidator : AbstractValidator<EditRolePermissionCommand>
    {
        public EditRolePermissionCommandValidator()
        {
            RuleFor(r => r.Title)
                .NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
        }
    }
}
