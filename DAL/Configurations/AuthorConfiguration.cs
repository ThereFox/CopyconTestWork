using DAL.Entitys;
using Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class AuthorConfiguration : IEntityTypeConfiguration<AuthourEntity>
{
    public void Configure(EntityTypeBuilder<AuthourEntity> builder)
    {

        builder.HasKey(ex => ex.Id);
        
        builder
            .HasMany(ex => ex.Books)
            .WithOne(ex => ex.Authour)
            .HasPrincipalKey(ex => ex.Id)
            .HasForeignKey(ex => ex.AuthourId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(ex => ex.Id).ValueGeneratedNever().HasColumnName("Id");
        builder.Property(ex => ex.YearOfBirth).HasColumnName("Year");
        

        builder.Property(ex1 => ex1.FirstName).HasColumnName("FirstName");
        builder.Property(ex1 => ex1.SecondName).HasColumnName("SecondName");
        builder.Property(ex1 => ex1.LastName).HasColumnName("LastName");

    }
}