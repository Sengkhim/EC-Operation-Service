using EcommerceServiceOperation.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerceServiceOperation.Infrastructure.ConfigEntitiesMapping;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.CategoryId).IsRequired();
        builder.HasIndex(e => e.Code).IsUnique();
        builder.Property(e => e.Name).HasMaxLength(100).IsRequired();
        builder.Property(e => e.Status).IsRequired();
        builder.Property(e => e.Price).IsRequired();
        builder.Property(e => e.Description).HasMaxLength(150);
        builder.Property(e => e.CreatedAt).IsRequired();
        builder.Property(e => e.UpdateAt);
        
        builder.HasOne<Category>(e => e.Category).WithOne(c => c.Product)
            .HasForeignKey<Product>(pf => pf.CategoryId);
    }
}