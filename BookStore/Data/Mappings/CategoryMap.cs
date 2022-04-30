using BookStore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("CATEGORIES");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100).HasColumnName("NAME");
            builder.Property(c => c.Description).HasMaxLength(1000).HasColumnName("DESCRIPTION");
            builder.Property(c => c.InsertedDate).HasColumnType("date").HasColumnName("INSERTED_DATE");
            builder.Property(c => c.InsertedUserId).HasColumnName("INSERTED_USER_ID").HasColumnType("int");
            builder.Property(c => c.Status).HasColumnType("int").HasColumnName("STATUS");
            builder.Property(c => c.UpdatedDate).HasColumnType("date").HasColumnName("UPDATED_DATE");
            builder.Property(c => c.UpdatedUserId).HasColumnName("UPDATED_USER_ID").HasColumnType("int");

            builder.HasMany(c => c.Books).WithOne(b => b.Category).HasForeignKey(b => b.CategoryId);
        }
    }
}
