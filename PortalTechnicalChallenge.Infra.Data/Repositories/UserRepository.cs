using Microsoft.EntityFrameworkCore;
using PortalTechnicalChallenge.Domain.Entities;
using PortalTechnicalChallenge.Domain.Interfaces;
using PortalTechnicalChallenge.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace PortalTechnicalChallenge.Infra.Data.Repositories
{
    /// <summary>
    /// repositorio de usuario
    /// </summary>
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        protected readonly PortalTechnicalChallengeContext _context;

        public UserRepository(PortalTechnicalChallengeContext context)
            : base(context)
        {
            _context = context;
        }

        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email);
        }



        public async Task<List<User>> GetAllAsync(int pageNumber, int pageSize)
        {
            var pagedData = await _context.Users
               .Skip((pageNumber - 1) * pageSize)
               .Take(pageSize)
               .ToListAsync();

            return pagedData;
        }

    }
}
