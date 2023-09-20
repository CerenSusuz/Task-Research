namespace HashtagSuggestion.KeywordExtractors
{
    public class TfidfKeywordExtractor : IKeywordExtractor
    {
        public List<string> ExtractKeywords(List<string> preprocessedWords)
        {
            // Compute the term frequency for each word in the content
            var termFrequency = preprocessedWords.GroupBy(word => word)
                .ToDictionary(group => group.Key, group => (double)group.Count() / preprocessedWords.Count);

            // Compute the inverse document frequency for each word.
            // Note: Implement a function `GetDocumentFrequency` that retrieves the document frequency for a given word.
            var inverseDocumentFrequency = preprocessedWords.Distinct()
                .ToDictionary(word => word, word => Math.Log(GetDocumentFrequency(word)));

            // Compute the TF-IDF score for each word.
            var tfidf = termFrequency.ToDictionary(
                pair => pair.Key,
                pair => pair.Value * inverseDocumentFrequency[pair.Key]);

            // Sort the words by their TF-IDF scores in descending order and select the top N words.
            int topN = 5;
            var keywords = tfidf.OrderByDescending(pair => pair.Value).Take(topN).Select(pair => pair.Key).ToList();

            return keywords;
        }

        private double GetDocumentFrequency(string word)
        {
            // This is a simple example. In practice, you would retrieve the actual document frequency.
            // For example, retrieve the value from a database or an API.
            return 1.0;
        }
    }
}
