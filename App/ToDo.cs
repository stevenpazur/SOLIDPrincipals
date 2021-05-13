using System;
using System.Text;

namespace App
{
    public class Todo : CalendarItem {

        private string text;
        private string description;
        private TodoStatus status = TodoStatus.INCOMPLETE;
        private DateTime? completedAt;
        private string ownerFirstName;
        private string ownerLastName;
        private string ownerEmail;
        private string ownerJobTitle;

        public Todo(string text, string ownerFirstName, string ownerLastName, string ownerEmail, string ownerJobTitle) {
            this.text = text;
            this.ownerFirstName = ownerFirstName;
            this.ownerLastName = ownerLastName;
            this.ownerEmail = ownerEmail;
            this.ownerJobTitle = ownerJobTitle;
        }

        public string getText() {
            return text;
        }

        public override string getTextToDisplay() {
            return getText();
        }

        public void setDescription(string description) {
            this.description = description;
        }

        public string getDescription() {
            return description;
        }

        public override void markComplete() {
            status = TodoStatus.COMPLETE;
            completedAt = DateTime.Now;
        }

        public override void markIncomplete() {
            status = TodoStatus.INCOMPLETE;
            completedAt = null;
        }

        public override bool isComplete() {
            return status == TodoStatus.COMPLETE;
        }

        public DateTime? getCompletedAt() {
            return completedAt;
        }

        public string getOwnerFirstName() {
            return ownerFirstName;
        }

        public string getOwnerLastName() {
            return ownerLastName;
        }

        public string getOwnerJobTitle() {
            return ownerJobTitle;
        }

        public string getOwnerEmail() {
            return ownerEmail;
        }

        public override string iCalendar() {
            if (text == null) throw new ArgumentException("You must specify the text");

            return new StringBuilder()
                    .Append("BEGIN:VTODO\n")
                    .Append($"COMPLETED::{getCompletedAt()}\n")
                    .Append($"UID:{getUuid()}@example.com\n")
                    .Append($"SUMMARY:{getTextToDisplay()}\n")
                    .Append("END:VTODO\n")
                    .ToString();
        }

        public override string ToString() {
            var a = getText();
            var b = getOwnerFirstName();
            var c = getOwnerLastName();
            var d = getOwnerEmail();
            var e = getOwnerJobTitle();
            var f = status == TodoStatus.INCOMPLETE ? "incomplete" : "complete";

            return $"{a} <{b} {c}> {d} ({e}): {f}";
        }
    }
}
