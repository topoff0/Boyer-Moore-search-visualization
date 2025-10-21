using Moore.Core.Dtos;
using Moore.Core.Entities;

namespace Moore.Core.Interfaces
{
    public interface IMoorService
    {
        public SearchResult Search(MooreAlgorithm moore);
    }
}