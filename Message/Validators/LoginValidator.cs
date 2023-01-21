using FluentValidation;
using Message.Commands;

namespace Message.Validators
{
    public class LoginValidator : AbstractValidator<LoginCommand>
    {
        public LoginValidator()
        {
            RuleFor(u => u.Email)          
                .NotEmpty().WithMessage("ایمیل باید وارد شود");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("رمز عبور باید وارد شود");
        }
    }
}
