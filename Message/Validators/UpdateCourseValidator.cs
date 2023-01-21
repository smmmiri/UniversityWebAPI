using FluentValidation;
using Message.Commands;

namespace Message.Validators
{
    public class UpdateCourseValidator : AbstractValidator<UpdateCourseCommand>
    {
        public UpdateCourseValidator()
        {
            RuleFor(s => s.Name)
                .NotEmpty().WithMessage("نام باید وارد شود")
                .Length(1, 50).WithMessage("اندازه نام وارد شده باید بین ۱ تا ۵۰ کاراکتر باشد");

            RuleFor(s => s.Unit)
                .NotEmpty().WithMessage("واحد باید وارد شود")
                .InclusiveBetween(0, 3).WithMessage("واحد باید بین ٠ تا ٣ باشد");

            RuleFor(s => s.CourseId)
                .NotEmpty().WithMessage("شناسه باید وارد شود");
        }
    }
}
