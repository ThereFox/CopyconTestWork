using DAL.Entitys;
using Domain.Entitys;
using Domain.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<BookEntity>
{
    public void Configure(EntityTypeBuilder<BookEntity> builder)
    {
        builder
            .HasKey(ex => ex.Id);

        
        builder
            .HasOne(ex => ex.Authour)
            .WithMany(ex => ex.Books)
            .HasForeignKey(ex => ex.AuthourId)
            .HasPrincipalKey(ex => ex.Id)
            .OnDelete(DeleteBehavior.Cascade);
        
            builder.Property(ex => ex.Id).HasColumnName("LanguageId");
    }
}