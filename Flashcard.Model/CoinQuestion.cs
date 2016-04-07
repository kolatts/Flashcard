using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcard.Model
{
    public class CoinQuestion  : Question
    {
        public override string Text => "How many cents?";

        public override string CorrectAnswer => Coins?.Select(x => x.Value)?.Sum().ToString();

        public List<Coin> Coins { get; set; }

        public CoinQuestion(int minNumberOfCoins, int maxNumberOfCoins)
        {
            var numberOfCoins = RandomSingleton.Instance.Random.Next(minNumberOfCoins, maxNumberOfCoins);
            Coins = new List<Coin>();
            for (var i = 0; i < numberOfCoins; i++)
            {
                Coins.Add(new Coin());
            }
        }
      

    }

    public class Coin
    {
        public Coin(bool random = true)
        {
            var rand = RandomSingleton.Instance.Random;
            Type = (CoinType)rand.Next((int) CoinType.Penny, (int) CoinType.HalfDollar);
        }

        public enum CoinType
        {
            Penny,
            Nickel,
            Dime,
            Quarter,
            HalfDollar
        }

        public CoinType Type { get; set; }

        public int Value
        {
            get
            {
                switch (Type)
                {
                    case CoinType.Penny:
                        return 1;
                    case CoinType.Nickel:
                        return 5;
                    case CoinType.Dime:
                        return 10;
                    case CoinType.Quarter:
                        return 25;
                    case CoinType.HalfDollar:
                        return 50;

                    default:
                        throw new ArgumentException($"Unknown {nameof(Type)} : {Type}");

                }
            }
        }
    }
}
