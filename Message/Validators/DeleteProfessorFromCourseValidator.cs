using FluentValidation;
using Message.Commands;

namespace Message.Validators
{
    public class DeleteProfessorFromCourseValidator : AbstractValidator<DeleteProfessorFromCourseCommand>
    {
        public DeleteProfessorFromCourseValidator()
        {
            RuleFor(c => c.CourseId)
                .NotEmpty().WithMessage("شناسه درس باید وارد شود");

            RuleFor(p => p.ProfessorId)
                .NotEmpty().WithMessage("شناسه استاد باید وارد شود");

            RuleFor(p => p.SemesterId)
                .NotEmpty().WithMessage("شناسه ترم باید وارد شود");
        }
    }
}
