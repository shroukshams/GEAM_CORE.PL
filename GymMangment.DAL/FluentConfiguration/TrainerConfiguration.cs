using GymMangment.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace GymMangement.DAL.FluentConfiguration
{

    public class TrainerConfiguration : IEntityTypeConfiguration<Trainer>
    {
        public void Configure(EntityTypeBuilder<Trainer> builder)
        {
                
        
            builder.Property(X => X.createdAt).HasColumnName("HireDAte").HasDefaultValueSql("GETDATE()");

        }
    }
    

}

    

