using System.IO;
using System.Text;

namespace SaG.Core
{
    public class FileHelper : IFileHelper
    {
        public string[] ReadAllLines(string path)
        {
            return File.ReadAllLines(path);
        }

        public string[] ReadAllLines(string path, Encoding encoding)
        {
            return File.ReadAllLines(path, encoding);
        }

        public bool Exists(string path)
        {
            return File.Exists(path);
        }
    }
}
