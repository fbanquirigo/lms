using System;
using System.Xml.Serialization;

namespace SaG.API.Areas.APIClient.Models
{
    [Serializable]
    [XmlRoot("Method")]
    [XmlType("Method")]
    public class Method
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Form { get; set; }
    }
}