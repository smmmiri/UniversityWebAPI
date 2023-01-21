using FluentValidation;
using Message.Commands;

namespace Message.Validators
{
    public class AddScoreValidator : AbstractValidator<AddScoreCommand>
    {
        public AddScoreValidator()
        {
            RuleFor(s => s.CourseId)
                .NotEmpty().WithMessage("شناسه باید وارد شود");

            RuleFor(score => score.Score)
                .NotEmpty().WithMessage("شناسه باید وارد شود")
                .InclusiveBetween(0, 20).WithMessage("نمره باید بین ٠ تا ٢٠ باشد");

            RuleFor(s => s.StudentId)
                .NotEmpty().WithMessage("شناسه باید وارد شود");

            RuleFor(s => s.SemesterId)
                .NotEmpty().WithMessage("شناسه باید وارد شود");
        }
    }
}
