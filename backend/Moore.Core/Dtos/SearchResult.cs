namespace Moore.Core.Dtos
{
    public class SearchResult
    {
        public bool Found { get; set; }
        public int Position { get; set; }
        public TimeSpan ExecutionTime { get; set; }
    }
}