using System.Text.RegularExpressions;

namespace TranscriptionComparator.Strategies
{
    public class RemoveExtraWhitespace : ITextManipulationStrategy
    {
        public string Perform(string input)
        {
            return Regex.Replace(input, " +", " ");
        }
    }
}