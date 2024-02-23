using Dapper.Crud.VSExtension.Helpers;
using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace Dapper.Crud.Tests
{
    public class TestMethod
    {
        private readonly string model = "User";

        [Fact]
        public void GenerateInsert()
        {
            // Arrange
            var objUser = new User();
            IList<PropertyInfo> props = new List<PropertyInfo>(objUser.GetType().GetProperties());
            var content = DapperGenerator.Insert("User", props, false, false, false, false, false, false);

            // Act
            var ret = MethodGenerator.GenerateInsert(content, model, false, false, false);

            // Assert
            Assert.Contains("public void InsertUser(User user)", ret);
            Assert.Contains(content, ret);
        }

        [Fact]
        public void GenerateInsertAsync()
        {
            // Arrange
            var objUser = new User();
            IList<PropertyInfo> props = new List<PropertyInfo>(objUser.GetType().GetProperties());
            var content = DapperGenerator.Insert("User", props, false, false, false, true, false, false);

            // Act
            var ret = MethodGenerator.GenerateInsert(content, model, false, true, false);

            // Assert
            Assert.Contains("public async Task InsertUser(User user)", ret);
            Assert.Contains(content, ret);
        }

        [Fact]
        public void GenerateReturnIdInsert()
        {
            // Arrange
            var objUser = new User();
            IList<PropertyInfo> props = new List<PropertyInfo>(objUser.GetType().GetProperties());
            var content = DapperGenerator.Insert("User", props, false, false, false, false, true, false);

            // Act
            var ret = MethodGenerator.GenerateInsert(content, model, false, false, true);

            // Assert
            Assert.Contains("public int InsertUser(User user)", ret);
            Assert.Contains(content, ret);
        }

        [Fact]
        public void GenerateReturnIdInsertAsync()
        {
            // Arrange
            var objUser = new User();
            IList<PropertyInfo> props = new List<PropertyInfo>(objUser.GetType().GetProperties());
            var content = DapperGenerator.Insert("User", props, false, false, false, true, true, false);

            // Act
            var ret = MethodGenerator.GenerateInsert(content, model, false, true, true);

            // Assert
            Assert.Contains("public async Task<int> InsertUser(User user)", ret);
            Assert.Contains(content, ret);
        }

        [Fact]
        public void GenerateSelect()
        {
            // Arrange
            var objUser = new User();
            IList<PropertyInfo> props = new List<PropertyInfo>(objUser.GetType().GetProperties());
            var content = DapperGenerator.Select("User", props, false, false, false, false);

            // Act
            var ret = MethodGenerator.GenerateSelect(content, model, false, false);

            // Assert
            Assert.Contains("public IEnumerable<User> SelectUser()", ret);
            Assert.Contains(content, ret);
        }

        [Fact]
        public void GenerateSelectAsync()
        {
            // Arrange
            var objUser = new User();
            IList<PropertyInfo> props = new List<PropertyInfo>(objUser.GetType().GetProperties());
            var content = DapperGenerator.Select("User", props, false, false, true, false);

            // Act
            var ret = MethodGenerator.GenerateSelect(content, model, false, true);

            // Assert
            Assert.Contains("public async Task<IEnumerable<User>> SelectUser()", ret);
            Assert.Contains(content, ret);
        }

        [Fact]
        public void GenerateUpdate()
        {
            // Arrange
            var objUser = new User();
            IList<PropertyInfo> props = new List<PropertyInfo>(objUser.GetType().GetProperties());
            var content = DapperGenerator.Update("User", props, false, false, false, false, false);

            // Act
            var ret = MethodGenerator.GenerateUpdate(content, model, false, false);

            // Assert
            Assert.Contains("public void UpdateUser(User user)", ret);
            Assert.Contains(content, ret);
        }

        [Fact]
        public void GenerateUpdateAsync()
        {
            // Arrange
            var objUser = new User();
            IList<PropertyInfo> props = new List<PropertyInfo>(objUser.GetType().GetProperties());
            var content = DapperGenerator.Update("User", props, false, false, false, true, false);

            // Act
            var ret = MethodGenerator.GenerateUpdate(content, model, false, true);

            // Assert
            Assert.Contains("public async Task UpdateUser(User user)", ret);
            Assert.Contains(content, ret);
        }

        [Fact]
        public void GenerateDelete()
        {
            // Arrange
            var objUser = new User();
            IList<PropertyInfo> props = new List<PropertyInfo>(objUser.GetType().GetProperties());
            var content = DapperGenerator.Delete("User", props, false, false, false, false);

            // Act
            var ret = MethodGenerator.GenerateDelete(content, model, false, false);

            // Assert
            Assert.Contains("public void DeleteUser(User user)", ret);
            Assert.Contains(content, ret);
        }

        [Fact]
        public void GenerateDeleteAsync()
        {
            // Arrange
            var objUser = new User();
            IList<PropertyInfo> props = new List<PropertyInfo>(objUser.GetType().GetProperties());
            var content = DapperGenerator.Delete("User", props, false, false, true, false);

            // Act
            var ret = MethodGenerator.GenerateDelete(content, model, false, true);

            // Assert
            Assert.Contains("public async Task DeleteUser(User user)", ret);
            Assert.Contains(content, ret);
        }
    }
}