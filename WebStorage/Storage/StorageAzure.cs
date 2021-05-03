using Azure.Storage.Files.Shares;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebStorage.Storage
{
    public class StorageAzure : IStorage
    {
        ShareClient root;
        public StorageAzure()
        {
            string keys = @"DefaultEndpointsProtocol=https;AccountName=apisegura;AccountKey=vRc7MEYYp4aN1viy4iTkPNmAW7UjnWLX/iEyMmskynmRrHCIRuMKnRKCbUMeUt5AdQ0hkWUdO84LXoBWQ9kX7Q==;EndpointSuffix=core.windows.net";
            string share = "data";
            root = new ShareClient(keys, share);
            
        }

        public List<string> AllFiles()
        {
            List<string> FileNames = new List<string>();
            var files=root.GetRootDirectoryClient().GetFilesAndDirectories();
            foreach (var item in files)
            {
                FileNames.Add(item.Name);
            }
            return FileNames;
        }

        public void UploadFile(string name, Stream file)
        {
            ShareFileClient shareFile = root.GetRootDirectoryClient().GetFileClient(name);
            shareFile.Create(file.Length);
            shareFile.Upload(file);
        }
    }
}