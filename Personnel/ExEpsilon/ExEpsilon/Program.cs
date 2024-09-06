using System.Diagnostics.Tracing;
using System.Linq;

namespace ExEpsilon
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<char, double> letterFrequencies = new Dictionary<char, double>
            {
                { 'A', 8.15 }, { 'B', 0.97 }, { 'C', 3.15 }, { 'D', 3.55 }, { 'E', 17.40 },
                { 'F', 1.05 }, { 'G', 1.30 }, { 'H', 1.20 }, { 'I', 7.35 }, { 'J', 0.61 },
                { 'K', 0.05 }, { 'L', 5.49 }, { 'M', 2.96 }, { 'N', 7.10 }, { 'O', 5.27 },
                { 'P', 3.02 }, { 'Q', 0.99 }, { 'R', 6.55 }, { 'S', 7.75 }, { 'T', 6.95 },
                { 'U', 6.35 }, { 'V', 1.02 }, { 'W', 0.04 }, { 'X', 0.45 }, { 'Y', 0.30 },
                { 'Z', 0.15 }
            };


            //Exemple
            List<string> words = new List<string> { "bonjour", "hello", "monde", "vert", "rouge", "bleu", "jaune" };

            List<(string Word, double Epsilon)> filteredWords = words
              .Select(word => (Word: word, Epsilon: CalculateEpsilon(word.ToUpper(), letterFrequencies)))
              .Where(result => result.Epsilon >= 0.5 && result.Epsilon <= 0.95)
              .ToList();

            filteredWords.ForEach(result =>
                Console.WriteLine($"{result.Word} - Epsilon: {result.Epsilon}")
            );



        }

        static double CalculateEpsilon(string word, Dictionary<char, double> letterFrequencies)
        {
            return word
                .GroupBy(letter => letter)
                .Sum(group => (letterFrequencies.ContainsKey(group.Key) ? letterFrequencies[group.Key] : 0.0) / 100 / group.Count());
        }
    }
}
