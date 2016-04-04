using System;
using System.Collections.Generic;

namespace TranscriptionComparator
{
    public class ComparisonResult
    {
        /// <summary>
        /// Group the interviewee belongs to.
        /// </summary>
        public int GroupNumber { get; set; }

        /// <summary>
        /// Name of interviewee.
        /// </summary>
        public string SubjectName { get; set; }

        /// <summary>
        /// Name of the question / prompt given to the interviewee.
        /// </summary>
        public string PromptName { get; set; }

        public string TextA { get; set; }
        public string TextB { get; set; }
        public int LevenshteinDistance { get; set; }
        public List<Diff> Differences { get; set; }
        public int TotalUnitsCount => Math.Max(TextA?.Length ?? 0, TextB?.Length ?? 0);
        public string HtmlDelta { get; set; }
    }
}