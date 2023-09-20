using HashtagSuggestion.KeywordExtractors;
using HashtagSuggestion.Preprocessors;

namespace HashtagSuggestion
{
    public class HashtagSuggestor
    {
        private readonly IContentPreprocessor _preprocessor;
        private readonly IKeywordExtractor _keywordExtractor;
        private readonly HashtagGenerator _hashtagGenerator;

        public HashtagSuggestor(IContentPreprocessor preprocessor, IKeywordExtractor keywordExtractor)
        {
            _preprocessor = preprocessor;
            _keywordExtractor = keywordExtractor;
            _hashtagGenerator = new HashtagGenerator();
        }

        public List<string> SuggestHashtags(string content)
        {
            var preprocessedContent = _preprocessor.Preprocess(content);
            var keywords = _keywordExtractor.ExtractKeywords(preprocessedContent);
            var hashtags = _hashtagGenerator.GenerateHashtags(keywords);

            return hashtags;
        }
    }
}
