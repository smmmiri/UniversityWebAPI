using FluentValidation;
using Message.Commands;

namespace Message.Validators
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidator()
        {
            RuleFor(u => u.Id)
                .NotEmpty().WithMessage("شناسه کاربر باید وارد شود");

            RuleFor(u => u.FirstName)
                .NotEmpty().WithMessage("نام باید وارد شود");

            RuleFor(u => u.LastName)
                .NotEmpty().WithMessage("نام خانوادگی باید وارد شود");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("ایمیل باید وارد شود")
                .EmailAddress().WithMessage("ایمیل باید معتبر باشد");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("رمز عبور باید وارد شود")
                .Length(8, 20).WithMessage("طول رمز عبور باید بین ٨ تا ٢٠ باشد");
        }
    }
}
