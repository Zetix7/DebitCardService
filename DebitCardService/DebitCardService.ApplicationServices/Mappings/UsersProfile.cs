using AutoMapper;
using DebitCardService.ApplicationServices.API.Domain;
using DebitCardService.ApplicationServices.API.Domain.Models;

namespace DebitCardService.ApplicationServices.Mappings;

public class UsersProfile : Profile
{
    public UsersProfile()
    {
        CreateMap<DataAccess.Entities.User, User>()
            .ForMember(x=>x.Id, y=>y.MapFrom(z=>z.Id))
            .ForMember(x=>x.FirstName, y=>y.MapFrom(z=>z.FirstName))
            .ForMember(x=>x.LastName, y=>y.MapFrom(z=>z.LastName))
            .ForMember(x=>x.AccessLevel, y=>y.MapFrom(z=>z.AccessLevel))
            .ForMember(x=>x.Login, y=>y.MapFrom(z=>z.Login))
            .ForMember(x=>x.IsActive, y=>y.MapFrom(z=>z.IsActive))
            .ForMember(x=>x.AmountsOnCards, y=>y.MapFrom(z=>z.DebitCards != null ? z.DebitCards.Select(x=>x.Amount) : new List<decimal>()));

        CreateMap<AddUserRequest, DataAccess.Entities.User>()
            .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
            .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
            .ForMember(x => x.AccessLevel, y => y.MapFrom(z => z.AccessLevel))
            .ForMember(x => x.Login, y => y.MapFrom(z => z.Login))
            .ForMember(x => x.HashedPassword, y => y.MapFrom(z => z.HashedPassword))
            .ForMember(x => x.IsActive, y => y.MapFrom(z => z.IsActive));

        CreateMap<UpdateUserByIdRequest, DataAccess.Entities.User>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
            .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
            .ForMember(x => x.AccessLevel, y => y.MapFrom(z => z.AccessLevel))
            .ForMember(x => x.HashedPassword, y => y.MapFrom(z => z.Password))
            .ForMember(x => x.IsActive, y => y.MapFrom(z => z.IsActive));
    }
}
