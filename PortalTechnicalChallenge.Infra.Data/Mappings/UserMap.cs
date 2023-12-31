﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalTechnicalChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalTechnicalChallenge.Infra.Data.Mappings
{
    /// <summary>
    /// map da entidade user
    /// </summary>
    public class UserMap : BaseEntityMap<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("technical_challenge_user");

            builder.Property(c => c.Name)
                .HasColumnType("varchar(255)")
                .HasColumnName("name")
                .IsRequired();

            builder.Property(c => c.LastName)
                .HasColumnType("varchar(255)")
                .HasColumnName("last_name")
                .IsRequired();

            builder.Property(c => c.Age)
                .HasColumnType("integer")
                .HasColumnName("age")
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnType("varchar(255)")
                .HasColumnName("email")
                .IsRequired();

            base.Configure(builder, "user");
        }
    }
}
