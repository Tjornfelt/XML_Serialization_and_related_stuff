using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using XmlTestExamples.Models;

namespace XmlTestExamples.Controllers
{
    public class XpathController : Controller
    {
        // GET: Xpath
        public ActionResult Index()
        {
            XpathModel model = new XpathModel();

            return View(model);
        }

        public string SelectNode(string xpath)
        {
            //Do some stuff!
            //http://www.codedigest.com/Articles/ASPNET/342_Using_XPath_Expression_to_Access_or_Read_XML_document_in_ASPNet.aspx

            XmlDocument xmldoc = new XmlDocument();
            //xmldoc.Load(@"~/Content/XmlXpath/Books.xml");
            xmldoc.Load(Server.MapPath("~/Content/XmlXpath/Books.xml"));
            string result = xmldoc.SelectSingleNode(xpath).InnerText;
            return result;
        }
    }
}