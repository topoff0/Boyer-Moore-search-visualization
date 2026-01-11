namespace Moore.Core.Entities
{
    public record SearchStep(
        int StepNumber,
        int TextPointer,
        int PatternPointer,
        string Description,
        bool IsMatch
    );
}
