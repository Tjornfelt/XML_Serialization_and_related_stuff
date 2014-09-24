using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Schema;

namespace XmlTestExamples.Controllers
{
    public class XSDExamplesController : Controller
    {
        // GET: XSDExamples
        public ActionResult Index()
        {
            return View();
        }

        public string ValidateXml(string validate)
        {
            //validate can be:
            //valid-schema
            //invalid-schema
            XmlDocument xmlDoc = new XmlDocument();
            
            if (validate == "valid-schema")
            {
                xmlDoc.Load(Server.MapPath("~/Content/XSDexamples/notevalid.xml"));
            }
            else if (validate == "invalid-schema")
            {
                xmlDoc.Load(Server.MapPath("~/Content/XSDexamples/noteerror.xml"));
            }

            try
            {
                xmlDoc.Schemas.Add("http://www.w3schools.com", "file:///C:/Users/Mads/Documents/GitHub/XML_Serialization_and_related_stuff/XmlTestExamples/XmlTestExamples/Content/XSDexamples/note.xsd");
                
                ValidationEventHandler eventHandler = new ValidationEventHandler(ValidationEventHandler);
                xmlDoc.Validate(eventHandler);
                return "Xml successfuldt valideret op mod XSD skemaet!";
            }
            catch (XmlSchemaValidationException ex)
            {
                return ex.Message;
            }
        }

        public void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    throw new XmlSchemaValidationException(e.Message);
            }
        }
    }
}