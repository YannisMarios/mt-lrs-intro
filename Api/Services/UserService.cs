using Api.DTO;
using Api.Models;
using Api.Repositories.Interfaces;
using Api.Services.Interfaces;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper)); 
        }

        public async Task<PageDto<UserDto>> GetUsers(SearchUserParamsDto searchParamsDTO)
        {
            if (searchParamsDTO == null)
            {
                throw new ArgumentNullException(nameof(searchParamsDTO));
            }
            var searchParams = _mapper.Map<SearchUsersParams>(searchParamsDTO);
            var usersPage = await _userRepository.GetUsers(searchParams);
            return _mapper.Map<PageDto<UserDto>>(usersPage);
        }

        public async Task<UserDto> GetUser(int userId)
        {
            if(userId <= 0)
            {
                throw new ArgumentException(nameof(userId));
            }

            var user = await _userRepository.GetUser(userId);
            return _mapper.Map<UserDto>(user);
        }


        public async Task<UserDto> CreateUser(UserDto userData)
        {
            if(userData == null)
            {
                throw new ArgumentNullException(nameof(userData));
            }

            var user = _mapper.Map<User>(userData);
            var result = await _userRepository.CreateUser(user);

            return _mapper.Map<UserDto>(result);
        }

        public async Task<UserDto> UpdateUser(int id, UserDto userData)
        {
            if (id == 0 || id < 0)
            {
                throw new ArgumentException(nameof(id));
            }

            if (userData == null)
            {
                throw new ArgumentNullException(nameof(userData));
            }
            var user = _mapper.Map<User>(userData);
            var result = await _userRepository.UpdateUser(id, user);

            return _mapper.Map<UserDto>(result);
        }

        public async Task DeleteUser(int id)
        {
            if (id == 0 || id < 0)
            {
                throw new ArgumentException(nameof(id));
            }
            await _userRepository.DeleteUser(id);
        }
    }
}
