using AutoFixture;
using TelegramBotPractice.Domain.Entities;
using TelegramBotPractice.Domain.ValueObjects;

namespace TelegramBotPractice.DomainTest.Entities
{
    public class UserTest
    {
        private readonly Fixture _fixture = new Fixture();

        public UserTest()
        {
            // Remove ThrowingRecursionBehavior and add OmitOnRecursionBehavior
            _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Fact]
        public void Create_User_Successfully()
        {
            // Arrange
            var chatId = 1234567890;
            var fullName = _fixture.Create<FullName>();
            var username = "john_doe";
            var favorits = _fixture.CreateMany<Favorit>(3); // Creates a collection of Favorit

            var user = new User
            {
                ChatId = chatId,
                FullName = fullName,
                Username = username,
                Favorits = favorits.ToList() // Convert IEnumerable<Favorit> to List<Favorit>
            };

            // Assert
            Assert.Equal(chatId, user.ChatId);
            Assert.Equal(fullName, user.FullName);
            Assert.Equal(username, user.Username);
            Assert.Equal(favorits, user.Favorits);
        }

        [Fact]
        public void Update_UserProperties_Successfully()
        {
            // Arrange
            var user = _fixture.Create<User>();  // Create a random user

            var firstName = "John";
            var lastName = "Doe";
            var middleName = "Middle";
            var userName = "johndoe";

            // Act
            var result = user.Update(firstName, lastName, middleName, userName);

            // Assert
            Assert.Equal(firstName, user.FullName.FirstName);
            Assert.Equal(lastName, user.FullName.LastName);
            Assert.Equal(middleName, user.FullName.MiddleName);
            Assert.Equal(userName, user.Username);
        }
    }
}
