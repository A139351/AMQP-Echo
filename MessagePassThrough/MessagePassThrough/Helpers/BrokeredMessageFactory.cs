using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;

namespace MessagePassThrough.Helpers
{
    public static class BrokeredMessageFactory
    {
        public static BrokeredMessage CreateJsonMessage<TPayload>(TPayload payload)
        {
            var serialisedPayload = JsonConvert.SerializeObject(payload);
            return new BrokeredMessage(serialisedPayload)
            {
               ContentType = "application/json"
            };
        }
    }
}