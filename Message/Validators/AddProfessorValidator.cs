using FluentValidation;
using Message.Commands;
using Message.Validators.ValidationMethods;

namespace Message.Validators
{
    public class AddProfessorValidator : AbstractValidator<AddProfessorCommand>
    {
        public AddProfessorValidator()
        {
            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("نام باید وارد شود")
                .Length(1, 50).WithMessage("اندازه نام وارد شده باید بین ۰ تا ۵۰ باشد");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("نام خانوادگی باید وارد شود")
                .Length(1, 50).WithMessage("اندازه نام خانوادگی وارد شده باید بین ۰ تا ۵۰ باشد");

            RuleFor(p => p.NationalCode)
                .NotEmpty().WithMessage("کد ملی باید وارد شود")
                .Length(10).WithMessage("کد ملی باید ١٠ رقم باشد");

            RuleFor(p => p.Birthday)
                .Must(DateValidation.ValidateDateOfProfessor).WithMessage("سن باید وارد شود و بین ٢٥ تا ١٠٠ باشد");

            RuleFor(p => p.SemesterId)
                .NotEmpty().WithMessage("شناسه باید وارد شود");

            RuleForEach(p => p.CoursesId)
                .NotEmpty().WithMessage("شناسه باید وارد شود");

            RuleForEach(p => p.Salaries)
                .NotEmpty().WithMessage("دستمزد باید وارد شود")
                .Must(p => p > 0).WithMessage("دستمزد باید بیشتر از ۰ باشد");
        }
    }
}
