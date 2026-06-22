using GymMangment.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymMangement.DAL.FluentConfiguration
{
    internal class SessiosConfiguration : IEntityTypeConfiguration<Session>

    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.ToTable(TB =>
            {
                TB.HasCheckConstraint("SessionCapacityCheck", "Capacity Between 1and 25");
                TB.HasCheckConstraint("SessionEndDATECheck", "EndDate >StartDate");
            });
        }
    }
}
