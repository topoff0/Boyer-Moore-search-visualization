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

            ShiftTable = BuildShiftTable(request.Pattern);
        }


        public string Text { get; set; }
        public string Pattern { get; set; }
        public Dictionary<char, int> ShiftTable { get; set; } = [];
        

        private static Dictionary<char, int> BuildShiftTable(string pattern)
        {
            Dictionary<char, int> result = [];
            for (int i = 0; i < pattern.Length; i++)
            {
               result[pattern[i]] = int.Max(1, pattern.Length - i - 1);
            }
            return result;
        }
    }
}
