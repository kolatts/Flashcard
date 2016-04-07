using System;
using System.Collections.Generic;
namespace Flashcard.Model
{
    public class Quiz
    {
        private QuizTemplate template;
        public Quiz()
        {


        }

        public Quiz(bool julian)
        {
            
            if (julian)
                template = new QuizTemplate()
                {
                    Sections = new List<MathTemplateSection>()
                    {
                        new MathTemplateSection() { Minimum = 0, Maximum = 9, NumberOfFactors = 2, Subject = Subject.Addition, NumberOfQuestions = 2 },
                        //new MathTemplateSection() { Minimum = 0, Maximum = 9, NumberOfFactors = 2, Subject = MathSubject.Subtraction, NumberOfQuestions = 2 }
                    }
                };
            else
                template = new QuizTemplate()
                {
                    Sections = new List<MathTemplateSection>()
                    {
                        new MathTemplateSection() { Minimum = 0, Maximum = 8, NumberOfFactors = 2, Subject = Subject.Addition, NumberOfQuestions = 2 },
                        new MathTemplateSection() { Minimum = 0, Maximum = 8, NumberOfFactors = 2, Subject = Subject.Subtraction, NumberOfQuestions = 2 }
                    }
                };
            Questions = new List<IAnswerable>();
            GenerateMoreQuestions();
            TimePermitted = TimeSpan.FromMinutes(3);
        }

        public void GenerateMoreQuestions()
        {
                foreach (var section in template.Sections)
                {
                    Questions.AddRange(section.CreateQuestions());
                }
        }

        public enum CompletionType 
        {
            Time,
            Question
        }

        public CompletionType Completion { get; set; }

        public Quiz(QuizTemplate template)
        {
            
        }

        public List<IAnswerable> Questions {get;set;}

        public DateTimeOffset? Started {get;set;}

        public DateTimeOffset? Finished { get; set; }



        public string TimeInSeconds 
        { 
            get 
            { 
                return TimeElapsed == null ? string.Empty : Math.Floor(TimeElapsed.Value.TotalSeconds) + "s";
            } 
        }
        public TimeSpan? TimeElapsed
        {
            get
            {
                if (Started == null)
                    return null;
                if (Finished != null)
                    return Finished.Value - Started.Value;
                return DateTimeOffset.Now - Started;
            }
        }
        public TimeSpan TimePermitted  {get;set;}

        public TimeSpan TimeRemaining {
            get { 
                if (TimeElapsed == null)
                    return TimePermitted;
                return TimePermitted - TimeElapsed.Value;}
            }
    }
}

