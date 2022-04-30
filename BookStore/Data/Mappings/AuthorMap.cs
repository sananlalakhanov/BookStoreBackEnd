using BookStore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data.Mappings
{
    public class AuthorMap : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("AUTHORS");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.DateOfBirth).HasColumnType("date");
            builder.Property(a => a.Description).HasMaxLength(1000).HasColumnName("DESCRIPTION");
            builder.Property(a => a.Email).IsRequired().HasMaxLength(50);
            builder.Property(a => a.Gender).IsRequired().HasColumnType("int");
            builder.Property(a=>a.InsertedDate).HasColumnType("date").HasColumnName("INSERTED_DATE");
            builder.Property(a=>a.UpdatedDate).HasColumnType("date").HasColumnName("UPDATED_DATE");
            builder.Property(a=>a.InsertedUserId).HasColumnName("INSERTED_USER_ID").HasColumnType("int");
            builder.Property(a=>a.UpdatedUserId).HasColumnName("UPDATED_USER_ID").HasColumnType("int");
            builder.Property(a=>a.Name).IsRequired().HasMaxLength(50).HasColumnName("NAME");
            builder.Property(a=>a.Surname).IsRequired().HasMaxLength(50).HasColumnName("SURNAME");
            builder.Property(a => a.Status).IsRequired().HasColumnType("int").HasColumnName("STATUS");

            //builder.HasMany(a => a.Books).WithOne(b => b.Author).HasForeignKey(b => b.AuthorId);
        }
    }
}
