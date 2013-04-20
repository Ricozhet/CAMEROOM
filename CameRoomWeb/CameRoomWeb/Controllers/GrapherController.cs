using CameRoomWeb.Models.GrapherModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CameRoomWeb.Controllers
{
    public class GrapherController : Controller
    {
        //
        // GET: /Grapher/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GrapherRegister()
        {
            GrapherRegisterModel model = new GrapherRegisterModel();
            return View(model);
        }

    }
}
