using HashtagSuggestion.Preprocessors;
using HashtagSuggestion.KeywordExtractors;
using HashtagSuggestion;

class Program
{
    public static void Main(string[] args)
    {
        IContentPreprocessor preprocessor = new BasicPreprocessor();
        IKeywordExtractor keywordExtractor = new TfidfKeywordExtractor();
        HashtagSuggestor suggestor = new HashtagSuggestor(preprocessor, keywordExtractor);

        Console.Write("Enter your post content: ");
        string content = Console.ReadLine();

        List<string> hashtags = suggestor.SuggestHashtags(content);

        DisplayHashtags(hashtags);
    }

    static void DisplayHashtags(List<string> hashtags)
    {
        foreach (string hashtag in hashtags)
        {
            Console.WriteLine(hashtag);
        }
    }
}