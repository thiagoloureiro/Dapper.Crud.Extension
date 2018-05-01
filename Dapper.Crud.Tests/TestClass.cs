using Dapper.Crud.VSExtension.Helpers;
using Xunit;

namespace Dapper.Crud.Tests
{
    public class TestClass
    {
        private string model = "User";

        [Fact]
        public void GenerateClass()
        {
            var ret = ClassGenerator.GenerateClassBody(model, false);
            Assert.Contains("public class UserRepository", ret);
        }

        [Fact]
        public void GenerateClassWithInterface()
        {
            var ret = ClassGenerator.GenerateClassBody(model, true);
            Assert.Contains("public class UserRepository : IUserRepository", ret);
        }
    }
}