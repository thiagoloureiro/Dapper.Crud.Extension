using Dapper.Crud.VSExtension.Helpers;
using Xunit;

namespace Dapper.Crud.Tests
{
    public class InterfaceTest
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
            Assert.Contains($"List<{model}> Select{model}();", ret);
        }

        [Fact]
        public void InsertTest()
        {
            // Act
            var ret = InterfaceGenerator.GenerateInsert(model);

            // Assert
            Assert.Contains($"void Insert{model}({model} {model.ToLower()});", ret);
        }

        [Fact]
        public void UpdateTest()
        {
            // Act
            var ret = InterfaceGenerator.GenerateUpdate(model);

            // Assert
            Assert.Contains($"void Update{model}({model} {model.ToLower()});", ret);
        }

        [Fact]
        public void DeleteTest()
        {
            // Act
            var ret = InterfaceGenerator.GenerateDelete(model);

            // Assert
            Assert.Contains($"void Delete{model}({model} {model.ToLower()});", ret);
        }
    }
}