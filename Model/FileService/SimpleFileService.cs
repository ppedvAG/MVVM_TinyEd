using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_TinyEd.Model.FileService
{
    public class SimpleFileService
    {
        public string OpenFile(string Filename)
        {
            return File.ReadAllText(Filename);
        }

        public void SaveFile(string FileName, string Content)
        {
            File.WriteAllText(FileName, Content);
        }
    }
}
