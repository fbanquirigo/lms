using System;
using System.Xml.Serialization;

namespace SaG.API.Areas.APIClient.Models
{
    [Serializable]
    [XmlRoot("MethodsConfiguration")]
    public class MethodList
    {
        [XmlArray("Methods")]
        [XmlArrayItem("Method")]
        public Method[] Methods { get; set; }

        [XmlElement("MethodListTitle")]
        public string MethodListTitle { get; set; }
    }
}