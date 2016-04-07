using System;
using System.Collections.Generic;
namespace Flashcard.Model
{
    public class QuizTemplate
    {
        public QuizTemplate()
        {

        }

     
        public string Name {get;set;}

        public List<QuizTemplateSection> Sections {get;set;}


    }
}

