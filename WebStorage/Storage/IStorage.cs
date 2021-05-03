using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStorage.Storage
{
    public interface IStorage
    {
        List<String> AllFiles();
        void UploadFile(string name,Stream file);
    }
}
