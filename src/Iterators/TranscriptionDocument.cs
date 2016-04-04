using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TranscriptionComparator.Strategies;

namespace TranscriptionComparator.Iterators
{
    public class TranscriptionDocument : IEnumerable<string>
    {
        private readonly string _fileContents;
        private readonly NormaliseText _normaliser;

        public TranscriptionDocument(string fileContents)
        {
            _fileContents = fileContents;
            _normaliser = new NormaliseText();
        }

        public IEnumerator<string> GetEnumerator()
        {
            return Regex.Replace(_fileContents, "\r\n\\s*\r\n", "\r\n\r\n")
                .Replace("\r\n\r\n", "`")
                .Split('`')
                .Select(t => _normaliser.Perform(t))
                .Where(t => !String.IsNullOrWhiteSpace(t))
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}