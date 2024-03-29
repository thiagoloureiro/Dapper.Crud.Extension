﻿using Dapper.Crud.VSExtension.Helpers;
using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace Dapper.Crud.Tests
{
    public class TestUpdate
    {
        [Fact]
        public void GenerateUpdate()
        {
            // Arrange
            var objUser = new User();
            IList<PropertyInfo> props = new List<PropertyInfo>(objUser.GetType().GetProperties());

            // Act
            var ret = DapperGenerator.Update("User", props, false, false, false, false, false);

            // Assert
            Assert.Contains("UPDATE [User] SET Id = @Id, Name = @Name, Email = @Email WHERE Id = @Id", ret);
            Assert.Contains("db.Execute(sql, new { Id = user.Id, Name = user.Name, Email = user.Email }, commandType: CommandType.Text);", ret);
        }

        [Fact]
        public void GenerateUpdateAsync()
        {
            // Arrange
            var objUser = new User();
            IList<PropertyInfo> props = new List<PropertyInfo>(objUser.GetType().GetProperties());

            // Act
            var ret = DapperGenerator.Update("User", props, false, false, false, true, false);

            // Assert
            Assert.Contains("UPDATE [User] SET Id = @Id, Name = @Name, Email = @Email WHERE Id = @Id", ret);
            Assert.Contains("await db.ExecuteAsync(sql, new { Id = user.Id, Name = user.Name, Email = user.Email }, commandType: CommandType.Text);", ret);
        }

        [Fact]
        public void GenerateUpdateNoId()
        {
            // Arrange
            var objUser = new User();
            IList<PropertyInfo> props = new List<PropertyInfo>(objUser.GetType().GetProperties());

            // Act
            var ret = DapperGenerator.Update("User", props, false, false, true, false, false);

            // Assert
            Assert.Contains("UPDATE [User] SET Name = @Name, Email = @Email WHERE Id = @Id", ret);
            Assert.Contains("db.Execute(sql, new { Id = user.Id, Name = user.Name, Email = user.Email }, commandType: CommandType.Text);", ret);
        }

        [Fact]
        public void GenerateUpdateNoIdAsync()
        {
            // Arrange
            var objUser = new User();
            IList<PropertyInfo> props = new List<PropertyInfo>(objUser.GetType().GetProperties());

            // Act
            var ret = DapperGenerator.Update("User", props, false, false, true, true, false);

            // Assert
            Assert.Contains("UPDATE [User] SET Name = @Name, Email = @Email WHERE Id = @Id", ret);
            Assert.Contains("await db.ExecuteAsync(sql, new { Id = user.Id, Name = user.Name, Email = user.Email }, commandType: CommandType.Text);", ret);
        }
    }
}