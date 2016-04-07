using System;
using System.Collections.Generic;
namespace Flashcard.Model
{
    public class QuizTemplateSection
    {
        public QuizTemplateSection()
        {
        }

        public int Minimum {get;set;}
        public int Maximum {get;set;}

        public AnswerType AnswerType {get;set;}

        public int NumberOfFactors {get;set;}

        public MathSubject Subject {get;set;}

        public int NumberOfQuestions {get;set;}


        public List<IAnswerable> CreateQuestions() 
        {
            var list = new List<IAnswerable>();
            for (var i = 0; i < NumberOfQuestions; i++)
            {
                list.Add(CreateQuestion());
            }
            return list;
        }

        protected IAnswerable CreateQuestion()
        {
            switch (Subject)
            {
                case MathSubject.Addition:
                    return new AdditionQuestion(Minimum, Maximum, NumberOfFactors, AnswerType);
                case MathSubject.Subtraction:
                    return new SubtractionQuestion(Minimum, Maximum, NumberOfFactors, AnswerType);
                case MathSubject.Multiplication:
                    return new MultiplicationQuestion(Minimum, Maximum, NumberOfFactors, AnswerType);
                case MathSubject.Division:
                    return new DivisionQuestion(Minimum, Maximum, NumberOfFactors, AnswerType);
                default:
                    throw new ArgumentException("Subject not accounted for.");
            }
        }
    }
}

