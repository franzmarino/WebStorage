using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebStorage.Storage
{
    public class BlobStorage : IStorage
    {
        BlobContainerClient blobContainer;
        public BlobStorage()
        {
            string key = @"DefaultEndpointsProtocol=https;AccountName=archivoseduardo;AccountKey=Xco90YT7AAzWImXX5cGAj+4+tOwwQArcJp9TiTJSgNPbRwlJnyyAPis+5kYK66jQJLvgA56rKRNsmHuxQ1TPmA==;EndpointSuffix=core.windows.net";
            string blobName = "archivos";
            var blobService = new BlobServiceClient(key);
            blobContainer=blobService.GetBlobContainerClient(blobName);

        }
        public List<string> AllFiles()
        {
            List<string> allfiles=new List<string>();
            var files = blobContainer.GetBlobs();
            foreach (var item in files)
            {
                allfiles.Add(item.Name);
            }
            return allfiles;
        }

        public void UploadFile(string name, Stream file)
        {
            blobContainer.UploadBlob(name, file);
        }
    }
}