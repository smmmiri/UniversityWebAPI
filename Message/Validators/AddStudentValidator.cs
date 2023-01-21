using FluentValidation;
using Message.Commands;
using Message.Validators.ValidationMethods;

namespace Message.Validators
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        public AddStudentValidator()
        {
            RuleFor(s => s.FirstName)
                .NotEmpty().WithMessage("نام باید وارد شود")
                .Length(1, 50).WithMessage("اندازه نام وارد شده باید بین ۰ تا ۵۰ باشد");

            RuleFor(s => s.LastName)
                .NotEmpty().WithMessage("نام خانوادگی باید وارد شود")
                .Length(1, 50).WithMessage("اندازه نام خانوادگی وارد شده باید بین ۰ تا ۵۰ باشد");

            RuleFor(s => s.NationalCode)
                .NotEmpty().WithMessage("کد ملی باید وارد شود")
                .Length(10).WithMessage("کد ملی باید ١٠ رقم باشد");

            RuleFor(s => s.Birthday)
                .Must(DateValidation.ValidateDateOfStudent).WithMessage("سن باید وارد شود و بین ۱۸ تا ١٠٠ باشد");

            RuleFor(s => s.StudentNumber)
                .NotEmpty().WithMessage("شماره دانشجویی باید وارد شود");

            RuleForEach(s => s.ProfessorRelationIds)
                .NotEmpty().WithMessage("شناسه باید وارد شود");
        }
    }
}
