using Api.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Services.Interfaces
{
    public interface IUserTypeService
    {
        Task<IEnumerable<UserTypeDto>> GetAllUserTypes();
    }
}
