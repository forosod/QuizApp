using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using QuizApp.Models;

namespace QuizApp
{
    public partial class Form1 : Form
    {
        QuizApiClient? _client;
        List<MultipleChoiceQuestion> _questions = new();
        int _currentIndex = -1;
        int _correctCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        override protected void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _client = QuizApiClient.Create();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var apiQuestions = await _client!.GetQuizQuestionsAsync();

                _questions.Clear();

                foreach (var q in apiQuestions)
                {
                    var mc = new MultipleChoiceQuestion(q.Question, q.CorrectAnswer, q.IncorrectAnswers);
                    _questions.Add(mc);
                }

                _currentIndex = 0;
                _correctCount = 0;
                UpdateScoreLabel();
                DisplayCurrentQuestion();

                // Log first question to file
                if (_questions.Count > 0)
                    File.WriteAllText("latest_question.txt", _questions[0].QuestionText);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Fel vid hämtning av frågor: " + ex.Message);
            }
        }

        private void DisplayCurrentQuestion()
        {
            if (_currentIndex < 0 || _currentIndex >= _questions.Count)
            {
                labelQuestion.Text = "Inga fler frågor. Klicka Start Quiz för att hämta nya.";
                // Disable option buttons if no question
                buttonOption1.Enabled = false;
                buttonOption2.Enabled = false;
                buttonOption3.Enabled = false;
                buttonOption4.Enabled = false;
                buttonNext.Enabled = false;
                return;
            }

            var q = _questions[_currentIndex];
            labelQuestion.Text = q.GetDisplayText();

            // Assign options to buttons
            var opts = q.Options;
            buttonOption1.Text = opts.Count > 0 ? opts[0] : string.Empty;
            buttonOption2.Text = opts.Count > 1 ? opts[1] : string.Empty;
            buttonOption3.Text = opts.Count > 2 ? opts[2] : string.Empty;
            buttonOption4.Text = opts.Count > 3 ? opts[3] : string.Empty;

            // Enable option buttons
            buttonOption1.Enabled = true;
            buttonOption2.Enabled = true;
            buttonOption3.Enabled = true;
            buttonOption4.Enabled = true;

            buttonNext.Enabled = false;
        }

        private void optionButton_Click(object? sender, EventArgs e)
        {
            if (sender is not Button btn) return;
            if (_currentIndex < 0 || _currentIndex >= _questions.Count) return;

            var q = _questions[_currentIndex];

            // Disable options
            buttonOption1.Enabled = false;
            buttonOption2.Enabled = false;
            buttonOption3.Enabled = false;
            buttonOption4.Enabled = false;

            var chosen = btn.Text;
            bool correct = q.IsCorrect(chosen);
            if (correct)
            {
                _correctCount++;
                btn.BackColor = Color.LightGreen;
            }
            else
            {
                btn.BackColor = Color.LightCoral;
                // highlight correct
                foreach (var b in new[] { buttonOption1, buttonOption2, buttonOption3, buttonOption4 })
                {
                    if (b.Text == q.CorrectAnswer)
                        b.BackColor = Color.LightGreen;
                }
            }

            // Save log
            var logLine = $"{DateTime.UtcNow:o} | Q: {q.QuestionText} | Chosen: {chosen} | Correct: {q.CorrectAnswer}" + Environment.NewLine;
            File.AppendAllText("quiz_log.txt", logLine);

            UpdateScoreLabel();
            buttonNext.Enabled = true;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            // reset button colors
            foreach (var b in new[] { buttonOption1, buttonOption2, buttonOption3, buttonOption4 })
                b.BackColor = SystemColors.Control;

            _currentIndex++;
            UpdateScoreLabel();
            DisplayCurrentQuestion();

            // Save results
            File.WriteAllText("results.json", System.Text.Json.JsonSerializer.Serialize(new { Correct = _correctCount, Total = _questions.Count }));
        }

        private void UpdateScoreLabel()
        {
            labelScore.Text = $"Rätt: {_correctCount} / {_questions.Count}";
        }
    }
}
