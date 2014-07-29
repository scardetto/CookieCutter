using FluentAssertions;
using NUnit.Framework;

namespace CookieCutter.Tests
{
    [TestFixture]
    public class ColumnSetTester
    {
        [Test]
        public void should_build_columns()
        {
            var record = new ColumnSet();
            record.AddConstant("PID=");
            record.AddColumn("PresenterID", 6, ColumnType.Numeric);
            record.AddPadding(1);
            record.AddColumn("PresenterPassword", 8);
            record.AddPadding(1);
            record.AddConstant("SID=");
            record.AddColumn("SubmitterID", 6, ColumnType.Numeric);
            record.AddPadding(1);
            record.AddColumn("SubmitterPassword", 8);
            record.AddPadding(1);
            record.AddConstant("START");
            record.AddPadding(2);
            record.AddColumn("FileCreatedDate", 6, ColumnType.Numeric);
            record.AddPadding(1);
            record.AddConstant("3.0.0");
            record.AddPadding(1);
            record.AddColumn("SubmissionNumber", 11);
            record.AddPadding(41);
            record.AddColumn("FileID", 8);

            record.RecordLength.Should().Be(120);
        }
    }
}
