namespace App
{
  public interface ICompletable
  {
    string getTextToDisplay();

    void markComplete();

    void markIncomplete();

    bool isComplete();
  }
}