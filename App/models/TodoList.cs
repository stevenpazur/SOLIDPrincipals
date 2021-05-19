using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App
{
  public class TodoList
  {
    private readonly List<ICompletable> completables = new();

    public void add(ICompletable completable)
    {
      completables.Add(completable);
    }

    public List<ICompletable> all()
    {
      return completables;
    }

    public List<ICompletable> completed()
    {
      return completables.Where(c => c.isComplete()).ToList();
    }

    public List<ICompletable> uncompleted()
    {
      return completables.Where(c => !c.isComplete()).ToList();
    }

    public void completeAll()
    {
      completables.ForEach(c => c.markComplete());
    }

    public void uncompleteAll()
    {
      completables.ForEach(c => c.markIncomplete());
    }

    public override string ToString()
    {
      var builder = new StringBuilder();

      completables.ForEach(completable =>
      {
        if (completable.isComplete())
          builder.Append("√ ");
        else
          builder.Append("□ ");

        builder.Append(completable.getTitle()).Append("\n");
      });

      return builder.ToString();
    }
  }
}