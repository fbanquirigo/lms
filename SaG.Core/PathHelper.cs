using System.IO;

namespace SaG.Core
{
    public class PathHelper : IPathHelper
    {
        public string Combine(string path1, string path2)
        {
            return Path.Combine(path1, path2);
        }

        public string Combine(string path1, string path2, string path3)
        {
            return Path.Combine(path1, path2, path3);
        }

        public string Combine(string path1, string path2, string path3, string path4)
        {
            return Path.Combine(path1, path2, path3, path4);
        }

        public string Combine(params string[] paths)
        {
            return Path.Combine(paths);
        }
    }
}
