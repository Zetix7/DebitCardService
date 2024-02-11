using DebitCardService.ApplicationServices.API.Domain;
using FluentValidation;

namespace DebitCardService.ApplicationServices.API.Validators;

public class AddUserRequestValidator :AbstractValidator<AddUserRequest>
{
    public AddUserRequestValidator()
    {
        RuleFor(x => x.FirstName).Length(1, 20);
        RuleFor(x => x.LastName).Length(1, 30);
        RuleFor(x => x.Login).Length(8, 15);
        RuleFor(x => x.Password).Length(10, 50);
    }
}
