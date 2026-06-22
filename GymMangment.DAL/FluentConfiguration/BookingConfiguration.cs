using GymMangment.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymMangment.DAL.FluentConfiguration
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Booking> builder)
        {
            builder.Ignore(X => X.ID);
            builder.HasKey(X => new { X.MemberId, X.SessionId });
            builder.Property(X => X.createdAt).HasColumnName("BookingDate").HasDefaultValueSql("GETDATE()");


        }
    }
}
