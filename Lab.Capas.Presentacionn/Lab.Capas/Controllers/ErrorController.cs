using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.Capas.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult PageNotFound()
        {
            return View();
        }

        public ActionResult CantDelete()
        {
            throw new Exception("No es posible eliminar el registro especificado");
        }
    }
}