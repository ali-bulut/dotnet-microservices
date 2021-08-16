using System;
using FluentValidation;
using FreeCourse.Web.Models.Discount;

namespace FreeCourse.Web.Validator
{
    public class DiscountApplyInputValidator : AbstractValidator<DiscountApplyInput>
    {
        public DiscountApplyInputValidator()
        {
            RuleFor(x => x.Code).NotEmpty().WithMessage("Discount code can't be blank!");
        }
    }
}
