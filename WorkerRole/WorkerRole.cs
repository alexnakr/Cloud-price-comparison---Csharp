using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Blob;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using ZXing;
using ZXing.Common;
using System.Drawing;
using System.Xml;
using WebRole1.Models;
using System.Xml.Serialization;
using System.IO;
using System.Data.Common;

namespace WorkerRole
{
    public class WorkerRole : RoleEntryPoint
    {

        private CloudQueue messageQueue;
        private CloudBlobContainer receiptStorage;
        private CloudQueueMessage msg;
        private bool onStopCalled = false;
        private ApplicationDbContext db;
        public override void Run()
        {
            while (true)
            {
                try
                {
                    bool messageFound = false;
                    if (onStopCalled == true)
                    {
                        return;
                    }
                    msg = messageQueue.GetMessage();

                    if (msg != null)
                    {
                        ProccessQueueMessage(msg);
                        messageFound = true;
                    }
                    if (messageFound == false)
                    {
                        System.Threading.Thread.Sleep(1000 * 20);
                    }
                }
                catch (Exception ex)
                {
                    string err = ex.Message;
                    if (ex.InnerException != null)
                    {
                        err += "Inner Exception: " + ex.InnerException.Message;
                    }
                    if (msg != null)
                    {
                        err += "Last queue message retrieved: " + msg.AsString;
                    }
                    System.Threading.Thread.Sleep(1000 * 20);
                }
            }
        }

        private void ProccessQueueMessage(CloudQueueMessage msg)
        {
            if (msg.DequeueCount > 5)
            {
                Trace.TraceError("Deleting poison message: message {0}.", msg.ToString());
                messageQueue.DeleteMessage(msg);
                return;
            }
            ConvertQRtoXml(msg.AsString);
            messageQueue.DeleteMessage(msg);
        }

        public override bool OnStart()
        {
            //Maximum connections
            ServicePointManager.DefaultConnectionLimit = 12;
            //Instantiate DB context
            db = new ApplicationDbContext();
            db.Database.Initialize(true);

            var storageAccount = CloudStorageAccount.Parse(RoleEnvironment.GetConfigurationSettingValue("StorageConnectionString"));
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            this.messageQueue = queueClient.GetQueueReference("receiptqueue");

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            this.receiptStorage = blobClient.GetContainerReference("receipts");

            messageQueue.CreateIfNotExists();
            receiptStorage.CreateIfNotExists();
            return base.OnStart();
        }

        public void ConvertQRtoXml(String uri)
        {
            try
            {
                WebRequest request = System.Net.WebRequest.Create(uri);
                WebResponse response = request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                Bitmap bitmap = new Bitmap(responseStream);
                try
                {
                    BarcodeReader reader = new BarcodeReader { AutoRotate = true, TryHarder = true };
                    Result result = reader.Decode(bitmap);
                    XmlDocument xm = new XmlDocument();
                    xm.LoadXml(result.Text);
                  //  Receipt receipt = null;
                  //  XmlSerializer ser = new XmlSerializer(typeof(Receipt));
                  //  receipt = (Receipt)ser.Deserialize(new StringReader(xm.OuterXml));
                  //  db.Receipts.Add(receipt);
                    Store store = new Store();
                    
                    store.Name = "test111111";
                    store.Latitude = 2;
                    store.Longitude = 3;
                    try
                    {
                        db.Stores.Add(store);
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        e.ToString();
                    }
                }
                catch
                {
                    throw new Exception("Cannot decode the QR code");
                }
            }
            catch (System.Net.WebException)
            {
                throw new Exception("There was an error opening the image file." + "Check the URL");
            }
        }
    }
}
