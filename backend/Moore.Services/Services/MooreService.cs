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

            while (textPointer < textLength)
            {
                int currentTextPointer = textPointer;
                int patternPointer = patternLength - 1;

                while (patternPointer >= 0 &&
                       moore.Text[currentTextPointer] == moore.Pattern[patternPointer])
                {
                    steps.Add(new SearchStep(
                        stepNumber++,
                        currentTextPointer,
                        patternPointer,
                        $"Match on step {stepNumber}: true",
                        true));

                    currentTextPointer--;
                    patternPointer--;
                }

                if (patternPointer < 0)
                {
                    finishTime = DateTime.Now;
                    return new SearchResult(true, currentTextPointer + 1, finishTime - startTime, steps);
                }

                steps.Add(new SearchStep(
                stepNumber,
                currentTextPointer,
                patternPointer,
                $"Match on step {stepNumber++}: false",
                false));

                char mismatchChar = moore.Text[currentTextPointer];

                if (!moore.ShiftTable.TryGetValue(mismatchChar, out int shift))
                    shift = patternLength;

                textPointer += Math.Max(1, shift);
            }

            finishTime = DateTime.Now;
            return new SearchResult(false, -1, finishTime - startTime, steps);
        }

        private static bool IsDataValid(string Text, string Pattern)
        {
            return !string.IsNullOrEmpty(Text)
                && !string.IsNullOrEmpty(Pattern)
                && Pattern.Length <= Text.Length;
        }
    }
}
