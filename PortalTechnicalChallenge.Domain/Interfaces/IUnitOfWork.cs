using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalTechnicalChallenge.Domain.Interfaces
{

    /// <summary>
    /// interface de unidade de trabalho para trabalharcom transaction
    /// </summary>

    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        int BeginTransaction();
        bool Save();
    }
}
