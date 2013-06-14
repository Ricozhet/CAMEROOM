using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CameRoomWeb.Models.BookingModel;
using CameRoomWeb.Utilities;

namespace CameRoomWeb.Controllers
{
    public class BookingController : Controller
    {
        //
        // GET: /Booking/
        CameRoomService.ServiceClient service = new CameRoomService.ServiceClient();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SelectEvent()
        {
            Booking model = new Booking();
            //model.ProvinceID = 2;
            return View(model);
        }

        [HttpPost]
        public ActionResult SelectEvent(string button)
        {
            //model.ProvinceID = 2;
            Session["EventType"] = button;
            return RedirectToAction("Booking", "Booking");
        }

        public ActionResult Booking()
        {
            Booking model = new Booking();
            model.BookingDate = "5";
            model.ProvinceID = 2;
            model.ListPlace = Utility.getPlaceListByProvinceID(model.ProvinceID);
            model.eventTypeID = Session["EventType"].ToString();
            return View(model);
        }

        [HttpPost]
        public ActionResult Booking(Booking model)
        {
            model.ProvinceID =2;
            model.ListPlace = Utility.getPlaceListByProvinceID(model.ProvinceID);
            model.eventTypeID = Session["EventType"].ToString();
            model.bookingDatetime = model.BookingYear +"-"+model.BookingDate +"-"+model.BookingMounth +" 00:00:00.000" ;
            Session["BookingModel"] = model;
            return RedirectToAction("Search", "Booking");
        }

        [ValidateInput(true)]
        public ActionResult ChangeProvince(Booking model)
        {
            string test = model.PlaceID;
            model.ListPlace = Utility.getPlaceListByProvinceID(model.ProvinceID);
            return View("Booking", model);
        }

        public ActionResult Search()
        {
            string errMsg = "";
            DataSet ds = new DataSet();
            Booking model = new Booking();
            model = (Booking)Session["BookingModel"];
            service.getGrapherForBooking(model.bookingDatetime, Convert.ToInt16(model.bookingType), Convert.ToInt16(model.eventTypeID), model.ProvinceID, Convert.ToInt32(model.PlaceID), out ds, out errMsg);
            model.SearchGrapher = ds;
            return View(model);
        }

        [HttpGet]
        public FileContentResult GetLogoImage(string id)
        {
            try
            {
                //AccountDL _UserServices = new AccountDL();
                string imagetype = "image/jpeg";
                byte[] _ImgData = GetBytes(id);
                if (_ImgData == null)
                    return null;
                else
                    return new FileContentResult(_ImgData, "image/jpeg");

            }
            catch (Exception ex)
            {
                //log.Debug("GetLogoImage() : Error occured : " + ex.Message.ToString());
            }
            return null;
        }

        public ActionResult GetImage(int id)
        {
            byte[] image = service.getGrapherImage(id);
            return File(image, "image/jpg");
        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
    }
}
