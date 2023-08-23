using PortalTechnicalChallenge.Domain.Interfaces;
using PortalTechnicalChallenge.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PortalTechnicalChallenge.Infra.Data.UnitOfWork
{

    /// <summary>
    /// unidade de trabalho para trabalhar com transaction
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PortalTechnicalChallengeContext _context;
        private int _transactionCount;

        public UnitOfWork(PortalTechnicalChallengeContext context,
            IUserRepository users
        )
        {
            _context = context;
            Users = users;
        }

        public IUserRepository Users { get; private set; }


        public bool Save()
        {
            if (_transactionCount <= 1)
            {
                _transactionCount = 0;
                return _context.SaveChanges() > 0;
            }

            _transactionCount--;
            return true;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int BeginTransaction()
        {
            return ++_transactionCount;
        }
    }
}
