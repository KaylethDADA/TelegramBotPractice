using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TelegramBotPractice.Domain.Entities;

namespace TelegramBotPractice.Infrastructure.Context.Configurations
{
    public class AuthorsConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors");
            builder.HasKey(k => k.Id);


            builder.OwnsOne(x => x.FullName, fullName =>
            {
                fullName.Property(x => x.FirstName)
                .IsRequired();
                fullName.Property(x => x.LastName)
                .IsRequired();
                fullName.Property(x => x.MiddleName);
            });

        }
    }
}
