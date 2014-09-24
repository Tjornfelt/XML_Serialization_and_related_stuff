using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XmlTestExamples.Models;

namespace XmlTestExamples.Controllers
{
    public class XsltExamplesController : Controller
    {
        // GET: Xslt
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EmbeddedXslt()
        {
            return View();
        }
    }
}