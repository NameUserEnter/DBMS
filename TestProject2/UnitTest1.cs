using DBMS;
using Xunit;
namespace TestProject2
{
    public class UnitTest1
    {
        private Column _column;

        [Fact]
        public void TestIntColumnValidation1()
        {
            _column = new IntColumn("", "INT");
            Assert.True(_column.Validate("8779"));
        }

        [Fact]
        public void TestIntColumnValidation2()
        {
            _column = new IntColumn("", "INT");
            Assert.False(_column.Validate("dlsvdlv"));
        }

        [Fact]
        public void TestRealColumnValidation1()
        {
            _column = new RealColumn("", "REAL");
            Assert.True(_column.Validate("48,95"));
        }

        [Fact]
        public void TestRealColumnValidation2()
        {
            _column = new RealColumn("","REAL");
            Assert.False(_column.Validate("38d70"));
        }

        [Fact]
        public void TestCharColumnValidation1()
        {
            _column = new CharColumn("", "CHAR");
            Assert.True(_column.Validate("K"));
        }

        [Fact]
        public void TestCharColumnValidation2()
        {
            _column = new CharColumn("", "CHAR");
            Assert.False(_column.Validate("wvnlkndn"));
        }

        [Fact]
        public void TestStringColumnValidation()
        {
            _column = new StringColumn("", "STRING");
            Assert.True(_column.Validate("str"));
        }

        [Fact]
        public void TestRealIntervalColumnValidation1()
        {
            _column = new RealIntervalColumn("", "REAL INTERVAL");
            Assert.True(_column.Validate("5,77 9,58"));
        }

        [Fact]
        public void TestRealIntervalColumnValidation2()
        {
            _column = new RealIntervalColumn("", "REAL INTERVAL");
            Assert.False(_column.Validate("9,77 5,58"));
        }

    }
    public class TestProjection
    {
        [Fact]
        private void TestRepeatedRows1()
        {
            var database = new Database("");
            var table = new Table("");
            var column1 = new IntColumn("C1","INT");
            var column2 = new StringColumn("C2","STRING");
            var column3 = new CharColumn("C3","CHAR");
            var row1 = new Row
            {
                Values = new List<object> { "30", "abc", "W" }
            };
            var row2 = new Row
            {
                Values = new List<object> { "30", "abc", "W" }
            };
            var row3 = new Row
            {
                Values = new List<object> { "30", "abc", "W" }
            };
            database.Tables.Add(table);
            database.Tables[0].Columns.Add(column1);
            database.Tables[0].Columns.Add(column2);
            database.Tables[0].Columns.Add(column3);
            database.Tables[0].Rows.Add(row1);
            database.Tables[0].Rows.Add(row2);
            database.Tables[0].Rows.Add(row3);

            Manager manager = new Manager();
            manager.db = database;
            var testProjection = manager.RepeatedRows(0);
            Assert.Equal(database.Tables[0].Rows.Count, 1);
        }

    }
}