namespace App
{
    public interface ICompletable
    {
        string getTitle();

        void markComplete();

        void markIncomplete();

        bool isComplete();
    }
}