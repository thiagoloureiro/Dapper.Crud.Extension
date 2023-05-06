using Dapper.Crud.VSExtension.Helpers;
using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace Dapper.Crud.Tests
{
    public class TestInsert
    {
        [Fact]
        public void GenerateInsert()
        {
            // Arrange
            var objUser = new User();
            IList<PropertyInfo> props = new List<PropertyInfo>(objUser.GetType().GetProperties());

            // Act
            var ret = DapperGenerator.Insert("User", props, false, false, false, false, false, false);

            // Assert
            Assert.Contains("INSERT INTO [User] (Id, Name, Email) VALUES (@Id, @Name, @Email)", ret);
            Assert.Contains("db.Execute(sql, new { Id = user.Id, Name = user.Name, Email = user.Email }, commandType: CommandType.Text);", ret);
        }

        [Fact]
        public void GenerateInsertReturnId()
        {
            // Arrange
            var objUser = new User();
            IList<PropertyInfo> props = new List<PropertyInfo>(objUser.GetType().GetProperties());

            // Act
            var ret = DapperGenerator.Insert("User", props, false, false, false, false, true, false);

            // Assert
            Assert.Contains("INSERT INTO [User] (Id, Name, Email) VALUES (@Id, @Name, @Email)", ret);
            Assert.Contains("return db.QuerySingle<int>(sql, new { Id = user.Id, Name = user.Name, Email = user.Email }, commandType: CommandType.Text);", ret);
        }

        [Fact]
        public void GenerateInsertReturnIdAsync()
        {
            // Arrange
            var objUser = new User();
            IList<PropertyInfo> props = new List<PropertyInfo>(objUser.GetType().GetProperties());

            // Act
            var ret = DapperGenerator.Insert("User", props, false, false, false, true, true, false);

            // Assert
            Assert.Contains("INSERT INTO [User] (Id, Name, Email) VALUES (@Id, @Name, @Email)", ret);
            Assert.Contains("return await db.QueryAsync<int>(sql, new { Id = user.Id, Name = user.Name, Email = user.Email }, commandType: CommandType.Text).Single();", ret);
        }

        [Fact]
        public void GenerateInsertAsync()
        {
            // Arrange
            var objUser = new User();
            IList<PropertyInfo> props = new List<PropertyInfo>(objUser.GetType().GetProperties());

            // Act
            var ret = DapperGenerator.Insert("User", props, false, false, false, true, false, false);

            // Assert
            Assert.Contains("INSERT INTO [User] (Id, Name, Email) VALUES (@Id, @Name, @Email)", ret);
            Assert.Contains("await db.ExecuteAsync(sql, new { Id = user.Id, Name = user.Name, Email = user.Email }, commandType: CommandType.Text);", ret);
        }

        [Fact]
        public void GenerateInsertNoId()
        {
            // Arrange
            var objUser = new User();
            IList<PropertyInfo> props = new List<PropertyInfo>(objUser.GetType().GetProperties());

            // Act
            var ret = DapperGenerator.Insert("User", props, false, false, true, false, false, false);

            // Assert
            Assert.Contains("INSERT INTO [User] (Name, Email) VALUES (@Name, @Email)", ret);
            Assert.Contains("db.Execute(sql, new { Name = user.Name, Email = user.Email }, commandType: CommandType.Text);", ret);
        }

        [Fact]
        public void GenerateInsertNoIdAsync()
        {
            // Arrange
            var objUser = new User();
            IList<PropertyInfo> props = new List<PropertyInfo>(objUser.GetType().GetProperties());

            // Act
            var ret = DapperGenerator.Insert("User", props, false, false, true, true, false, false);

            // Assert
            Assert.Contains("INSERT INTO [User] (Name, Email) VALUES (@Name, @Email)", ret);
            Assert.Contains("await db.ExecuteAsync(sql, new { Name = user.Name, Email = user.Email }, commandType: CommandType.Text);", ret);
        }
    }
}