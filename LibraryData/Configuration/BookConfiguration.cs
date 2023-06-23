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
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");

            builder.HasKey(b => b.Id);

            builder.Ignore(b => b.IsActive);

            builder.Property(a => a.CreateDate)
                .HasDefaultValueSql("getdate()");

            builder.Property(a => a.UpdateDate)
                .HasDefaultValueSql("getdate()");

            builder.Property(b => b.Title)
                .HasColumnType("varchar(80)")
                .IsRequired();

            builder.Property(b => b.ISBN)
                .HasColumnType("varchar(13)")
                .IsRequired();

            builder.HasOne(b => b.Author)
                .WithMany(a => a.PublishedBooks)
                .HasForeignKey(b => b.AuthorId);


            builder.HasOne(b => b.Publisher)
                .WithMany(p => p.PublishedBooks)
                .HasForeignKey(b => b.PublisherId);
        }
    }
}
