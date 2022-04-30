using BookStore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data.Mappings
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("BOOKS");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name).IsRequired().HasColumnName("NAME").HasMaxLength(100);
            builder.Property(b => b.InsertedDate).HasColumnType("date").HasColumnName("INSERTED_DATE");
            builder.Property(b => b.InsertedUserId).HasColumnName("INSERTED_USER_ID").HasColumnType("int");
            builder.Property(b => b.UpdatedDate).HasColumnType("date").HasColumnName("UPDATED_DATE");
            builder.Property(b => b.UpdatedUserId).HasColumnName("UPDATED_USER_ID").HasColumnType("int");
            builder.Property(b => b.AuthorId).HasColumnName("AUTHOR_ID");
            builder.Property(b => b.CategoryId).HasColumnName("CATEGORY_ID");
            builder.Property(b => b.Description).HasMaxLength(1000).HasColumnName("DESCRIPTION");
            builder.Property(b => b.Price).HasColumnType("DECIMAL").HasDefaultValue(0);

            builder.HasOne(b => b.Author).WithMany(a => a.Books).HasForeignKey(b => b.AuthorId);
        }
    }
}
