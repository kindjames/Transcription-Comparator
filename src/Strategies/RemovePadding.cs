namespace TranscriptionComparator.Strategies
{
    public class RemovePadding : ITextManipulationStrategy
    {
        public string Perform(string input)
        {
            return input.Trim();
        }
    }
}