namespace App
{
    public interface ICompletable
    {
        //change back to TextToDisplay
        string TextToDisplay();

        void markComplete();

        void markIncomplete();

        bool isComplete();
    }
}