using FluentValidation;

namespace Shop.Application.Orders.IncreaseItemCount
{
    public class IncreaseOrderCountCommandValidator:AbstractValidator<IncreaseOrderCountCommand>
    {
        public IncreaseOrderCountCommandValidator()
        {
            RuleFor(f => f.Count)
               .GreaterThanOrEqualTo(1).WithMessage("تعداد باید بیشتر از 0 باشد");
        }
    }


}
