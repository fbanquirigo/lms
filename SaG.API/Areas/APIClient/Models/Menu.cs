using System;
using System.Xml.Serialization;

namespace SaG.API.Areas.APIClient.Models
{
    [Serializable]
    [XmlRoot("MenuItem")]
    [XmlType("MenuItem")]
    public class Menu
    {
        public string Text { get; set; }
        public string Form { get; set; }
        public string Location { get; set; }
        [XmlArray("SubMenus")]
        [XmlArrayItem("MenuItem")]
        public Menu[] SubMenus { get; set; }
    }
}