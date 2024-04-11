using Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder
            .HasKey(ex => ex.Id);

        builder
            .HasOne(ex => ex.Writer)
            .WithMany(ex => ex.WritedBooks)
            .OnDelete(DeleteBehavior.Cascade);
        builder
            .ComplexProperty(ex => ex.OriginalLanguage)
            .Property(ex => ex.Name)
            .HasField("Language");
    }
}