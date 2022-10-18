using Azure.Storage.Queues;
using System;

namespace MSAzureStorageQueueSender
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "ConnectString Or SAS Token";
            string queueName = "QueueName";

            QueueClient client = new QueueClient(connectionString, queueName);

            client.CreateIfNotExists();

            if (client.Exists())
            {
                for (int i = 0; i < 500; i++)
                {
                    client.SendMessage($"Test Queue Message {i}");

                    Console.WriteLine($"Test Queue Message {i}");
                }
            }

            Console.ReadLine();
        }
    }
}
