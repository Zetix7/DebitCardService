using DebitCardService.ApplicationServices.API.Domain;
using FluentValidation;

namespace DebitCardService.ApplicationServices.API.Validators;

public class GetExchangeRatesValidator : AbstractValidator<GetExchangeRatesRequest>
{
    public GetExchangeRatesValidator()
    {
        RuleFor(x => x.Currency).Length(3);
    }
}
