using DebitCardService.ApplicationServices.API.Domain;
using FluentValidation;

namespace DebitCardService.ApplicationServices.API.Validators;

public class AddUserRequestValidator :AbstractValidator<AddUserRequest>
{
    public AddUserRequestValidator()
    {
        RuleFor(x => x.FirstName).Length(1, 20).WithMessage("WRONG_LENGTH");
        RuleFor(x => x.LastName).Length(1, 30).WithMessage("WRONG_LENGTH");
        RuleFor(x => x.Login).Length(8, 15).WithMessage("WRONG_LENGTH");
        RuleFor(x => x.Password).Length(10, 50).WithMessage("WRONG_LENGTH");
    }
}
