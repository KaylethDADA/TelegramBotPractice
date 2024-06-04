using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TelegramBotPractice.Domain.Entities;

namespace TelegramBotPractice.Infrastructure.Context.Configurations
{
    public class GenresConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genres");
            builder.HasKey(k => k.Id);

        }
    }
}
