using PortalTechnicalChallenge.Domain.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// entidade de dominio usuario
/// </summary>

namespace PortalTechnicalChallenge.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }
}
