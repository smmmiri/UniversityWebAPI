using FluentValidation;
using Message.Commands;

namespace Message.Validators
{
    public class GrantValidator : AbstractValidator<GrantCommand>
    {
        public GrantValidator()
        {
            RuleFor(a => a.UserId)
                .NotEmpty().WithMessage("شناسه کاربری باید وارد شود");

            RuleFor(a => a.RoleId)
                .NotEmpty().WithMessage("شناسه نقش باید وارد شود");
        }
    }
}
