using FluentValidation;
using Message.Commands;

namespace Message.Validators
{
    public class AddCourseValidator : AbstractValidator<AddCourseCommand>
    {
        public AddCourseValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("نام باید وارد شود")
                .Length(1, 50).WithMessage("اندازه نام وارد شده باید بین ۱ تا ۵۰ کاراکتر باشد");

            RuleFor(c => c.Unit)
                .NotEmpty().WithMessage("واحد باید وارد شود")
                .InclusiveBetween(0, 3).WithMessage("واحد باید بین ٠ تا ٣ باشد");
        }
    }
}
