using DBMS;
using Xunit;

namespace TestProjectForDBMS2
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }

        [Fact]
        public void TestIntColumnValidation1()
        {
            Column _column = new IntColumn("");
            Assert.True(_column.Validate("42"));
        }
    }
}