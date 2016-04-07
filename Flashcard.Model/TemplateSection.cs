using System.Collections.Generic;

namespace Flashcard.Model
{
    public abstract class TemplateSection : ITemplateSection
    {
        public int NumberOfQuestions { get; set; }
        public AnswerType AnswerType { get; set; }
        public Subject Subject { get; set; }

        public virtual List<IAnswerable> CreateQuestions()
        {
            var list = new List<IAnswerable>();
            for (var i = 0; i < NumberOfQuestions; i++)
            {
                list.Add(CreateQuestion());
            }
            return list;
        }

        public abstract IAnswerable CreateQuestion();
    }
}