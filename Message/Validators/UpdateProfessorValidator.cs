using FluentValidation;
using Message.Commands;
using Message.Validators.ValidationMethods;

namespace Message.Validators
{
    public class UpdateProfessorValidator : AbstractValidator<UpdateProfessorCommand>
    {
        public UpdateProfessorValidator()
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

            RuleFor(p => p.ProfessorId)
                .NotEmpty().WithMessage("شناسه باید وارد شود");
        }
    }
}
