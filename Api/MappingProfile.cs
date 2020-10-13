using Api.DTO;
using Api.Models;
using AutoMapper;

namespace Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain ---> Dto
            CreateMap<User, UserDto>();
            CreateMap<UserType, UserTypeDto>();
            CreateMap<UserTitle, UserTitleDto>();
            CreateMap<SearchUsersParams, SearchUserParamsDto>();
            CreateMap(typeof(Page<>), typeof(PageDto<>));

            // Dto ---> Domain
            CreateMap<SearchUserParamsDto, SearchUsersParams>();
            CreateMap<UserDto, User>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Surname, y => y.MapFrom(z => z.Surname))
                .ForMember(x => x.BirthDate, y => y.MapFrom(z => z.BirthDate))
                .ForMember(x => x.UserTypeId, y => y.MapFrom(z => z.UserTypeId))
                .ForMember(x => x.UserTitleId, y => y.MapFrom(z => z.UserTitleId))
                .ForMember(x => x.EmailAddress, y => y.MapFrom(z => z.EmailAddress))
                .ForMember(x => x.IsActive, y => y.MapFrom(z => z.IsActive))
                .ForAllOtherMembers(x => x.Ignore());
        }
    }
}
