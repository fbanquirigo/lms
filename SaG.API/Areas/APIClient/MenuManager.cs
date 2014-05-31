using System.IO;
using System.Xml.Serialization;
using SaG.API.Areas.APIClient.Models;

namespace SaG.API.Areas.APIClient
{
    public class MenuManager : IMenuManager
    {
        public SiteMenu GetMenu(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("File not found.", path);

            using (Stream stream = new FileStream(path, FileMode.Open))
            {
                var serializer = new XmlSerializer(typeof(SiteMenu));
                object result = serializer.Deserialize(stream);
                return (result is SiteMenu)
                    ? result as SiteMenu
                    : null; 
            }
        }

        public MethodList GetMethodList(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("File not found.", path);

            using (Stream stream = new FileStream(path, FileMode.Open))
            {
                var serializer = new XmlSerializer(typeof(MethodList));
                object result = serializer.Deserialize(stream);
                return (result is MethodList)
                    ? result as MethodList
                    : null;
            }
        }
    }
}