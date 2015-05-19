using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebRole1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

         BlobStorageServices blobStorageService = new BlobStorageServices();
         QueueStorageServices queueStorageSerive = new QueueStorageServices();

        public ActionResult Upload()
        {
            CloudBlobContainer blobContainer = blobStorageService.GetCloudBlobContainer();
            List<string> blobs = new List<string>();
            foreach (var blobItem in blobContainer.ListBlobs())
            {
                blobs.Add(blobItem.Uri.ToString());
            }
            return View(blobs);
        }


        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase receipt)
        {
            if (receipt == null) return RedirectToAction("Upload");
            if (receipt.ContentLength > 0)
            {
                CloudBlobContainer blobContrainer = blobStorageService.GetCloudBlobContainer();
                CloudBlockBlob blob = blobContrainer.GetBlockBlobReference(receipt.FileName);
                blob.UploadFromStream(receipt.InputStream);

                CloudQueue queue = queueStorageSerive.GetCloudQueueContainer();
                CloudQueueMessage message = new CloudQueueMessage(blob.Uri.AbsoluteUri);
                queue.AddMessage(message);
            }
            return RedirectToAction("Upload");
        }
   

        [HttpPost]
        public void DeleteReceipt(string name)
        {
            Uri uri = new Uri(name);
            string filename = System.IO.Path.GetFileName(uri.LocalPath);
            CloudBlobContainer blobContainer = blobStorageService.GetCloudBlobContainer();
            CloudBlockBlob blob = blobContainer.GetBlockBlobReference(filename);
            blob.Delete();
        }
    }
}
