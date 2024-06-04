using System.Text.Json;

namespace TelegramBotPractice.Domain.Primitives
{
    public abstract class BaseValueObjects
    {
        public override bool Equals(object? obj)
        {
            if (obj is not BaseValueObjects entity || entity == null)
                return false;

            var serialEnti = Serialize(entity);
            var serialThis = Serialize(this);

            if (string.Compare(serialEnti, serialThis) != 0)
                return false;

            return true;
        }
        public override int GetHashCode()
        {
            return Serialize(this).GetHashCode();
        }
        private string Serialize(BaseValueObjects valueObjects)
        {
            var serializedObjects = JsonSerializer.Serialize(valueObjects);
            return serializedObjects;
        }
    }
}
