using System.Collections.Generic;

namespace Flashcard.Model
{
    public interface ITemplateSection
    {
        int NumberOfQuestions { get; set; }
        AnswerType AnswerType { get; set; }
        Subject Subject { get; set; }
        List<IAnswerable> CreateQuestions();
    }
}