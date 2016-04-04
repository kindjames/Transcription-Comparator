using System;
using System.Text.RegularExpressions;

namespace TranscriptionComparator.Strategies
{
    public class RemovePunctuation : ITextManipulationStrategy
    {
        private const string pattern = @"[^\w\s\.\?]";

        public string Perform(string input)
        {
            return Regex.Replace(input, pattern, String.Empty, RegexOptions.IgnoreCase);
        }
    }
}