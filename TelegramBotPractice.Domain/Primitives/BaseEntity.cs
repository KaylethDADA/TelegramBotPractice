namespace TelegramBotPractice.Domain.Primitives
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is not BaseEntity entity)
                return false;

            return GetHashCode() == entity.GetHashCode();
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
