using System;
using System.IO;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MessagePassThrough.Contracts;
using MessagePassThrough.Helpers;
using Microsoft.Azure.WebJobs;
using Microsoft.ServiceBus.Messaging;

namespace MessagePassThrough
{
    public class Functions
    {
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
        public static async Task ProcessQueueMessage(
            [ServiceBusTrigger("amqp-poc-inbount-digtoenterprise", AccessRights.Listen)] BrokeredMessage messageIn,
            [ServiceBus("amqp-poc-outbount-digtoenterprise", AccessRights.Send)] IAsyncCollector<BrokeredMessage> outputQueue,
            TextWriter log)
        {
            log.WriteLine(messageIn);

            var inputMessage = messageIn.ParseXmlMessageBody<InputMessage>();

            var outputMessage = new OutputMessage()
            {
                Message = "SUCCESSFULLY SENT!",
                TransactionId = inputMessage.TransactionId
            };

            var messageOut = new BrokeredMessage(outputMessage.Serialize());

            await outputQueue.AddAsync(messageOut);
        }
    }
}
