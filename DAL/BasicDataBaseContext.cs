using Domain.Entitys;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class BasicDataBaseContext : DbContext
{
    public DbSet<Book> Books { get; }
    public DbSet<Author> Authors { get; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BasicDataBaseContext).Assembly);
    }
}