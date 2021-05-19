using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace App.Tests
{
    public class ExportServiceTest
    {
        [Fact]
        public void itExportsEverything()
        {
            var twoHours = new TimeSpan(2, 0, 0);

            var event1 = new Event(
                "My birthday party",
                new DateTime(2028, 6, 7, 8, 9, 0),
                twoHours);

            var reminder1 = new Reminder(
                "Buy birthday hats",
                new DateTime(2028, 6, 7, 6, 9, 0));

            var todo1 = new Todo("Do stuff", new Owner("Alex", "Hamilton", "alex@example.com", "Treasurer"));

            var expected = "BEGIN:VCALENDAR\n" +
                           "VERSION:2.0\n\n" +
                           "BEGIN:VEVENT\n" +
                           "DTSTART:2028-06-07T08:09\n" +
                           "DTEND:2028-06-07T10:09\n" +
                           $"UID:{event1.getUuid()}@example.com\n" +
                           "DESCRIPTION:My birthday party\n" +
                           "END:VEVENT\n\n" +
                           "BEGIN:VALARM\n" +
                           "TRIGGER:-2028-06-07T06:09\n" +
                           "ACTION:DISPLAY\n" +
                           $"UID:{reminder1.getUuid()}@example.com\n" +
                           "DESCRIPTION:Buy birthday hats\n" +
                           "END:VALARM\n\n" +
                           "BEGIN:VTODO\n" +
                           "COMPLETED::\n" +
                           $"UID:{todo1.getUuid()}@example.com\n" +
                           "SUMMARY:Do stuff\n" +
                           "END:VTODO\n" +
                           "END:VCALENDAR";

            List<CalendarItem> items = new() {event1, reminder1, todo1};

            var actual = new ExportService().export(items);

            actual.Should().Be(expected);
        }
    }
}