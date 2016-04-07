using System;
using System.Collections.Generic;
using System.Linq;
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

    public enum AnswerType
    {
        Freeform,
        MultipleChoice
    }

    public enum MathSubject
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

    public abstract class MathQuestion : Question
    {
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public int NumberOfFactors { get; set; } = 2;
        public int CorrectAnswerInt { get; set; }

        public override string CorrectAnswer
        {
            get
            {
                return CorrectAnswerInt.ToString();
            }
        }
        public MathQuestion(int minimum, int maximum, int numberOfFactors, AnswerType answerType)
        {
            if (minimum == maximum)
                throw new Exception("Minimum cannot be equal to maximum");
            if (Math.Abs(minimum - maximum) < 4 && answerType == AnswerType.MultipleChoice)
                throw new Exception("Cannot create multiple choice questions with range < 4");
            if (minimum > maximum)
            {
                var temporaryMinimum = minimum;
                minimum = maximum;
                maximum = temporaryMinimum;
            }
            Minimum = minimum;
            Maximum = maximum;
            NumberOfFactors = numberOfFactors;
            AnswerType = answerType;
        }
        public override bool? Answer(string userAnswer)
        {
            int parsedAnswer;
            if (int.TryParse(userAnswer, out parsedAnswer))
                return base.Answer(userAnswer);
            return null;
        }
        public abstract void GenerateChoices();
    }


    public class RandomSingleton
    {
        private static readonly RandomSingleton instance = new RandomSingleton();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static RandomSingleton()
        {
        }

        private RandomSingleton()
        {
            random = new Random();
        }

        public static RandomSingleton Instance
        {
            get
            {
                return instance;
            }
        }

        private Random random;
        public Random Random {get { return random; } set { random = value; }}
    }
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

    public class MultiplicationQuestion : MathQuestion
    {
        protected List<int> Factors { get; set; }
        public override string Text
        => Factors.Select(x=> x.ToString()).Aggregate((x,y) => x + " x " + y) + " = ?";
        public MultiplicationQuestion(int minimum, int maximum, int numberOfFactors, AnswerType answerType)
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

