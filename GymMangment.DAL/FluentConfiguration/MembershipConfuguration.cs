using GymMangment.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymMangement.DAL.FluentConfiguration
{
    public class MembershipConfuguration : IEntityTypeConfiguration<MemberShip>
    {
        public void Configure(EntityTypeBuilder<MemberShip> builder)
        {
         builder.HasKey(X => X.ID);
            builder.Property(X => X.createdAt).HasColumnName("startedDate").HasDefaultValueSql("GETDATE()");
        }
    }
    }

