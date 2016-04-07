using System.Collections.Generic;
using System.Linq;

namespace Flashcard.Model
{
    public class AdditionQuestion : MathQuestion
    {
        protected List<int> Addends { get; set; }
        public override string Text
            => Addends.Select(x=> x.ToString()).Aggregate((x,y) => x + " + " + y) + " = ?";
        public AdditionQuestion(int minimum, int maximum, int numberOfFactors, AnswerType answerType)
            :base(minimum, maximum, numberOfFactors, answerType)
        {
            Addends = new List<int>();
            while (Addends.Count < numberOfFactors)
            {
                Addends.Add(RandomSingleton.Instance.Random.Next(minimum, maximum));
            }
            CorrectAnswerInt = Addends.Sum();
        }


        public override void GenerateChoices()
        {
            int? createdAnswer;
            while (Choices.Count < 4)
            {
                createdAnswer = RandomSingleton.Instance.Random.Next(Minimum) + RandomSingleton.Instance.Random.Next(Maximum);
                if (Choices.All(x=> x != createdAnswer.ToString()))
                {
                    Choices.Add(createdAnswer.ToString());
                }
            }
        } 



    }
}