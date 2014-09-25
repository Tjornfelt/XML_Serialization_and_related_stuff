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

        public string ValidateXmlDTD(string validate)
        {
            //validate can be:
            //valid-schema
            //invalid-schema
            // Create the XmlReader object.
            XmlReader reader = null;
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            settings.ValidationType = ValidationType.DTD;
            settings.ValidationEventHandler += new ValidationEventHandler (ValidationEventHandler);

            if (validate == "valid-schema")
            {
                reader = XmlReader.Create(Server.MapPath("~/Content/DTDexamples/notevalid.xml"), settings);
            }
            else if (validate == "invalid-schema")
            {
                reader = XmlReader.Create(Server.MapPath("~/Content/DTDexamples/noteerror.xml"), settings);
            }
            

            try
            {
                // Parse the file. 
                while (reader.Read()) ;
                // xmlDoc.Load(reader); //Note that XmlDocument will FAIL when trying to parse the XML which contains a DTD declaration - my guess is that it is simply
                // not supported anymore - the good old XmlReader, however, just crawls through the document 
                return "Xml successfuldt valideret op mod DTD skemaet!";
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