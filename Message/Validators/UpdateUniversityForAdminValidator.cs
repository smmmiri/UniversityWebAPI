using FluentValidation;
using Message.Commands;

namespace Message.Validators
{
    public class UpdateUniversityForAdminValidator : AbstractValidator<UpdateUniversityForAdminCommand>
    {
        public UpdateUniversityForAdminValidator()
        {
            RuleFor(u => u.UniversityId)
                .NotEmpty().WithMessage("شناسه باید وارد شود");

            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("نام باید وارد شود")
                .Length(1, 50).WithMessage("اندازه نام وارد شده باید بین ۱ تا ۵۰ کاراکتر باشد");

            RuleFor(u => u.Address)
                .NotEmpty().WithMessage("نشانی باید وارد شود");

            RuleFor(u => u.EstablishedYear)
                .NotEmpty().WithMessage("سال تاسیس باید وارد شود")
                .LessThanOrEqualTo((uint)DateTime.Now.Year);

            RuleFor(u => u.Budget)
                .NotEmpty().WithMessage("بودجه باید وارد شود")
                .GreaterThan(0M).WithMessage("مقدار بودجه باید بیشتر از ٠ باشد");
        }
    }
}
