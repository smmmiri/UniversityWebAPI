using FluentValidation;
using Message.Commands;

namespace Message.Validators
{
    public class AddProfessorToCourseValidator : AbstractValidator<AddProfessorToCourseCommand>
    {
        public AddProfessorToCourseValidator()
        {
            RuleFor(c => c.CourseId)
                .NotEmpty().WithMessage("شناسه درس باید وارد شود");

            RuleFor(p => p.ProfessorId)
                .NotEmpty().WithMessage("شناسه استاد باید وارد شود");

            RuleFor(p => p.SemesterId)
                .NotEmpty().WithMessage("شناسه ترم باید وارد شود");

            RuleFor(p => p.Salary)
                .NotEmpty().WithMessage("دستمزد باید وارد شود")
                .Must(p => p > 0).WithMessage("دستمزد باید بیشتر از ۰ باشد");
        }
    }
}
