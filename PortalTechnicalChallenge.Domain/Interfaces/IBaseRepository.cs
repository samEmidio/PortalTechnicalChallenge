using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalTechnicalChallenge.Domain.Interfaces
{
    /// <summary>
    /// base repository com metodos genericos
    /// </summary>

    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        void AddRange(IEnumerable<TEntity> entities);
        TEntity GetById(int id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAllDesc();
        void Update(TEntity obj);
        void Remove(int id);
    }
}
