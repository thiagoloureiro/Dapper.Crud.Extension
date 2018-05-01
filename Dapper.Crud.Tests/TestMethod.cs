using Dapper.Crud.ModelExample;
using Dapper.Crud.VSExtension.Helpers;
using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace Dapper.Crud.Tests
{
    public class TestMethod
    {
        private string model = "User";

        [Fact]
        public void GenerateInsert()
        {
            // Arrange
            var objUser = new User();
            IList<PropertyInfo> props = new List<PropertyInfo>(objUser.GetType().GetProperties());
            var content = DapperGenerator.Insert("User", props, false, false, false);

            // Act
            var ret = MethodGenerator.GenerateInsert(content, model, false);

            // Assert
            Assert.Contains("public void InsertUser(User user)", ret);
            Assert.Contains(content, ret);
        }

        [Fact]
        public void GenerateSelect()
        {
            // Arrange
            var objUser = new User();
            IList<PropertyInfo> props = new List<PropertyInfo>(objUser.GetType().GetProperties());
            var content = DapperGenerator.Select("User", props, false, false);

            // Act
            var ret = MethodGenerator.GenerateSelect(content, model, false);

            // Assert
            Assert.Contains("public List<User> SelectUser()", ret);
            Assert.Contains(content, ret);
        }

        [Fact]
        public void GenerateUpdate()
        {
            // Arrange
            var objUser = new User();
            IList<PropertyInfo> props = new List<PropertyInfo>(objUser.GetType().GetProperties());
            var content = DapperGenerator.Update("User", props, false, false, false);

            // Act
            var ret = MethodGenerator.GenerateUpdate(content, model, false);

            // Assert
            Assert.Contains("public void UpdateUser(User user)", ret);
            Assert.Contains(content, ret);
        }

        [Fact]
        public void GenerateDelete()
        {
            // Arrange
            var objUser = new User();
            IList<PropertyInfo> props = new List<PropertyInfo>(objUser.GetType().GetProperties());
            var content = DapperGenerator.Delete("User", props, false, false);

            // Act
            var ret = MethodGenerator.GenerateDelete(content, model, false);

            // Assert
            Assert.Contains("public void DeleteUser(User user)", ret);
            Assert.Contains(content, ret);
        }
    }
}