namespace Moore.Services.Main
{
    public static class Moor
    {
        public static void FillHashTable(Dictionary<char, int> table, string lookingWord)
        {
            for (int i = 0; i < lookingWord.Length; i++)
            {
                table[c] = lookingWord.Length - i - 1;
            }
        }

        public static List<int> GetAllIndexes(string input, Dictionary<char, int> table, string lookingWord)
        {
            List<int> result = [];
            for (int i = lookingWord.Length - 1; i >= 0; i--)
            {
                if
            }
        }
    }
}