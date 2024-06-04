using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TelegramBotPractice.Domain;

namespace TelegramBotPractice.Infrastructure.Context.Configurations
{
    public class BookOfGenresConfiguration : IEntityTypeConfiguration<BookOfGenre>
    {
        public void Configure(EntityTypeBuilder<BookOfGenre> builder)
        {
            builder.ToTable("BookOfGenres");
            builder.HasKey(k => new { k.GenreId, k.BookId });

            builder.HasOne(bg => bg.Book)
                .WithMany(b => b.Genres)
                .HasForeignKey(bg => bg.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(bg => bg.Genre)
                .WithMany(g => g.Books)
                .HasForeignKey(bg => bg.GenreId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
