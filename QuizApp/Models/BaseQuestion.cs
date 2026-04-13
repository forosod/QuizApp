namespace QuizApp.Models;

public abstract class BaseQuestion
{
    public string QuestionText { get; protected set; }

    public BaseQuestion(string questionText)
    {
        QuestionText = questionText;
    }

    // Polymorphic display hook; UI can call this to get the text to display
    public virtual string GetDisplayText() => QuestionText;
}
