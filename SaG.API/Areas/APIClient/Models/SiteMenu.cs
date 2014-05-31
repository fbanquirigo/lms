using System;
using System.Xml.Serialization;

namespace SaG.API.Areas.APIClient.Models
{
    [Serializable]
    [XmlRoot("MenuConfiguration")]
    public class SiteMenu
    {
        [XmlArray("Menus")]
        [XmlArrayItem("MenuItem")]
        public Menu[] Menus { get; set; }
    }
}