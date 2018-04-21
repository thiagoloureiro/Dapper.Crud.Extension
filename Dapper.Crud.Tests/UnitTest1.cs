using Dapper.Crud.VSExtension.Helpers;
using Xunit;

namespace Dapper.Crud.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void GenerateSelect()
        {
            var ret = DapperGenerator.Select("ModelTest");
            Assert.True(ret.Contains("SELECT * FROM [ModelTest]"));
            Assert.True(ret.Contains("ret = db.Query<ModelTest>(sql, commandType: CommandType.Text).ToList();"));
        }
    }
}