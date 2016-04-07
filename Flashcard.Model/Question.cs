using System;
using System.Collections.Generic;

namespace Flashcard.Model
{
    public abstract class Question : IAnswerable
    {
        public abstract string Text { get; }
        public virtual string CorrectAnswer { get; }
        public string UserAnswer { get; set; }
        public bool AnsweredCorrectly { get; set; }
        public AnswerType AnswerType { get; set; }
        public List<string> Choices {get;set;}

        public virtual bool? Answer (string userAnswer)
        {
            var correct =  this.CorrectAnswer == userAnswer;
            UserAnswer = userAnswer;
            Ended = DateTimeOffset.Now;
            AnsweredCorrectly = correct;
            return correct;
        }


        public DateTimeOffset? Started { get; set; }
        public DateTimeOffset? Ended { get; set; }
        public string TimeInSeconds { 
            get 
            { 
                if (Started == null)
                    return string.Empty;
                if (Ended != null)
                    return (Math.Floor((Ended.Value - Started.Value).TotalSeconds)).ToString() + "s";
                return (Math.Floor((DateTimeOffset.Now - Started.Value).TotalSeconds)).ToString() + "s";
            } 
        }

        public TimeSpan? CompletionTime {
            get {
                if (Started == null || Ended == null)
                    return null;
                return Ended.Value - Started.Value;
            }
        }
    }
}