using CameRoomWeb.Models.GrapherModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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
            //insert pic
            long tmpGrapherID = 0;
            HttpPostedFileBase image = Request.Files[0];
            Byte[] uploadimage = new Byte[image.ContentLength];
            image.InputStream.Read(uploadimage, 0, image.ContentLength);
            model.GrapherPhoto = uploadimage;
            service.insertGrapherRegister(model.GrapherEmail, model.GrapherName, model.GrapherSurname, model.GrapherPersonalID, model.GrapherPhoto, model.GrapherMobileNumber, model.GrapherSex, model.Password, model.ProvinceID, out errMsg, out tmpGrapherID);
            model.GrapherID = tmpGrapherID;

            string CongratType = Request.Form["CongratType"];
            string WeddingType = Request.Form["WeddingType"];
            string OtherType = Request.Form["OtherType"];
            if (CongratType == "1")
            {
                service.insertGrapherRegisterMapEarningRate(model.GrapherID, 1, model.PriceforCongratulationMorning, model.PriceforCongratulationAfternoon, 
                    0, model.PriceforCongratulationFullday, out errMsg);
            }
            if (WeddingType == "1")
            {
                service.insertGrapherRegisterMapEarningRate(model.GrapherID, 2, model.PriceforWeddingMorning, model.PriceforWeddingAfternoon, 
                    model.PriceforWeddingEvening, model.PriceforWeddingFullday, out errMsg);
            }
            if (OtherType == "1")
            {
                service.insertGrapherRegisterMapEarningRate(model.GrapherID, 3, model.PriceforOtherMorning, model.PriceforOtherAfternoon, 
                    model.PriceforOtherEvening, model.PriceforOtherFullday, out errMsg);
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult GrapherEdit()
        {
            GrapherEditModel model = new GrapherEditModel();
            model.GrapherEmail = "twet";
            string errMsg = "";
            long tmpGrapherID = 0;
            string tmpGrapherName = "";
            string tmpGrapherSurname = "";
            string tmpGrapherPersonalID = "";
            string tmpGrapherTelephoneNumber = "";
            string tmpGrapherSex = "";
            int tmpProvinceID = 0;

            service.getGrapherProfileByEmail(model.GrapherEmail, out errMsg, out tmpGrapherID, out tmpGrapherName, out tmpGrapherSurname,
                out tmpGrapherPersonalID, out tmpGrapherTelephoneNumber, out tmpGrapherSex, out tmpProvinceID);
            
            model.GrapherName = tmpGrapherName;
            model.GrapherSurname = tmpGrapherSurname;
            model.GrapherPersonalID = tmpGrapherPersonalID;
            model.GrapherTelephoneNumber = tmpGrapherTelephoneNumber;
            model.GrapherSex = tmpGrapherSex;
            if (model.GrapherSex == "1")
            {
                model.GrapherSexDisplay = "Male";
            }
            else 
            {
                model.GrapherSexDisplay = "Female";
            }
            model.ProvinceID = tmpProvinceID;


            return View(model);
        }

        //[HttpPost]
        //public ActionResult GrapherEdit()
        //{
        //    return View();
        //}
    }
}
