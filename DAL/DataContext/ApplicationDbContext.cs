using APIBiblioteca.Models;
using Microsoft.EntityFrameworkCore;
namespace APIBiblioteca.DAL.DataContext
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Genre>().Property(x => x.Name).HasMaxLength(150);

      modelBuilder.Entity<Author>().Property(x => x.Name).HasMaxLength(150);
      modelBuilder.Entity<Author>().Property(x => x.PublicationDate).HasColumnType("date");


      modelBuilder.Entity<Book>().Property(x => x.Title).HasMaxLength(200);
      modelBuilder.Entity<Book>().Property(x => x.PublicationDate).HasColumnType("date");


      modelBuilder.Entity<Comment>().Property(x => x.Content).HasMaxLength(200);
    }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Book> Books { get; set; }

  }
}
