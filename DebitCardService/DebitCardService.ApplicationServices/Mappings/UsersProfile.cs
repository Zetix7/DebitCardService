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
            .ForMember(x=>x.LastName, y=>y.MapFrom(z=>z.LastName));

        CreateMap<AddUserRequest, DataAccess.Entities.User>()
            .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
            .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
            .ForMember(x => x.Login, y => y.MapFrom(z => z.Login))
            .ForMember(x => x.Password, y => y.MapFrom(z => z.Password));

        CreateMap<UpdateUserNameByIdRequest, DataAccess.Entities.User>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
            .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName));
    }
}
