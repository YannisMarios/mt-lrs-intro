using Api.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Services.Interfaces
{
    public interface IUserTitleService
    {
        Task<IEnumerable<UserTitleDto>> GetAllUserTitles();
    }
}
