using DebitCardService.ApplicationServices.API.Domain;
using FluentValidation;

namespace DebitCardService.ApplicationServices.API.Validators;

public class UpdateDebitCardRequestValidation : AbstractValidator<UpdateDebitCardRequest>
{
    public UpdateDebitCardRequestValidation()
    {
        RuleFor(x => x.PinCode).InclusiveBetween(1000, 9999).WithMessage("WRONG_RANGE");
        RuleFor(x => x.CashWithdrawalLimit).GreaterThanOrEqualTo(0).WithMessage("TOO_SMALL_VALUE");
        RuleFor(x => x.PayPassLimit).GreaterThanOrEqualTo(0).WithMessage("TOO_SMALL_VALUE");
        RuleFor(x => x.PhoneLimit).GreaterThanOrEqualTo(0).WithMessage("TOO_SMALL_VALUE");
    }
}
