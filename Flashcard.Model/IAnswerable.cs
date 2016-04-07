using System;
using System.Collections.Generic;

namespace Flashcard.Model
{
	public interface IAnswerable
	{
         string Text { get; }
         string CorrectAnswer { get; }

         List<string> Choices { get; set; }
        bool? Answer(string userAnswer);
        DateTimeOffset? Started { get; set; }
        DateTimeOffset? Ended { get; set; }
         string TimeInSeconds {get;}
         TimeSpan? CompletionTime {get;}
        bool AnsweredCorrectly { get; set; }

	}
}

