using System;
using Xunit;
using System.Collections.Generic;
using FluentAssertions;

namespace App.Tests
{
    public class ExportServiceTest
    {
        [Fact]
        public void itExportsEverything() {
            var twoHours = new TimeSpan(2, 0, 0);

            Event event1 = new Event(
                "My birthday party",
                new DateTime(2028, 6, 7, 8, 9, 0),
                twoHours);

            Reminder reminder1 = new Reminder(
                "Buy birthday hats",
                new DateTime(2028, 6, 7, 6, 9, 0));

            Todo todo1 = new Todo("Do stuff", "Alex", "Hamilton", "alex@example.com", "Treasurer");

            string expected = "BEGIN:VCALENDAR\n" +
                "VERSION:2.0\n" +
                "BEGIN:VEVENT\n" +
                "DTSTART:2028-06-07T08:09\n" +
                "DTEND:2028-06-07T10:09\n" +
                $"UID:{event1.getUuid()}@example.com\n" +
                "DESCRIPTION:My birthday party\n" +
                "END:VEVENT\n" +
                "BEGIN:VALARM\n" +
                "TRIGGER:-2028-06-07T06:09\n" +
                "ACTION:DISPLAY\n" +
                $"UID:{reminder1.getUuid()}@example.com\n" +
                "DESCRIPTION:Buy birthday hats\n" +
                "END:VALARM\n" +
                "BEGIN:VTODO\n" +
                "COMPLETED::\n" +
                $"UID:{todo1.getUuid()}@example.com\n" +
                "SUMMARY:Do stuff\n" +
                "END:VTODO\n" +
                "END:VCALENDAR\n";

            List<CalendarItem> items = new List<CalendarItem>{event1, reminder1, todo1};

            string actual = new ExportService().export(items);

            actual.Should().Be(expected);
        }
    }
}
