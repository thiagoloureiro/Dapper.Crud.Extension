using Dapper.Crud.VSExtension.Helpers;
using Xunit;

namespace Dapper.Crud.Tests
{
    public class ModelTest
    {
        [Fact]
        public void TypeList()
        {
            var ret = ModelHelper.Types();
            Assert.True(ret.Count > 0);
        }
    }
}