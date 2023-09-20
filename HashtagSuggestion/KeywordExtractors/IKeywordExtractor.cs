namespace HashtagSuggestion.KeywordExtractors
{
    public interface IKeywordExtractor
    {
        List<string> ExtractKeywords(List<string> preprocessedWords);
    }
}
