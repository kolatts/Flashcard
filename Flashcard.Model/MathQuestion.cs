using System;

namespace Flashcard.Model
{
    public abstract class MathQuestion : Question
    {
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public int NumberOfFactors { get; set; } = 2;
        public int CorrectAnswerInt { get; set; }

        public override string CorrectAnswer
        {
            get
            {
                return CorrectAnswerInt.ToString();
            }
        }
        public MathQuestion(int minimum, int maximum, int numberOfFactors, AnswerType answerType)
        {
            if (minimum == maximum)
                throw new Exception("Minimum cannot be equal to maximum");
            if (Math.Abs(minimum - maximum) < 4 && answerType == AnswerType.MultipleChoice)
                throw new Exception("Cannot create multiple choice questions with range < 4");
            if (minimum > maximum)
            {
                var temporaryMinimum = minimum;
                minimum = maximum;
                maximum = temporaryMinimum;
            }
            Minimum = minimum;
            Maximum = maximum;
            NumberOfFactors = numberOfFactors;
            AnswerType = answerType;
        }
        public override bool? Answer(string userAnswer)
        {
            int parsedAnswer;
            if (int.TryParse(userAnswer, out parsedAnswer))
                return base.Answer(userAnswer);
            return null;
        }
        public abstract void GenerateChoices();
    }
}