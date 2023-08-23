using PortalTechnicalChallenge.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// interface de servico de usuario
/// </summary>

namespace PortalTechnicalChallenge.Application.Interfaces
{
    public interface IUserAppService
    {
        UserViewModel AddIfNotExists(CreateUserViewModel createUserViewModel);
        UserViewModel GetByEmail(string email);
        UserViewModel GetById(int id);
        void Delete(int id);
        UserViewModel UpdateUser(UpdateUserViewModel updateUserViewModel);
        Task<List<UserViewModel>> GetAll(int pageNumber, int pageSize);
    }
}
