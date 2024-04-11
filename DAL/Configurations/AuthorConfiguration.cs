using Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {

        builder
            .HasMany(ex => ex.WritedBooks)
            .WithOne(ex => ex.Writer)
            .OnDelete(DeleteBehavior.Cascade);

        var nameBuilder = builder
            .ComplexProperty(ex => ex.Name);

        nameBuilder
            .Property(ex => ex.FirstName)
            .HasField("FirstName");
        
        
        nameBuilder
            .Property(ex => ex.LastName)
            .HasField("LastName");
        
        nameBuilder
            .Property(ex => ex.SecondName)
            .HasField("SecondName");
        
    }
}