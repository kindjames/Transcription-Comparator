using System;
using System.Text.RegularExpressions;

namespace TranscriptionComparator.Strategies
{
    public class RemoveFillerWords : ITextManipulationStrategy
    {
        private const string pattern = "\\b(uh|um|mm|em|er|ha)\\b";

        public string Perform(string input)
        {
            return Regex.Replace(input, pattern, String.Empty, RegexOptions.IgnoreCase);
        }
    }
}