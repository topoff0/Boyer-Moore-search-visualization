using Moore.Core.Entities;
using Moore.Core.Interfaces;
using Moore.Core.ResultDtos;

namespace Moore.Services.Services
{
    public class MooreService : IMooreService
    {
        public SearchResult Search(MooreAlgorithm moore)
        {
            if (!IsDataValid(moore.Text, moore.Pattern))
                return new SearchResult(false, -1, new TimeSpan(0), []);

            DateTime startTime = DateTime.Now;
            DateTime finishTime;

            int textLength = moore.Text.Length;
            int patternLength = moore.Pattern.Length;

            List<SearchStep> steps = [];
            int stepNumber = 1;

            int textPointer = patternLength - 1;
            int patternPointer = patternLength - 1;

            while (textPointer < textLength)
            {
                while (patternPointer >= 0 && moore.Text[textPointer] == moore.Pattern[patternPointer])
                {
                    steps.Add(new SearchStep(
                        stepNumber,
                        textPointer,
                        patternPointer,
                        $"Match on step: {stepNumber}",
                        true));

                    patternPointer--;
                    textPointer--;
                    stepNumber++;
                }

                if (patternPointer < 0)
                {
                    finishTime = DateTime.Now;
                    return new SearchResult(true, textPointer, finishTime - startTime, steps);
                }

                steps.Add(new SearchStep(
                stepNumber,
                textPointer,
                patternPointer,
                $"Match on step: {stepNumber}",
                false));

                if (!moore.PatternHashTable.TryGetValue(moore.Text[textPointer], out int value))
                    textPointer += patternLength;
                else
                    textPointer += value;

                patternPointer = patternLength - 1;
            }

            finishTime = DateTime.Now;
            return new SearchResult(false, textLength - 1, finishTime - startTime, steps);
        }

        private static bool IsDataValid(string Text, string Pattern)
        {
            return !string.IsNullOrEmpty(Text)
                    && !string.IsNullOrEmpty(Pattern)
                    && Pattern.Length < Text.Length;
        }
    }
}
