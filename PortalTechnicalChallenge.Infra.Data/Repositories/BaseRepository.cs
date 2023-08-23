using Microsoft.EntityFrameworkCore;
using PortalTechnicalChallenge.Domain.Core.Entity;
using PortalTechnicalChallenge.Domain.Interfaces;
using PortalTechnicalChallenge.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PortalTechnicalChallenge.Infra.Data.Repositories
{
    /// <summary>
    /// repositorio com metodos genericos
    /// </summary>

    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly PortalTechnicalChallengeContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public BaseRepository(PortalTechnicalChallengeContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }


        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            Db.AddRange(entities);
        }

        public virtual TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual IQueryable<TEntity> GetAllDesc()
        {
            return DbSet.OrderByDescending(x => x.CreatedBy);
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
