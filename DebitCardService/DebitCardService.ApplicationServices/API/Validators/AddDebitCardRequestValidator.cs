using DebitCardService.ApplicationServices.API.Domain;
using FluentValidation;

namespace DebitCardService.ApplicationServices.API.Validators;

public class AddDebitCardRequestValidator : AbstractValidator<AddDebitCardRequest>
{
    public AddDebitCardRequestValidator()
    {
        RuleFor(x => x.AccountNumber).Length(26).WithMessage("WRONG_LENGTH");
        RuleFor(x => x.Amount).GreaterThanOrEqualTo(0).WithMessage("TOO_SMALL_VALUE");
        RuleFor(x => x.CardNumber).Length(16).WithMessage("WRONG_LENGTH");
        RuleFor(x => x.ExpirityDate)
            .Equal(new DateTime(DateTime.Now.AddYears(3).Year,DateTime.Now.AddMonths(1).Month,1))
            .WithMessage("WRONG_DATE_FIRST_DAY_IN_NEXT_MONTH_AFTER_3_YEARS_TIME_00:00:00");
        RuleFor(x => x.Cvv2Code).InclusiveBetween(100, 999).WithMessage("WRONG_RANGE");
        RuleFor(x => x.PinCode).InclusiveBetween(1000, 9999).WithMessage("WRONG_RANGE");
        RuleFor(x => x.CardHolder).Length(1,51).WithMessage("WRONG_LENGTH");
        RuleFor(x => x.CashWithdrawalLimit).GreaterThanOrEqualTo(0).WithMessage("TOO_SMALL_VALUE");
        RuleFor(x => x.PayPassLimit).GreaterThanOrEqualTo(0).WithMessage("TOO_SMALL_VALUE");
        RuleFor(x => x.PhoneLimit).GreaterThanOrEqualTo(0).WithMessage("TOO_SMALL_VALUE");
    }
}
