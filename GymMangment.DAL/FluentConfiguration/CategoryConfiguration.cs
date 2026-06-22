using GymMangment.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymMangment.DAL.FluentConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(X => X.Name).HasMaxLength(30).HasColumnType("varchar");

                builder.Property(X=>X.createdAt).HasDefaultValueSql("GETDATE()")
                ;

            builder.HasData(
              new Category{ID=1, Name = "Cadio" },
            new Category {ID=2, Name = "strength" },
            new Category {ID=3, Name = "Yoga" },
            new Category {ID=4 ,Name = "Boxing" },
            new Category {ID = 5, Name = "CrossFit" }
            );
        }

  
    }
    }

