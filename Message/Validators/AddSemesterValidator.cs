using FluentValidation;
using Message.Commands;

namespace Message.Validators
{
    public class AddSemesterValidator : AbstractValidator<AddSemesterCommand>
    {
        public AddSemesterValidator()
        {
            RuleFor(s => s.SemesterNumber)
                .NotEmpty().WithMessage("شماره ترم باید وارد شود");

            RuleFor(s => s.SemesterType)
                .NotNull().WithMessage("نوع ترم باید وارد شود")
                .IsInEnum().WithMessage("نوع وارد شده باید معتبر باشد");

            RuleFor(s => s.SemesterYear)
                .NotEmpty().WithMessage("سال ترم باید وارد شود");
        }
    }
}
