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
    public class LibraryConfiguration : IEntityTypeConfiguration<Library>
    {
        public void Configure(EntityTypeBuilder<Library> builder)
        {
            builder.ToTable("Libraries");

            builder.HasKey(l => l.Id);

            builder.Ignore(l => l.IsActive);

            builder.Property(l => l.Name)
                .HasColumnType("varchar(80)")
                .IsRequired();
        }
    }
}
