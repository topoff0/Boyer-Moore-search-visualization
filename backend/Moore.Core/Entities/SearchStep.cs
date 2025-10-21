namespace Moore.Core.Entities
{
    public class SearchStep
    {
        public SearchStep
        (
            int stepNumber,
            int textPointer,
            int patternPointer,
            string description,
            bool isMatch
        )
        {
            StepNumber = stepNumber;
            TextPointer = textPointer;
            PatternPointer = patternPointer;
            Description = description;
            IsMatch = isMatch;
        }

        public int StepNumber { get; set; }
        public int TextPointer { get; set; }
        public int PatternPointer { get; set; }
        public string Description { get; set; } = default!;
        public bool IsMatch { get; set; }
    }
}