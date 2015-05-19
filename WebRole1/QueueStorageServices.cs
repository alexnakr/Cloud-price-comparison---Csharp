using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebRole1
{
    public class QueueStorageServices
    {
        public CloudQueue GetCloudQueueContainer()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            //Retrieve a reference to a queue
            CloudQueue queue = queueClient.GetQueueReference("receiptqueue");

            queue.CreateIfNotExists();
            return queue;
        }
    }
}