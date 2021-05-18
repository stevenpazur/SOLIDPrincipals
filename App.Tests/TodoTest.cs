using FluentAssertions;
using Xunit;

namespace App.Tests
{
    public class TodoTest
    {
        [Fact]
        public void testICalendar()
        {
            var todo1 = new Todo("Do stuff", new Owner("Alex", "Hamilton", "alex@example.com", "Treasurer"));

            var expected = "BEGIN:VTODO\n" +
                           "COMPLETED::\n" +
                           $"UID:{todo1.getUuid()}@example.com\n" +
                           "SUMMARY:Do stuff\n" +
                           "END:VTODO\n";

            todo1.iCalendar().Should().Be(expected);
        }

        [Fact]
        public void toStringWorks()
        {
            var todo1 = new Todo("Do stuff", new Owner("Alex", "Hamilton", "alex@example.com", "Treasurer"));

            todo1.ToString().Should().Be("Do stuff <Alex Hamilton> alex@example.com (Treasurer): incomplete");

            todo1.markComplete();

            todo1.ToString().Should().Be("Do stuff <Alex Hamilton> alex@example.com (Treasurer): complete");
        }
    }
}