using DAL.Entitys;
using Domain.Entitys;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class BasicDataBaseContext : DbContext
{
    public DbSet<BookEntity> Books { get; set; }
    public DbSet<AuthourEntity> Authors { get; set; }


    public BasicDataBaseContext(DbContextOptions<BasicDataBaseContext> DBconfiguration) : base(DBconfiguration)
    {
        this.Database.EnsureCreated();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BasicDataBaseContext).Assembly);
    }
}