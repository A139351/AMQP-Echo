using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using MessagePassThrough.Contracts;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using XMLLibrary;

namespace MessagePassThrough
{
    // To learn more about Microsoft Azure WebJobs SDK, please see https://go.microsoft.com/fwlink/?LinkID=320976
    public class Program
    {
        //// Please set the following connection strings in app.config for this WebJob to run:
        //// AzureWebJobsDashboard and AzureWebJobsStorage
        public static void Main()
        {
            var config = new JobHostConfiguration();

            if (config.IsDevelopment)
            {
                config.UseDevelopmentSettings();
            }

            var serviceBusConfig = new ServiceBusConfiguration
            {
                ConnectionString = ConfigurationManager
                    .ConnectionStrings["Microsoft.ServiceBus.ConnectionString"].ConnectionString
            };

            config.UseServiceBus(serviceBusConfig);

            var host = new JobHost(config);
            // The following code ensures that the WebJob will be running continuously
            host.RunAndBlock();


        }

    }
}
