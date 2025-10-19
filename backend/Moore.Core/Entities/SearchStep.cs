namespace Moore.Core.Entities
{
    public class SearchStep
    {
        public int StepNumber { get; set; }
        public int TextPointer { get; set; }
        public int PatternPointer { get; set; }
        public string Description { get; set; } = default!;
        public bool IsMatch { get; set; }
    }
}