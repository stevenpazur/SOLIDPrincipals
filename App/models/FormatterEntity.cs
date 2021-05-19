using App.models;

namespace App
{
    public class FormatterEntity
    {
        public IFormatter Formatter { get; set; }

        public string format(Calendar calendar)
        {
            return Formatter.format(calendar);
        }
    }
}