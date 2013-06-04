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
        CameRoomService.ServiceClient service = new CameRoomService.ServiceClient();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GrapherRegister()
        {
            GrapherRegisterModel model = new GrapherRegisterModel();
            model.ProvinceID = 2;
            return View(model);
        }

        [HttpPost]
        public ActionResult GrapherRegister(GrapherRegisterModel model)
        {
            string errMsg = "";
            service.insertGrapherRegister(model.GrapherEmail,model.GrapherName,model.GrapherSurname,model.GrapherPersonalID,model.GrapherMobileNumber,model.GrapherSex,model.Password, model.ProvinceID, out errMsg);
            return View(model);
        }
    }
}
