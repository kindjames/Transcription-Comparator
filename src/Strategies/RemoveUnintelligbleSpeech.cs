using System;
using System.Text.RegularExpressions;

namespace TranscriptionComparator.Strategies
{
    public class RemoveUnintelligbleSpeech : ITextManipulationStrategy
    {
        private const string pattern = "(\\[.*?\\])|(\".*?\")|('.*?')|(\\(.*?\\))";

        public string Perform(string input)
        {
            return Regex.Replace(input, pattern, String.Empty, RegexOptions.IgnoreCase);
        }
    }
}