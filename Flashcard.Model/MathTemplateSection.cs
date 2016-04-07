using System;

namespace Flashcard.Model
{
    public class MathTemplateSection : TemplateSection
    {
        public MathTemplateSection()
        {
        }

        public int Minimum { get; set; }
        public int Maximum { get; set; }

        public int NumberOfFactors { get; set; }

        public override IAnswerable CreateQuestion()
        {
            switch (Subject)
            {
                case Subject.Addition:
                    return new AdditionQuestion(Minimum, Maximum, NumberOfFactors, AnswerType);

                case Subject.Subtraction:
                    return new SubtractionQuestion(Minimum, Maximum, NumberOfFactors, AnswerType);

                case Subject.Multiplication:
                    return new MultiplicationQuestion(Minimum, Maximum, NumberOfFactors, AnswerType);

                case Subject.Division:
                    return new DivisionQuestion(Minimum, Maximum, NumberOfFactors, AnswerType);

                default:
                    throw new ArgumentException("Subject not accounted for.");
            }
        }
    }
}