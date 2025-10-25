using Moore.Core.RequestDtos;

namespace Moore.Core.Entities
{
    public class MooreAlgorithm : Algorithm
    {
        private MooreAlgorithm() { }
        public MooreAlgorithm(SearchRequest request)
        {
            Name = "Boyer Moore search algorithm";
            Description = "Algorithm for search substring in string";

            Text = request.Text;
            Pattern = request.Pattern;

            for (int i = 0; i < Pattern.Length; i++)
            {
                PatternHashTable[Pattern[i]] = int.Max(1, Pattern.Length - i - 1);
            }
        }


        public string Text { get; set; } = default!;
        public string Pattern { get; set; } = default!;
        public Dictionary<char, int> PatternHashTable { get; set; } = [];
    }
}