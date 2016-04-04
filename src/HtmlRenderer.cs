using System.IO;

namespace TranscriptionComparator
{
    public class HtmlRenderer : IComparisonResultRenderer
    {
        private readonly TextWriter _stream;

        public HtmlRenderer(TextWriter stream)
        {
            _stream = stream;
            _stream.WriteLine("<html><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" /></head><body><table><tr><th>Text A</th><th>Text B</th><th>Delta</th><th>Levenshtein</th></tr>");
        }

        public void Render(ComparisonResult result)
        {
            _stream.WriteLine("<tr>");
            _stream.WriteLine("<td>");
            _stream.WriteLine(result.TextA);
            _stream.WriteLine("</td>");
            _stream.WriteLine("<td>");
            _stream.WriteLine(result.TextB);
            _stream.WriteLine("</td>");
            _stream.WriteLine("<td>");
            _stream.WriteLine(result.HtmlDelta);
            _stream.WriteLine("</td>");
            _stream.WriteLine("<td>");
            _stream.WriteLine(result.LevenshteinDistance);
            _stream.WriteLine("</td>");
            _stream.WriteLine("</tr>");
            _stream.Flush();
        }

        public void Dispose()
        {
            _stream.WriteLine("</body></html>");
            _stream.Flush();
            _stream.Dispose();
        }
    }
}