using System.IO;
using Dapper.Crud.VSExtension.Helpers;
using Xunit;

namespace Dapper.Crud.Tests.ModelTest
{
    public class AssemblyTest
    {
        [Fact]
        public void TestGenerateInstance()
        {
            // Arrange
            var path = System.IO.Path.GetFullPath(@"..\..\");
            var objText = File.ReadAllText(path + "\\ModelTest\\User.cs");

            // Act
            var instance = AssemblyHelper.ExecuteCode(objText, "Dapper.Crud.Tests.ModelTest", "User", false);

            // Assert
            Assert.True(instance != null);
        }
    }
}