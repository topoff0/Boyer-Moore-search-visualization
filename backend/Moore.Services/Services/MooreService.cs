using Moore.Core.Dtos;
using Moore.Core.Entities;
using Moore.Core.Interfaces;

namespace Moore.Services.Services
{
    public class MooreService : IMoorService
    {
        public SearchResult Search(MooreAlgorithm moore)
        {
            if (!IsDataValid(moore.Text, moore.Pattern))
                return new SearchResult(false, -1, new TimeSpan(0), []);

            DateTime startTime = DateTime.Now;

            int textLength = moore.Text.Length;
            int patternLength = moore.Pattern.Length;

            List<SearchStep> steps = [];
            int stepNumber = 1;

            int textPointer = patternLength - 1;
            int patternPointer = patternLength - 1;

            while (textPointer < textLength)
            {
                while (moore.Text[textPointer] == moore.Pattern[patternPointer] && patternPointer >= 0)
                {
                    steps.Add
                    (
                        new SearchStep
                        (stepNumber,
                        textPointer,
                        patternPointer,
                        $"Match on step: {stepNumber}",
                        true)
                    );

                }
            }
        }

        private static bool IsDataValid(string Text, string Pattern)
        {
            return !string.IsNullOrEmpty(Text)
                    && !string.IsNullOrEmpty(Pattern)
                    && Pattern.Length < Text.Length;
        }
    }
}