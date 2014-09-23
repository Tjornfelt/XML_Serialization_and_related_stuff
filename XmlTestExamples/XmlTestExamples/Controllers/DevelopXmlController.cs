using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XmlTestExamples.Models;
using XmlTestExamples.Helpers;

namespace XmlTestExamples.Controllers
{
    public class DevelopXmlController : Controller
    {
        // GET: DevelopXml
        public ActionResult Index()
        {
            DevelopXmlModel model = new DevelopXmlModel()
            {
                Users = XMLHelpers.ReadUsersFromXml(),
                CreateUserForm = new UserData()
            };
            return View(model);
        }

        // GET: DevelopXml
        public ActionResult Create(DevelopXmlModel data, FormCollection form)
        {
            UserData formData = data.CreateUserForm;
            formData.RelatedUsers = new List<int>();
            string userIdCsv = form["relatedUsers"];

            if (userIdCsv != null)
            {
                string[] userIdList = userIdCsv.Split(',');
                foreach (var id in userIdList)
                {
                    int convertedId = Convert.ToInt32(id);
                    formData.RelatedUsers.Add(convertedId);
                }
            }

            bool result = XMLHelpers.NewUserAsXml(formData);

            //Redirecting to same page to avoid weird URL's - normally i would post using ajax, but im too lazy right now.
            string url = this.Request.UrlReferrer.AbsolutePath;
            return Redirect(url);

            //DevelopXmlModel model = new DevelopXmlModel()
            //{
            //    Users = XMLHelpers.ReadUsersFromXml(),
            //    CreateUserForm = new UserData()
            //};
            //return View("Index", model,);
        }

        public ActionResult Delete(FormCollection form)
        {
            //Start by reading the XMLDocument
            Users users = XMLHelpers.ReadUsersFromXml();

            if (users != null)
            {
                string userIdCsv = form["relatedUsers"];

                if (userIdCsv != null)
                {
                    string[] userIdList = userIdCsv.Split(',');
                    foreach (var id in userIdList)
                    {
                        int convertedId = Convert.ToInt32(id);
                        XMLHelpers.RemoveXmlUser(convertedId);
                    }
                }
            }

            //Redirecting to same page to avoid weird URL's - normally i would post using ajax, but im too lazy right now.
            string url = this.Request.UrlReferrer.AbsolutePath;
            return Redirect(url);

            //DevelopXmlModel model = new DevelopXmlModel()
            //{
            //    Users = XMLHelpers.ReadUsersFromXml(),
            //    CreateUserForm = new UserData()
            //};
            //return View("Index", model);
        }
    }
}