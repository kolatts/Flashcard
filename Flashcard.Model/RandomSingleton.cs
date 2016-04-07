using System;

namespace Flashcard.Model
{
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
}