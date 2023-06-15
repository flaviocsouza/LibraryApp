using LibraryBusiness.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {

            builder.ToTable("Addresses");

            builder.HasKey(a => a.Id);

            builder.Ignore(a => a.IsActive);

            builder.Property(a => a.Street)
                .HasColumnType("varchar(80)")
                .IsRequired();

            builder.Property(a => a.City)
                .HasColumnType("varchar(80)")
                .IsRequired();

            builder.Property(a => a.State)
                .HasColumnType("varchar(80)")
                .IsRequired();

            builder.Property(a => a.PostalCode)
                .HasColumnType("varchar(10)")
                .IsRequired();

            builder.Property(a => a.Country)
                .HasColumnType("varchar(80)")
                .IsRequired();


            builder.Property(a => a.Phone)
                .HasColumnType("varchar(15)")
                .IsRequired();

            builder.HasOne(a => a.Member)
            .WithOne(m => m.Address)
            .HasForeignKey<Member>(m => m.AddressId);

            builder.HasOne(a => a.Library)
                .WithOne(l => l.Address)
                .HasForeignKey<Library>(l => l.AddressId);


            builder.HasOne(a => a.Publisher)
                .WithOne(p => p.Address)
                .HasForeignKey<Publisher>(l => l.AddressId);
        }
    }
}
