using Dapper.Crud.VSExtension.Helpers;
using Xunit;

namespace Dapper.Crud.Tests
{
    public class TestInterface
    {
        private string model = "User";

        [Fact]
        public void GenerateInterfaceBody()

        {
            // Act
            var ret = InterfaceGenerator.GenerateInterfaceBody(model);

            // Assert
            Assert.Contains("public interface IUserRepository", ret);
        }

        [Fact]
        public void SelectTest()
        {
            // Act
            var ret = InterfaceGenerator.GenerateSelect(model);

            // Assert
            Assert.Contains($"List<User> SelectUser();", ret);
        }

        [Fact]
        public void InsertTest()
        {
            // Act
            var ret = InterfaceGenerator.GenerateInsert(model);

            // Assert
            Assert.Contains($"void InsertUser(User user);", ret);
        }

        [Fact]
        public void UpdateTest()
        {
            // Act
            var ret = InterfaceGenerator.GenerateUpdate(model);

            // Assert
            Assert.Contains($"void UpdateUser(User user);", ret);
        }

        [Fact]
        public void DeleteTest()
        {
            // Act
            var ret = InterfaceGenerator.GenerateDelete(model);

            // Assert
            Assert.Contains($"void DeleteUser(User user);", ret);
        }
    }
}