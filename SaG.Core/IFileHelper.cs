using System.Text;

namespace SaG.Core
{
    public interface IFileHelper
    {
        string[] ReadAllLines(string path);

        string[] ReadAllLines(string path, Encoding encoding);

        bool Exists(string path);
    }
}