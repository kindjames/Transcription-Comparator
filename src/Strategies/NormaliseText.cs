using System.Linq;

namespace TranscriptionComparator.Strategies
{
    public class NormaliseText : ITextManipulationStrategy
    {
        private static readonly ITextManipulationStrategy[] Strategies =
        {
            new RemoveExtraWhitespace(),
            new RemoveFillerWords(),
            new RemovePunctuation(),
            new RemoveUnintelligbleSpeech(),
            new RemovePadding(),
        };

        public string Perform(string input)
        {
            return Strategies.Aggregate(input,
                (current, strategy) => strategy.Perform(current));
        }
    }
}