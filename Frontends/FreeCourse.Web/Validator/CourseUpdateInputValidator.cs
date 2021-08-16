using System;
using FluentValidation;
using FreeCourse.Web.Models.Catalog;

namespace FreeCourse.Web.Validator
{
    public class CourseUpdateInputValidator : AbstractValidator<CourseUpdateInput>
    {
        public CourseUpdateInputValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name field can't be blank!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description field can't be blank!");
            RuleFor(x => x.Feature.Duration).InclusiveBetween(1, int.MaxValue).WithMessage("Duration field can't be blank!");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price field can't be blank!").ScalePrecision(2, 6).WithMessage("Wrong format type for Price field!");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Please choose a category!");
        }
    }
}
