using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace XmlTestExamples.Models
{
    public class Users
    {
        
        [XmlElement(ElementName = "User")]
        public List<UserData> UserList { get; set; }
    }
}