using FluentValidation;
using Message.Commands;

namespace Message.Validators
{
    public class UpdateRoleValidator : AbstractValidator<UpdateRoleCommand>
    {
        public UpdateRoleValidator()
        {
            RuleFor(r => r.Id)
                .NotEmpty().WithMessage("شناسه نقش باید وارد شود");

            RuleFor(r => r.Name)
                .NotEmpty().WithMessage("نام نقش باید وارد شود")
                .Matches(@"[a-zA-Z]").WithMessage("فقط از حروف الفبا باید استفاده شود");

            RuleFor(r => r.NormalizedName)
                .NotEmpty().WithMessage("نام نقش باید وارد شود")
                .Matches(@"[A-Z]").WithMessage("فقط از حروف الفبا باید استفاده شود و تمام حروف بزرگ باشند")
                .Equal(r => r.Name.ToUpper()).WithMessage("مقدار وارد شده باید با نام برابر باشد");
        }
    }
}
