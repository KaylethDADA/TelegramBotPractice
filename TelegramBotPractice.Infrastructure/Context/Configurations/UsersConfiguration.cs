using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TelegramBotPractice.Domain.Entities;

namespace TelegramBotPractice.Infrastructure.Context.Configurations
{
    public class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(k => k.Id);

            builder.OwnsOne(x => x.FullName, fullName =>
            {
                fullName.Property(x => x.FirstName)
                .IsRequired();
                fullName.Property(x => x.LastName);
                fullName.Property(x => x.MiddleName);
            });

            builder.HasMany(u => u.Favorits)
                .WithOne(f => f.User)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
