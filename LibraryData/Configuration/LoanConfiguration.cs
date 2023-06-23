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
    public class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.ToTable("Loans");
            
            builder.HasKey(l => l.Id);

            builder.Ignore(l => l.IsActive);

            builder.Property(a => a.CreateDate)
                .HasDefaultValueSql("getdate()");

            builder.Property(a => a.UpdateDate)
                .HasDefaultValueSql("getdate()");

            builder.Property(l => l.LoanDate)
                .IsRequired();

            builder.Property(l => l.DueDate)
                .IsRequired();

            builder.HasOne(l => l.Book)
                .WithMany(b => b.LoanHistory)
                .HasForeignKey(l => l.BookId);

            builder.HasOne(l => l.Member)
                .WithMany(m => m.LoanHistory)
                .HasForeignKey(l => l.MemberId);

        }
    }
}
