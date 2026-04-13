using System;

namespace QuizApp.Models;

public class MultipleChoiceQuestion : BaseQuestion
{
    public List<string> Options { get; }
    public string CorrectAnswer { get; }

    public MultipleChoiceQuestion(string questionText, string correctAnswer, List<string> incorrectAnswers)
        : base(questionText)
    {
        CorrectAnswer = correctAnswer;
        Options = new List<string>(incorrectAnswers) { correctAnswer };
        // Shuffle options for display
        var rng = new Random();
        for (int i = Options.Count - 1; i > 0; i--)
        {
            int j = rng.Next(i + 1);
            var tmp = Options[i];
            Options[i] = Options[j];
            Options[j] = tmp;
        }
    }

    public override string GetDisplayText() => QuestionText;

    public bool IsCorrect(string answer) => string.Equals(answer, CorrectAnswer, StringComparison.OrdinalIgnoreCase);
}
