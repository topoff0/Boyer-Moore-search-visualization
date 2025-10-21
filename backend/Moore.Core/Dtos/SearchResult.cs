using Moore.Core.Entities;

namespace Moore.Core.Dtos
{
    public class SearchResult
    {
        public SearchResult(bool found, int position, TimeSpan executionTime, List<SearchStep> steps)
        {
            Found = found;
            Position = position;
            ExecutionTime = executionTime;
            Steps = steps;
        }
        public bool Found { get; set; }
        public int Position { get; set; }
        public TimeSpan ExecutionTime { get; set; }
        List<SearchStep> Steps { get; set; } = [];
    }
}