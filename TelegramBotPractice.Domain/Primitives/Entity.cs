namespace TelegramBotPractice.Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is not Entity entity)
                return false;

            return GetHashCode() == entity.GetHashCode();
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
