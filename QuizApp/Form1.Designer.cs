namespace QuizApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            labelQuestion = new Label();
            buttonOption1 = new Button();
            buttonOption2 = new Button();
            buttonOption3 = new Button();
            buttonOption4 = new Button();
            buttonNext = new Button();
            labelScore = new Label();
            SuspendLayout();
            // 
            // button1 (Load Quiz)
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(100, 30);
            button1.TabIndex = 0;
            button1.Text = "Start Quiz";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // labelQuestion
            // 
            labelQuestion.Location = new Point(12, 60);
            labelQuestion.Name = "labelQuestion";
            labelQuestion.Size = new Size(600, 60);
            labelQuestion.TabIndex = 1;
            labelQuestion.Text = "Frågan visas här";
            // 
            // buttonOption1
            // 
            buttonOption1.Location = new Point(12, 140);
            buttonOption1.Name = "buttonOption1";
            buttonOption1.Size = new Size(290, 40);
            buttonOption1.TabIndex = 2;
            buttonOption1.Text = "Option 1";
            buttonOption1.UseVisualStyleBackColor = true;
            buttonOption1.Click += optionButton_Click;
            // 
            // buttonOption2
            // 
            buttonOption2.Location = new Point(322, 140);
            buttonOption2.Name = "buttonOption2";
            buttonOption2.Size = new Size(290, 40);
            buttonOption2.TabIndex = 3;
            buttonOption2.Text = "Option 2";
            buttonOption2.UseVisualStyleBackColor = true;
            buttonOption2.Click += optionButton_Click;
            // 
            // buttonOption3
            // 
            buttonOption3.Location = new Point(12, 200);
            buttonOption3.Name = "buttonOption3";
            buttonOption3.Size = new Size(290, 40);
            buttonOption3.TabIndex = 4;
            buttonOption3.Text = "Option 3";
            buttonOption3.UseVisualStyleBackColor = true;
            buttonOption3.Click += optionButton_Click;
            // 
            // buttonOption4
            // 
            buttonOption4.Location = new Point(322, 200);
            buttonOption4.Name = "buttonOption4";
            buttonOption4.Size = new Size(290, 40);
            buttonOption4.TabIndex = 5;
            buttonOption4.Text = "Option 4";
            buttonOption4.UseVisualStyleBackColor = true;
            buttonOption4.Click += optionButton_Click;
            // 
            // buttonNext
            // 
            buttonNext.Location = new Point(512, 260);
            buttonNext.Name = "buttonNext";
            buttonNext.Size = new Size(100, 30);
            buttonNext.TabIndex = 6;
            buttonNext.Text = "Nästa fråga";
            buttonNext.UseVisualStyleBackColor = true;
            buttonNext.Click += buttonNext_Click;
            // 
            // labelScore
            // 
            labelScore.Location = new Point(12, 260);
            labelScore.Name = "labelScore";
            labelScore.Size = new Size(200, 30);
            labelScore.TabIndex = 7;
            labelScore.Text = "Rätt: 0 / 0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 320);
            Controls.Add(labelScore);
            Controls.Add(buttonNext);
            Controls.Add(buttonOption4);
            Controls.Add(buttonOption3);
            Controls.Add(buttonOption2);
            Controls.Add(buttonOption1);
            Controls.Add(labelQuestion);
            Controls.Add(button1);
            Name = "Form1";
            Text = "QuizApp";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Label labelQuestion;
        private Button buttonOption1;
        private Button buttonOption2;
        private Button buttonOption3;
        private Button buttonOption4;
        private Button buttonNext;
        private Label labelScore;
    }
}
