using Dapper.Crud.Tests.ModelTest;
using Dapper.Crud.VSExtension.Helpers;
using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace Dapper.Crud.Tests
{
    public class TestSelect
    {
        [Fact]
        public void GenerateSelect()
        {
            // Arrange
            var objUser = new User();
            IList<PropertyInfo> props = new List<PropertyInfo>(objUser.GetType().GetProperties());

            // Act
            var ret = DapperGenerator.Select("User", props, false, false);

            // Assert
            Assert.True(ret.Contains("SELECT Id, Name, Email FROM [User]"));
            Assert.True(ret.Contains("ret = db.Query<User>(sql, commandType: CommandType.Text).ToList();"));
        }
    }
}