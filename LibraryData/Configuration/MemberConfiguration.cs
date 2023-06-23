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
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable("Members");

            builder.HasKey(m => m.Id);

            builder.Ignore(m => m.IsActive);

            builder.Property(a => a.CreateDate)
                .HasDefaultValueSql("getdate()");

            builder.Property(a => a.UpdateDate)
                .HasDefaultValueSql("getdate()");

            builder.Property(m => m.Name)
                .HasColumnType("varchar(120)");
        }
    }
}
