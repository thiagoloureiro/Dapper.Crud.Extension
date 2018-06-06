using Dapper.Crud.ModelExample;
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
            Assert.Contains("SELECT Id, Name, Email FROM [User]", ret);
            Assert.Contains("ret = db.Query<User>(sql, commandType: CommandType.Text).ToList();", ret);
        }

        [Fact]
        public void GenerateSelectJoin()
        {
            // Arrange
            var objUser = new User();
            var objAddress = new Address();

            IList<PropertyInfo> props = new List<PropertyInfo>(objUser.GetType().GetProperties());
            IList<PropertyInfo> props2 = new List<PropertyInfo>(objAddress.GetType().GetProperties());

            var lstProperties = new List<IList<PropertyInfo>>
            {
                props,
                props2
            };

            List<string> models = new List<string>
            {
                "User",
                "Address"
            };

            // Act
            var ret = DapperGenerator.SelectJoin(models, lstProperties, false, false);

            // Assert
            Assert.Contains("SELECT Id, Name, Email FROM [User]", ret);
            Assert.Contains("ret = db.Query<User>(sql, commandType: CommandType.Text).ToList();", ret);
        }
    }
}