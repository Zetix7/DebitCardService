using AutoMapper;
using DebitCardService.ApplicationServices.API.Domain;
using DebitCardService.ApplicationServices.API.Domain.Models;

namespace DebitCardService.ApplicationServices.Mappings;

public class HistoryProfile : Profile
{
    public HistoryProfile()
    {
        CreateMap<DataAccess.Entities.History, History>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.DateOfOperation, y => y.MapFrom(z => z.DateOfOperation))
            .ForMember(x => x.Sender, y => y.MapFrom(z => z.Sender))
            .ForMember(x => x.SenderAccountNumber, y => y.MapFrom(z => z.SenderAccountNumber))
            .ForMember(x => x.Recipient, y => y.MapFrom(z => z.Recipient))
            .ForMember(x => x.RecipientAccountNumber, y => y.MapFrom(z => z.RecipientAccountNumber))
            .ForMember(x => x.Amount, y => y.MapFrom(z => z.Amount))
            .ForMember(x => x.Title, y => y.MapFrom(z => z.Title));

        CreateMap<AddHistoryRequest, DataAccess.Entities.History>()
            .ForMember(x => x.DebitCardId, y => y.MapFrom(z => z.DebitCardId))
            .ForMember(x => x.DateOfOperation, y => y.MapFrom(z => z.DateOfOperation))
            .ForMember(x => x.Sender, y => y.MapFrom(z => z.Sender))
            .ForMember(x => x.SenderAccountNumber, y => y.MapFrom(z => z.SenderAccountNumber))
            .ForMember(x => x.Recipient, y => y.MapFrom(z => z.Recipient))
            .ForMember(x => x.RecipientAccountNumber, y => y.MapFrom(z => z.RecipientAccountNumber))
            .ForMember(x => x.Amount, y => y.MapFrom(z => z.Amount))
            .ForMember(x => x.Title, y => y.MapFrom(z => z.Title));
    }
}
