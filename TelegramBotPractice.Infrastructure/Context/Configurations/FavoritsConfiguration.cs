using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TelegramBotPractice.Domain;

namespace TelegramBotPractice.Infrastructure.Context.Configurations
{
    public class FavoritsConfiguration : IEntityTypeConfiguration<Favorit>
    {
        public void Configure(EntityTypeBuilder<Favorit> builder)
        {
            builder.ToTable("Favorits");
            builder.HasKey(k => new { k.UserId, k.BookId });


        }
    }
}
