using FluentValidation;
using Message.Commands;

namespace Message.Validators
{
    public class AddUserValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserValidator()
        {
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

            RuleFor(u => u.ConfirmPassword)
                .NotEmpty().WithMessage("تایید رمز عبور باید وارد شود")
                .Length(8, 20).WithMessage("طول تایید رمز عبور باید بین ٨ تا ٢٠ باشد")
                .Equal(u => u.Password).WithMessage("مقدار وارد شده باید با رمز عبور یکی باشد");

            RuleFor(u => u.UniversityId)
                .NotEmpty().WithMessage("شناسه دانشگاه باید وارد شود");
        }
    }
}
