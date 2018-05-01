using Dapper.Crud.VSExtension.Helpers;
using System.IO;
using Xunit;

namespace Dapper.Crud.Tests
{
    public class AssemblyTest
    {
        [Fact]
        public void TestGenerateInstance()
        {
            // Arrange
            var path = Path.GetFullPath(@"..\..\..\Dapper.Crud.Model\");
            var objText = File.ReadAllText(path + "User.cs");

            // Act
            var instance = AssemblyHelper.ExecuteCode(objText, "Dapper.Crud.ModelExample", "User", false);

            // Assert
            Assert.True(instance != null);
        }
    }
}