using Microsoft.EntityFrameworkCore;
using TelegramBotPractice.Application.Dtos.Reporting;
using TelegramBotPractice.Domain.Entities;

namespace TelegramBotPractice.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Favorit> Favorits { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookOfGenre> BookOfGenres { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("User ID=postgres;Password=1488;Host=localhost;Port=5432;Database=postgres;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            modelBuilder.Entity<MostFavoritedBook>().HasNoKey();
        }

        [DbFunction(Name = "getmostfavoritedbooks", Schema = "public")]
        public virtual IQueryable<MostFavoritedBook> GetMostFavoritedBooks()
        {
            return Set<MostFavoritedBook>().FromSqlRaw("SELECT * FROM getmostfavoritedbooks()");
        }
    }
}
