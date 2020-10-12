using Api.DTO;
using Api.Repositories.Interfaces;
using Api.Services.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services
{
    public class UserTitleService : IUserTitleService
    {
        private readonly IUserTitleRepository _userTitleRepository;
        private readonly IMapper _mapper;

        public UserTitleService(IUserTitleRepository userTitleRepository, IMapper mapper)
        {
            _userTitleRepository = userTitleRepository ?? throw new ArgumentNullException(nameof(userTitleRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<UserTitleDto>> GetAllUserTitles()
        {
            var userTitles = await _userTitleRepository.GetAllUserTitles().ConfigureAwait(false);

            return userTitles.Select(x => _mapper.Map<UserTitleDto>(x));
        }
    }
}
