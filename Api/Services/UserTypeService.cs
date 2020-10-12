using Api.DTO;
using Api.Models;
using Api.Repositories.Interfaces;
using Api.Services.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services
{
    public class UserTypeService : IUserTypeService
    {
        private readonly IUserTypeRepository _userTypeRepository;
        private readonly IMapper _mapper;

        public UserTypeService(IUserTypeRepository userTypeRepository, IMapper mapper)
        {
            _userTypeRepository = userTypeRepository ?? throw new ArgumentNullException(nameof(userTypeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<UserTypeDto>> GetAllUserTypes()
        {
            var usersTypes = await _userTypeRepository.GetAllUserTypes().ConfigureAwait(false);

            return usersTypes.Select(x => _mapper.Map<UserTypeDto>(x));
        }
    }
}
