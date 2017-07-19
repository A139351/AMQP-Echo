namespace MessagePassThrough.Helpers
{
    public class ParseJsonMessageResult<TMessage> where TMessage : class
    {
        private ParseJsonMessageResult(TMessage message, string rawData, string additionalInfo = "")
        {
            ParsedMessage = message;
            RawData = rawData;
            AdditionalInfo = additionalInfo;
        }

        public TMessage ParsedMessage { get; }
        public string RawData { get; }
        public string AdditionalInfo { get; }
        public bool IsSuccess => ParsedMessage != null;

        public static ParseJsonMessageResult<TMessage> Success(TMessage result, string rawData)
        {
            return new ParseJsonMessageResult<TMessage>(result, rawData);
        }

        public static ParseJsonMessageResult<TMessage> Failure(string rawData, string additionalInfo = "")
        {
            return new ParseJsonMessageResult<TMessage>(null, rawData, additionalInfo);
        }

    }
}