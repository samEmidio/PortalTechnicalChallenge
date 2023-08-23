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
    /// map da entidade audit
    /// </summary>

    public abstract class AuditEntityMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : AuditEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(c => c.CreatedAt)
                   .HasColumnName("created_at")
                   .IsRequired();

            builder.Property(c => c.CreatedBy)
                   .HasColumnName("created_by")
                   .IsRequired();

            builder.Property(c => c.UpdatedAt)
                   .HasColumnType("date")
                   .HasColumnName("updated_at");

            builder.Property(c => c.UpdatedBy)
                   .HasColumnName("updated_by");
        }
    }
}
