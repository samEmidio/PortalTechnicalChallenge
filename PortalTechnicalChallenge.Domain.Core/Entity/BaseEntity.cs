using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalTechnicalChallenge.Domain.Core.Entity
{
    public class BaseEntity : AuditEntity
    {
        public Guid Identifier { get; protected set; } = Guid.NewGuid();
        [Key]
        public int Id { get; set; }
    }
}
