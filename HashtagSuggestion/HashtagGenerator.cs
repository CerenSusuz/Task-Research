namespace HashtagSuggestion
{
    public class HashtagGenerator
    {
        public List<string> GenerateHashtags(List<string> keywords)
        {
            // Convert the extracted keywords into hashtags
            return keywords.Select(keyword => $"#{keyword}").ToList();
        }
    }
}
