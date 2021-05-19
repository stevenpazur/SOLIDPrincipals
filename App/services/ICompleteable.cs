namespace App
{
    public interface ICompletable
    {
        //change back to TextToDisplay
        string getTitle();

        void markComplete();

        void markIncomplete();

        bool isComplete();
    }
}