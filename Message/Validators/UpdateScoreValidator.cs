using FluentValidation;
using Message.Commands;

namespace Message.Validators
{
    public class UpdateScoreValidator : AbstractValidator<UpdateScoreCommand>
    {
        public UpdateScoreValidator()
        {
            RuleFor(s => s.CourseId)
                .NotEmpty().WithMessage("شناسه باید وارد شود");

            RuleFor(s => s.Score)
                .NotEmpty().WithMessage("شناسه باید وارد شود")
                .InclusiveBetween(0, 20).WithMessage("نمره باید بین ٠ تا ٢٠ باشد");

            RuleFor(s => s.StudentId)
                .NotEmpty().WithMessage("شناسه باید وارد شود");

            RuleFor(s => s.SemesterId)
                .NotEmpty().WithMessage("شناسه باید وارد شود");
        }
    }
}
