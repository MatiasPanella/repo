using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.Capas.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        [HandleError]
        public ActionResult Index()
        {
            throw new Exception();
        }
    }
}