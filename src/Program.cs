using System;
using System.Diagnostics;
using System.IO;

namespace TranscriptionComparator
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please select comparison and press ENTER:");
            Console.WriteLine("A: English");
            Console.WriteLine("B: Chinese");

            var selection = Console.ReadLine();

            var args = new[]
            {
                Transcriptions.en_Interrating_Lucy,
                Transcriptions.en_Interrating_William
            };

            if (String.Compare(selection, "B", StringComparison.OrdinalIgnoreCase) == 0)
            {
                args = new[]
                {
                    Transcriptions.ch_Interrating_Lucy,
                    Transcriptions.ch_Interrating_Kang
                };
            }

            var savePath = $"Comparison_{DateTime.Now.Ticks}.html";

            var stopwatch = Stopwatch.StartNew();

            using (var renderer = new HtmlRenderer(File.CreateText(savePath)))
            {
                foreach (var result in new Iterators.TranscriptionComparator(args[0], args[1]))
                {
                    renderer.Render(result);
                }
            }

            Console.WriteLine($"Completed in {stopwatch.Elapsed}");
            Console.ReadLine();
        }
    }
}