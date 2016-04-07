namespace Flashcard.Model
{
    public class CoinTemplateSection : TemplateSection
    {
        public int MinimumCoins { get; set; }
        public int MaximumCoins { get; set; }

        public override IAnswerable CreateQuestion()
        {
            return new CoinQuestion(MinimumCoins, MaximumCoins);
        }
    }
}