using Moore.Core.Entities;

namespace Moore.Core.ResultDtos
{
    public record SearchResult(
        bool Found,
        int Position,
        TimeSpan ExecutionTime,
        List<SearchStep> Steps
    );
}
