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
            CreateMap<UserDto, User>();
        }
    }
}
