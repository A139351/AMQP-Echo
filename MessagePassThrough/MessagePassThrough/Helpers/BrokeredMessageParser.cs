using System;
using System.IO;
using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;

namespace MessagePassThrough.Helpers
{
    public static class BrokeredMessageParser
    {
        public static ParseJsonMessageResult<TMessageBody> ParseJsonMessageBody<TMessageBody>(this BrokeredMessage message)
            where TMessageBody : class
        {
            string messageBody;
            try
            {
                messageBody = message.GetBody<string>();
            }
            catch(Exception)
            {
                return ParseJsonMessageResult<TMessageBody>.Failure(string.Empty, "Failed to Deserialise body into string");
            }
            
            if (string.IsNullOrEmpty(messageBody))
            {
                return ParseJsonMessageResult<TMessageBody>.Failure(string.Empty, "Empty body string, expected JSON body");
            }
            try
            {
                var settings = new JsonSerializerSettings { MissingMemberHandling = MissingMemberHandling.Error };
                var bodyObject = JsonConvert.DeserializeObject<TMessageBody>(messageBody, settings);
                return ParseJsonMessageResult<TMessageBody>.Success(bodyObject, messageBody);

            }
            catch (Exception)
            {
                return ParseJsonMessageResult<TMessageBody>.Failure(messageBody, "Failed to parse JSON body");
            }
        }

        public static TMessageBody ParseXmlMessageBody<TMessageBody>(this BrokeredMessage message)
        {
            var stream = message.GetBody<Stream>();
            var reader = new StreamReader(stream);
            var bodyString = reader.ReadToEnd();

            return bodyString.Deserialize<TMessageBody>();
        }
    }

}