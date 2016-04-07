using System.Collections.Generic;
using System.Linq;

namespace Flashcard.Model
{
    public class DivisionQuestion : MathQuestion
    {
        protected List<int> Factors { get; set; }
        public override string Text
            => Factors.Select(x=> x.ToString()).Aggregate((x,y) => x + " / " + y) + " = ?";
        public DivisionQuestion(int minimum, int maximum, int numberOfFactors, AnswerType answerType)
            :base(minimum, maximum, numberOfFactors, answerType)
        {
            Factors = new List<int>();
            Factors.Add(RandomSingleton.Instance.Random.Next(minimum, maximum));
            while (Factors.Count < numberOfFactors)
            {
                Factors.Add(RandomSingleton.Instance.Random.Next(minimum, maximum));
            }
            CorrectAnswerInt = Factors.Aggregate((x, y) => x * y);
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