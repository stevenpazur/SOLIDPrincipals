using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace App.Tests
{
    public class CalendarTest
    {
        [Fact]
        public void itSchedulesThingsCorrectly()
        {
            var twoHours = new TimeSpan(2, 0, 0);

            var event1 = new Event(
                "My birthday party",
                new DateTime(2028, 6, 7, 8, 9, 0),
                twoHours);

            var reminder1 = new Reminder(
                "Buy birthday hats",
                new DateTime(2028, 6, 7, 6, 9, 0));

            var reminder2 = new Reminder(
                "Clean up house",
                new DateTime(2028, 6, 8, 6, 9, 0));

            var calendar = new Calendar();

            calendar.addSchedulable(event1);
            calendar.addSchedulable(reminder1);
            calendar.addSchedulable(reminder2);

            calendar.items().Should().ContainInOrder(new List<CalendarItem> {reminder1, event1, reminder2});
        }

        [Fact]
        public void itFormatsThingsCorrectly()
        {
            var twoHours = new TimeSpan(2, 0, 0);

            var event1 = new Event(
                "My birthday party",
                new DateTime(2028, 6, 7, 8, 9, 0),
                twoHours);

            var reminder1 = new Reminder(
                "Buy birthday hats",
                new DateTime(2028, 6, 7, 6, 9, 0));

            var calendar = new Calendar();

            calendar.addSchedulable(event1);
            calendar.addSchedulable(reminder1);

            var expected = "June\n" +
                           "1 2 3 4 5 6 7* 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 \n" +
                           "\n";

            calendar.format().Should().Be(expected);
        }
    }
}