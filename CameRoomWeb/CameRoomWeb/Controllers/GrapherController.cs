using CameRoomWeb.Models.GrapherModel;
using System;
using System.Collections.Generic;
using System.IO;
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
        /*
        [HttpPost]
        public ActionResult GrapherRegister()
        {
            GrapherRegisterModel model = new GrapherRegisterModel();
            
            foreach (string upload in Request.Files)
            {
                Stream fileStream = Request.Files[upload].InputStream;
                int fileLength = Request.Files[upload].ContentLength;
                byte[] fileData = new byte[fileLength];
                fileStream.Read(fileData, 0, fileLength);
            }
            return View(model);
        }
         */
    }
}
