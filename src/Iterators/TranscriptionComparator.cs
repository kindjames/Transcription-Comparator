using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TranscriptionComparator.Iterators
{
    public class TranscriptionComparator : IEnumerable<ComparisonResult>
    {
        private static readonly diff_match_patch DiffMatchPatch = new diff_match_patch();
        private readonly TranscriptionDocument _transcriptionSectionsA;
        private readonly TranscriptionDocument _transcriptionSectionsB;

        public TranscriptionComparator(string transcriptionFilePathA, string transcriptionFilePathB)
        {
            _transcriptionSectionsA = new TranscriptionDocument(transcriptionFilePathA);
            _transcriptionSectionsB = new TranscriptionDocument(transcriptionFilePathB);
        }

        public IEnumerator<ComparisonResult> GetEnumerator()
        {
            var transcriptionLines = _transcriptionSectionsA.Zip(_transcriptionSectionsB,
                (a, b) => new Tuple<string, string>(a, b));

            foreach (var line in transcriptionLines)
            {
                var differences = DiffMatchPatch.diff_main(line.Item1, line.Item2);

                DiffMatchPatch.diff_cleanupEfficiency(differences);

                DiffMatchPatch.diff_cleanupSemanticLossless(differences);

                differences = CleanupCasingIssues(differences).ToList();

                yield return new ComparisonResult
                {
                    TextA = line.Item1,
                    TextB = line.Item2,
                    Differences = differences,
                    HtmlDelta = DiffMatchPatch.diff_prettyHtml(differences),
                    LevenshteinDistance = DiffMatchPatch.diff_levenshtein(differences),
                };
            }
        }

        private static IEnumerable<Diff> CleanupCasingIssues(List<Diff> differences)
        {
            for (var i = 0; differences.Count > i; i++)
            {
                var current = differences[i];

                if (current.operation == Operation.DELETE && (i + 1) < differences.Count)
                {
                    var next = differences[i + 1];
                    if (next.operation == Operation.INSERT)
                    {
                        if (String.Compare(next.text.Trim(), current.text.Trim(), StringComparison.OrdinalIgnoreCase) == 0)
                        {
                            yield return new Diff(Operation.EQUAL, current.text);

                            i++; // step over next
                            continue;
                        }
                    }
                }

                yield return current;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}