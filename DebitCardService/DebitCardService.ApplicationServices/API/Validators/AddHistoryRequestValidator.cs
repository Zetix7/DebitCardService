using DebitCardService.ApplicationServices.API.Domain;
using FluentValidation;

namespace DebitCardService.ApplicationServices.API.Validators;

public class AddHistoryRequestValidator : AbstractValidator<AddHistoryRequest>
{
    public AddHistoryRequestValidator()
    {
        RuleFor(x => x.Sender).Length(3, 51).WithMessage("WRONG_RANGE");
        RuleFor(x => x.SenderAccountNumber).Length(26).WithMessage("WRONG_LENGTH");
        RuleFor(x => x.Recipient).Length(3, 51).WithMessage("WRONG_RANGE");
        RuleFor(x => x.RecipientAccountNumber).Length(26).WithMessage("WRONG_LENGTH");
        RuleFor(x => x.Amount).GreaterThan(0).WithMessage("TOO_LOW_VALUE");
        RuleFor(x => x.Title).Length(1, 100).WithMessage("WRONG_RANGE");
    }
}
