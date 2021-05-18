using System;
using FluentAssertions;
using Xunit;

namespace App.Tests
{
    public class ReminderTest
    {
        [Fact]
        public void testICalendar()
        {
            var reminder1 = new Reminder(
                "Buy birthday hats",
                new DateTime(2028, 6, 7, 6, 9, 0));

            var expected = "BEGIN:VALARM\n" +
                           "TRIGGER:-2028-06-07T06:09\n" +
                           "ACTION:DISPLAY\n" +
                           $"UID:{reminder1.getUuid()}@example.com\n" +
                           "DESCRIPTION:Buy birthday hats\n" +
                           "END:VALARM\n";

            reminder1.iCalendar().Should().Be(expected);
        }

        [Fact]
        public void toStringWorks()
        {
            var reminder1 = new Reminder(
                "Buy birthday hats",
                new DateTime(2028, 6, 7, 6, 9, 0));

            reminder1.ToString().Should().Be("Buy birthday hats at Jun 7, 2028 6:09 AM (incomplete)");

            reminder1.markComplete();

            reminder1.ToString().Should().Be("Buy birthday hats at Jun 7, 2028 6:09 AM (complete)");
        }
    }
}