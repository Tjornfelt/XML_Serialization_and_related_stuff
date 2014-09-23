using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace XmlTestExamples.Models
{
    public class UserData
    {
        //[XmlElement(ElementName = "Id")]
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlElement(ElementName = "Name")]
        [Display(Name = "Navn")]
        public string Name { get; set; }

        [XmlElement(ElementName = "Title")]
        [Display(Name = "Titel")]
        public string Title { get; set; }

        [XmlElement(ElementName = "RelatedUsers")]
        public List<int> RelatedUsers { get; set; }
    }
}