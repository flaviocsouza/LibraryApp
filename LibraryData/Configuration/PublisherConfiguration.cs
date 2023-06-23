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
    public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.ToTable("Publishers");

            builder.HasKey(p => p.Id);

            builder.Ignore(p => p.IsActive);

            builder.Property(a => a.CreateDate)
                .HasDefaultValueSql("getdate()");

            builder.Property(a => a.UpdateDate)
                .HasDefaultValueSql("getdate()");

            builder.Property(p => p.Name)
                .HasColumnType("varchar(80)")
                .IsRequired();
        }
    }
}