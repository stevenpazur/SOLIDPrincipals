using App.models;
using Xunit;
using FluentAssertions;
using System;

namespace App.Tests
{
    public class ScheduleFormatterTest
    {
        [Fact]
        public void TestName()
        {
            //Given
            var calendar = new Calendar();
            var event1 = new Event("Event 1", new DateTime(2020, 10, 20), new TimeSpan(1, 0, 0));
            calendar.addSchedulable(event1);
            var scheduleFormatter = new ScheduleFormatter();
            //When
            var result = scheduleFormatter.format(calendar);
            //Then
            result.Should().Contain("10/20/2020 12:00:00 AM\n - Event 1 at Oct 20, 2020 12:00 AM (ends at Oct 20, 2020 1:00 AM)");
        }
    }
}