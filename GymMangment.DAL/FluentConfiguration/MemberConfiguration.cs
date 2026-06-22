using GymMangment.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace GymMangement.DAL.FluentConfiguration
{
    internal class MemberConfiguration : GymUserConfiguration<Member>, IEntityTypeConfiguration<Member>
    {



        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(X => X.createdAt).HasColumnName("JionDate").HasDefaultValueSql("GETDATE()");
            base.Configure(builder);
        }
    }
}
    

