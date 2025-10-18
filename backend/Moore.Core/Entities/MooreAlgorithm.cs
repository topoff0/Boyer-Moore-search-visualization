using Moore.Core.Dtos;

namespace Moore.Core.Entities
{
    public class MooreAlgorithm : Algorithm
    {
        private MooreAlgorithm() { }
        public MooreAlgorithm(MooreDto dto)
        {
            Input = dto.Input;
            LookingWord = dto.LookingWord;
        }


        public string Input { get; set; } = default!;
        public string LookingWord { get; set; } = default!;
        public Dictionary<char, int> HashWordTable { get; set; } = [];
    }
}