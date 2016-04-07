using System.Collections.Generic;
using System.Linq;

namespace Flashcard.Model
{
    public class SubtractionQuestion : MathQuestion
    {
        protected List<int> Subtractants { get; set; }
        public override string Text
            => Subtractants.Select(x=> x.ToString()).Aggregate((x,y) => x + " - " + y) + " = ?";
        public SubtractionQuestion(int minimum, int maximum, int numberOfFactors, AnswerType answerType)
            :base(minimum, maximum, numberOfFactors, answerType)
        {
            Subtractants = new List<int>();
            Subtractants.Add(RandomSingleton.Instance.Random.Next(minimum, maximum));
            while (Subtractants.Count < numberOfFactors)
            {
                Subtractants.Add(RandomSingleton.Instance.Random.Next(0, Subtractants[0] - Subtractants.Skip(1).Sum()));
            }
            CorrectAnswerInt = Subtractants[0] - Subtractants.Skip(1).Sum();
        }


        public override void GenerateChoices()
        {
            int? createdAnswer;
            while (Choices.Count < 4)
            {
                createdAnswer = RandomSingleton.Instance.Random.Next(Minimum, Maximum);
                if (Choices.All(x=> x != createdAnswer.ToString()))
                {
                    Choices.Add(createdAnswer.ToString());
                }
            }
        } 
    }
}