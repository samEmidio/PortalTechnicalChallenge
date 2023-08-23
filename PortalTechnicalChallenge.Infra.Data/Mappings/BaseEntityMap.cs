using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalTechnicalChallenge.Domain.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalTechnicalChallenge.Infra.Data.Mappings
{
    /// <summary>
    /// amap da entidade baseEntity
    /// </summary>
    public abstract class BaseEntityMap <TEntity> : AuditEntityMap<TEntity> where TEntity : BaseEntity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder, string entityName)
        {
            builder.Property(c => c.Id)
                   .HasColumnName("id")
                   .HasColumnType("integer");


            base.Configure(builder);
        }
    }
}
