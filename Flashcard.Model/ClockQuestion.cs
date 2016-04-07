using System;

namespace Flashcard.Model
{
    public class ClockQuestion : Question
    {
        public override string Text => "What is the time?";
        public override string CorrectAnswer => $"{Hour}:{Minutes}";

        public int Hour { get; set; }

        public int Minutes { get; set; }

        public enum Interval
        {
            FiveMinutes,
            FifteenMinutes,
            ThirtyMinutes,
            SixtyMinutes
        }

        public Interval MinimumInterval { get; set; }

        public ClockQuestion(Interval minimumInterval)
        {
            MinimumInterval = minimumInterval;
            var rand = RandomSingleton.Instance.Random;
            Hour = rand.Next(1, 12);
            Minutes = GetMinutes();
        }

        protected  int GetMinutes()
        {
            var rand = RandomSingleton.Instance.Random;
            switch (MinimumInterval)
            {
                case Interval.FiveMinutes:
                    return 5 * rand.Next(0,11);
                case Interval.FifteenMinutes:
                    return 15 * rand.Next(0,3);
                case Interval.ThirtyMinutes:
                    return 30 * rand.Next(0,1);
                case Interval.SixtyMinutes:
                    return 0;
                default: throw new ArgumentException($"Unknown {nameof(Interval)} : {MinimumInterval}");
            }
        }

    }
}
