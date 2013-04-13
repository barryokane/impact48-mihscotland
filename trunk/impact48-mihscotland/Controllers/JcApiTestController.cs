using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JustGiving.Api.Sdk;

namespace impact48_mihscotland.Controllers
{
    public class JcApiTestController : Controller
    {
        //
        // GET: /ApiTest/

        public ActionResult Index()
        {
            string key = ConfigurationManager.AppSettings["JustGiving.Api.Key"];
            var client = new JustGivingClient(key);
            var page = client.Charity.Retrieve(185656);

            return View();
        }

    }
}
