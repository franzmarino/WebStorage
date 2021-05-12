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
            string key = @"DefaultEndpointsProtocol=https;AccountName=archivoseduardo;AccountKey=Xco90YT7AAzWImXX5cGAj+4+tOwwQArcJp9TiTJSgNPbRwlJnyyAPis+5kYK66jQJLvgA56rKRNsmHuxQ1TPmA==;EndpointSuffix=core.windows.net";
            string share = "archivos";
            root = new ShareClient(key, share);
            
        }

        public List<string> AllFiles()
        {
            List<string> FileNames = new List<string>();
            var files=root.GetRootDirectoryClient().GetFilesAndDirectories();
            foreach (var item in files)
            {
                var tipo = " (archivo)";
                if (item.IsDirectory) tipo =" (Carpeta)";
                FileNames.Add(item.Name+tipo);
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