using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcard.Model
{
    public class ClockTemplateSection : TemplateSection
    {
        public ClockQuestion.Interval MinimumInterval { get; set; }

        public override IAnswerable CreateQuestion()
        {
            return new ClockQuestion(MinimumInterval);
        }
    }
}