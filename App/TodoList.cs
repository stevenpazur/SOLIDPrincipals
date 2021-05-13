using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace App
{
    public class TodoList {

        private List<ICompletable> completables = new List<ICompletable>();

        public void add(ICompletable completable) {
            completables.Add(completable);
        }

        public List<ICompletable> all() {
            return completables;
        }

        public List<ICompletable> completed() {
            return completables.Where(c => c.isComplete()).ToList();
        }

        public List<ICompletable> uncompleted() {
            return completables.Where(c => !c.isComplete()).ToList();
        }

        public void completeAll() {
            completables.ForEach(c => c.markComplete());
        }

        public void uncompleteAll() {
            completables.ForEach(c => c.markIncomplete());
        }

        public override string ToString() {
            StringBuilder builder = new StringBuilder();

            completables.ForEach(completable => {
                if (completable.isComplete()) {
                    builder.Append("√ ");
                } else {
                    builder.Append("□ ");
                }

                builder.Append(completable.getTextToDisplay()).Append("\n");
            });

            return builder.ToString();
        }
    }
}
