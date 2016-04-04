using System;

namespace TranscriptionComparator
{
    public interface IComparisonResultRenderer : IDisposable
    {
        void Render(ComparisonResult result);
    }
}