using AutoMapper;
using DebitCardService.ApplicationServices.API.Domain;
using DebitCardService.ApplicationServices.API.Domain.Models;

namespace DebitCardService.ApplicationServices.Mappings;

public class DebitCardsProfile : Profile
{
    public DebitCardsProfile()
    {
        CreateMap<DataAccess.Entities.DebitCard, DebitCard>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.AccountNumber, y => y.MapFrom(z => z.AccountNumber))
            .ForMember(x => x.Amount, y => y.MapFrom(z => z.Amount))
            .ForMember(x => x.CardNumber, y => y.MapFrom(z => z.CardNumber))
            .ForMember(x => x.ExpirityDate, y => y.MapFrom(z => z.ExpirityDate))
            .ForMember(x => x.CardHolder, y => y.MapFrom(z => z.CardHolder))
            .ForMember(x => x.IsActive, y => y.MapFrom(z => z.IsActive))
            .ForMember(x => x.AmountsOfTransaction, y => y.MapFrom(z => z.History != null ? z.History.Select(x=>x.Amount) : new List<decimal>()));

        CreateMap<AddDebitCardRequest, DataAccess.Entities.DebitCard>()
            .ForMember(x => x.AccountNumber, y => y.MapFrom(z => z.AccountNumber))
            .ForMember(x => x.Amount, y => y.MapFrom(z => z.Amount))
            .ForMember(x => x.CardNumber, y => y.MapFrom(z => z.CardNumber))
            .ForMember(x => x.ExpirityDate, y => y.MapFrom(z => z.ExpirityDate))
            .ForMember(x => x.Cvv2Code, y => y.MapFrom(z => z.Cvv2Code))
            .ForMember(x => x.PinCode, y => y.MapFrom(z => z.PinCode))
            .ForMember(x => x.CardHolder, y => y.MapFrom(z => z.CardHolder))
            .ForMember(x => x.IsActive, y => y.MapFrom(z => z.IsActive))
            .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId));

        CreateMap<UpdateDebitCardActivityRequest, DataAccess.Entities.DebitCard>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.IsActive, y => y.MapFrom(z => z.IsActive));
    }
}
