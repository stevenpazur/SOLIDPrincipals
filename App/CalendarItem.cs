using System;

namespace App
{
  public abstract class CalendarItem
  {
    public static string DATE_FORMATTER = "MMM d, yyyy h:mm tt";
    private readonly string uuid;
    public abstract string title { get; set; }
    public CalendarItem()
    {
      uuid = Guid.NewGuid().ToString();
    }
    public string getUuid()
    {
      return uuid;
    }
    public abstract string iCalendar();
  }
}