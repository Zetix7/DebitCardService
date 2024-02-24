using DebitCardService.ApplicationServices.API.Domain;
using FluentValidation;

namespace DebitCardService.ApplicationServices.API.Validators;

public class UpdateUserNameByIdValidator : AbstractValidator<UpdateUserNameByIdRequest>
{
    public UpdateUserNameByIdValidator()
    {
        RuleFor(x => x.FirstName).Length(1, 20).WithMessage("WRONG_LENGTH");
        RuleFor(x => x.LastName).Length(1, 30).WithMessage("WRONG_LENGTH");
        RuleFor(x => x.Password).MinimumLength(10).WithMessage("WRONG_LENGTH");
    }
}
