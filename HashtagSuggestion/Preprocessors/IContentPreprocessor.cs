namespace HashtagSuggestion.Preprocessors
{
    public interface IContentPreprocessor
    {
        List<string> Preprocess(string content);
    }
}
