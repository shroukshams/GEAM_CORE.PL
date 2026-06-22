using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GymMangement.DAL.Models;
using GymMangment.DAL.Models;
namespace GymMangment.DAL.FluentConfiguration
{
    internal class PlanConfiguration : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder) { 
       builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Description).HasMaxLength(200);
        builder.Property(p => p.Price).HasColumnType("decimal(18,2)");

        builder.Property(p => p.IsActive).IsRequired();
        builder.Property(p => p.createdAt).HasDefaultValueSql("GETDATE()");
        builder.Property(p => p.updatedAt).HasDefaultValueSql("GETDATE()");
        builder.ToTable(TB => { TB.HasCheckConstraint("PlanDurationCheck", "[DurationOnDays] BETWEEN 1 AND 356"); });
        }
        }
    }

