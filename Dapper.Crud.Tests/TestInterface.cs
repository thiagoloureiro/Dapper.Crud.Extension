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
            var ret = InterfaceGenerator.GenerateSelect(model, false);

            // Assert
            Assert.Contains($"IEnumerable<User> SelectUser();", ret);
        }

        [Fact]
        public void SelectTestAsync()
        {
            // Act
            var ret = InterfaceGenerator.GenerateSelect(model, true);

            // Assert
            Assert.Contains($"Task<IEnumerable<User>> SelectUser();", ret);
        }

        [Fact]
        public void InsertTest()
        {
            // Act
            var ret = InterfaceGenerator.GenerateInsert(model, false, false);

            // Assert
            Assert.Contains($"void InsertUser(User user);", ret);
        }

        [Fact]
        public void InsertTestAsync()
        {
            // Act
            var ret = InterfaceGenerator.GenerateInsert(model, true, false);

            // Assert
            Assert.Contains($"Task InsertUser(User user);", ret);
        }

        [Fact]
        public void InsertReturnIdTest()
        {
            // Act
            var ret = InterfaceGenerator.GenerateInsert(model, false, true);

            // Assert
            Assert.Contains($"int InsertUser(User user);", ret);
        }

        [Fact]
        public void InsertReturnIdTestAsync()
        {
            // Act
            var ret = InterfaceGenerator.GenerateInsert(model, true, true);

            // Assert
            Assert.Contains($"Task<int> InsertUser(User user);", ret);
        }

        [Fact]
        public void UpdateTest()
        {
            // Act
            var ret = InterfaceGenerator.GenerateUpdate(model, false);

            // Assert
            Assert.Contains($"void UpdateUser(User user);", ret);
        }

        [Fact]
        public void UpdateTestAsync()
        {
            // Act
            var ret = InterfaceGenerator.GenerateUpdate(model, true);

            // Assert
            Assert.Contains($"Task UpdateUser(User user);", ret);
        }

        [Fact]
        public void DeleteTest()
        {
            // Act
            var ret = InterfaceGenerator.GenerateDelete(model, false);

            // Assert
            Assert.Contains($"void DeleteUser(User user);", ret);
        }

        [Fact]
        public void DeleteTestAsync()
        {
            // Act
            var ret = InterfaceGenerator.GenerateDelete(model, true);

            // Assert
            Assert.Contains($"Task DeleteUser(User user);", ret);
        }
    }
}