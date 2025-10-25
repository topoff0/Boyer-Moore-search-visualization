using Moore.Core.Entities;
using Moore.Core.ResultDtos;

namespace Moore.Core.Interfaces
{
    public interface IMooreService
    {
        public SearchResult Search(MooreAlgorithm moore);
    }
}