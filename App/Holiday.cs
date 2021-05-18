using System;
using System.Text;

namespace App
{
  public class Holiday : CalendarItem
  {
    private readonly TimeSpan duration;
    private readonly DateTime startsAt;
    public override string title { get; set; }
    public Holiday(string title, DateTime startsAt, TimeSpan duration)
    {
      this.title = title;
      this.startsAt = startsAt;
      this.duration = duration;
    }
    public DateTime EndsAt => startsAt + duration;


    public string getTitle()
    {
      return title;
    }

    public string getTextToDisplay()
    {
      return getTitle();
    }

    public DateTime getStartsAt()
    {
      return startsAt;
    }

    public TimeSpan getDuration()
    {
      return duration;
    }

    public DateTime getEndsAt()
    {
      return startsAt + getDuration();
    }

    public override string iCalendar()
    {
      if (title == null) return null;

      return new StringBuilder()
        .Append("BEGIN:VHOLIDAY\n")
        .Append($"DTSTART:{getStartsAt().ToString("yyyy-MM-ddThh:mm")}\n")
        .Append($"DTEND:{getEndsAt().ToString("yyyy-MM-ddThh:mm")}\n")
        .Append($"UID:{getUuid()}@example.com\n")
        .Append($"DESCRIPTION:{getTextToDisplay()}\n")
        .Append("END:VHOLIDAY\n")
        .ToString();
    }

    public override string ToString()
    {
      var a = getTitle();
      var b = getStartsAt().ToString(DATE_FORMATTER);
      var c = getEndsAt().ToString(DATE_FORMATTER);
      return $"{a} at {b} (ends at {c})";
    }
  }
}