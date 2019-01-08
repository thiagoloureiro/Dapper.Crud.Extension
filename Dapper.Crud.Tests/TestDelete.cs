using Dapper.Crud.ModelExample;
using Dapper.Crud.VSExtension.Helpers;
using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace Dapper.Crud.Tests
{
    public class TestDelete
    {
        [Fact]
        public void GenerateDelete()
        {
            // Arrange
            var objUser = new User();
            IList<PropertyInfo> props = new List<PropertyInfo>(objUser.GetType().GetProperties());

            // Act
            var ret = DapperGenerator.Delete("User", props, false, false);

            // Assert
            Assert.Contains("DELETE FROM User WHERE Id = @Id", ret);
            Assert.Contains("db.Execute(sql, new { user.Id }, commandType: CommandType.Text);", ret);
        }
    }
}