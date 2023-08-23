using PortalTechnicalChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalTechnicalChallenge.Domain.Interfaces
{
    /// <summary>
    ///interface de repositorio de usuario 
    /// </summary>

    public interface IUserRepository : IBaseRepository<User>
    {
        User GetByEmail(string email);
        Task<List<User>> GetAllAsync(int pageNumber, int pageSize);
    }
}
