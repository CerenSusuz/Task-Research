using System.Text.RegularExpressions;

namespace HashtagSuggestion.Preprocessors
{
    internal class BasicPreprocessor : IContentPreprocessor
    {
        public List<string> Preprocess(string content)
        {
            // Implement tokenization and basic preprocessing logic
            string[] words = Regex.Replace(content.ToLower(), @"\W+", " ").Split(' ');
            return words.Where(word => !IsStopWord(word)).ToList();
        }

        private bool IsStopWord(string word)
        {
            // Implement a simple check for stopwords
            // You would usually use a predefined list of stopwords or a library here
            string[] stopwords = { "a", "an", "the", "and", "in", "on", "at" };
            return stopwords.Contains(word);
        }
    }
}
