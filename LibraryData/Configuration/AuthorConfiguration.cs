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
    internal class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors");

            builder.HasKey(a => a.Id);
            
            builder.Ignore(a => a.IsActive);

            builder.Property(a => a.CreateDate)
                .HasDefaultValueSql("getdate()");

            builder.Property(a => a.UpdateDate)
                .HasDefaultValueSql("getdate()");

            builder.Property(a => a.Name)
                .HasColumnType("Varchar(120)")
                .IsRequired();


            builder.Property(a => a.Nationality)
                .HasColumnType("Varchar(20)")
                .IsRequired();

            builder.HasMany(a => a.PublishedBooks)
                .WithOne(a => a.Author)
                .HasForeignKey(a => a.AuthorId);
        }
    }
}
