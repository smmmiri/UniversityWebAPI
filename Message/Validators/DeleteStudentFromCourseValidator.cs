using FluentValidation;
using Message.Commands;

namespace Message.Validators
{
    public class DeleteStudentFromCourseValidator : AbstractValidator<DeleteStudentFromCourseCommand>
    {
        public DeleteStudentFromCourseValidator()
        {
            RuleFor(c => c.ProfessorRelationId)
                .NotEmpty().WithMessage("شناسه جدول رابطه باید وارد شود");

            RuleFor(s => s.StudentId)
                .NotEmpty().WithMessage("شناسه دانشجو باید وارد شود");
        }
    }
}
