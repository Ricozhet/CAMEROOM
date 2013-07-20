using CameRoomWeb.Models.GrapherModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using CameRoomWeb.Models.BookingModel;
using CameRoomWeb.Utilities;
using CameRoomWeb.Enumeric;
using CameRoomWeb.Models;

namespace CameRoomWeb.Controllers
{
    public class GrapherController : Controller
    {
        //
        // GET: /Grapher/
        private Service.GrapherService _grapherService = new Service.GrapherService();
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
            model.GrapherID = 25;
            AuthenInfo info = new AuthenInfo();
            info = (AuthenInfo)HttpContext.Session["LoginInfo"];
            string errMsg = "";
            string tmpGrapherEmail = "";
            string tmpGrapherName = "";
            string tmpGrapherSurname = "";
            string tmpGrapherPersonalID = "";
            string tmpGrapherTelephoneNumber = "";
            string tmpGrapherSex = "";
            int tmpProvinceID = 0;

            service.getGrapherProfileByGrapherID(model.GrapherID, out errMsg, out tmpGrapherEmail, out tmpGrapherName, out tmpGrapherSurname,
                out tmpGrapherPersonalID, out tmpGrapherTelephoneNumber, out tmpGrapherSex, out tmpProvinceID);

            model.GrapherEmail = tmpGrapherEmail;
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
            //Event Type
            double tmpMorningRate = 0;
            double tmpAfternoonRate = 0;
            double tmpEveningRate = 0;
            double tmpFulldayRate = 0;
            double[,] tmpEarningRate = new double[3,5];
            model.EarningRateCongratulation = new double[5];
            model.EarningRateWedding = new double[5];
            model.EarningRateOther = new double[5];
            //model.EventTypeID = 1;
            for (int iCount = 1; iCount <= 3; iCount++)
            {
                model.EventTypeID = iCount;
                if (!service.getGrapherEarningRateProfileByGrapherIDandEventTypeID(model.GrapherID, model.EventTypeID, out errMsg,
                out tmpMorningRate, out tmpAfternoonRate, out tmpEveningRate, out tmpFulldayRate))
                {
                    for (int j = 0; j <= 4; j++)
                    {
                        tmpEarningRate[iCount -1, j] = 0;
                    }
                }
                else
                {
                    //model.EarningRateCongratulation[0] = iCount;
                    //model.MorningRate = tmpMorningRate;
                    //model.AfternoonRate = tmpAfternoonRate;
                    //model.EveningRate = tmpEveningRate;
                    //model.FulldayRate = tmpFulldayRate;
                    tmpEarningRate[iCount - 1, 0] = iCount;
                    tmpEarningRate[iCount - 1, 1] = tmpMorningRate;
                    tmpEarningRate[iCount - 1, 2] = tmpAfternoonRate;
                    tmpEarningRate[iCount - 1, 3] = tmpEveningRate;
                    tmpEarningRate[iCount - 1, 4] = tmpFulldayRate;
                }

                //for (int y = 0; y <= 4; y++)
                //{
                //    model.EarningRate[iCount - 1, y] = tmpEarningRate[iCount - 1, y];
                //}
                for (int y = 0; y <= 4; y++)
                {
                    model.EarningRateCongratulation[y] = tmpEarningRate[0, y];
                    model.EarningRateWedding[y] = tmpEarningRate[1,y];
                    model.EarningRateOther[y] = tmpEarningRate[2,y];
                }
            }
            //Province
            model.ProvinceID = tmpProvinceID;
            return View(model);
        }

        public ActionResult GrapherHome(int id)
        {
            Booking model = new Booking();
            model = (Booking)Session["BookingModel"];
            model.grapherID = id;
            Session["BookingModel"] = model;
            return View();
        }

        [HttpPost]
        public ActionResult GrapherHome()
        {
            string errMsg = "";
            long tmpID = Convert.ToInt64(0);
            Booking model = new Booking();
            model = (Booking)Session["BookingModel"];
            model.userID = 2;
            SendMail.sendEmail("peerawatkung@gmail.com", "TEST SUBJECT", "KAK", out errMsg);
            service.insertBooking(model.bookingDatetime, Convert.ToInt32(model.bookingType), model.userID, model.grapherID, Convert.ToInt32(model.eventTypeID), model.ProvinceID, Convert.ToInt32(model.PlaceID), out tmpID, out errMsg);
            Session["BookingModel"] = model;
            return View();
        }

        #region Vesuvius
        public ActionResult GrapherLogOn()
        {
            var model = new GrapherLogOn();
            return View(model);
        }

        [HttpPost]
        public ActionResult GrapherLogOn(GrapherLogOn model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                Encrypt encrypt = new Encrypt();
                string saltkey = "";
                saltkey = _grapherService.getPasswordSalt(model.GrapherEmail);
                model.GrapherPassword = encrypt.ComputeHash(model.GrapherPassword, saltkey);

                string msg = "";
                LogOnResultType resultType = _grapherService.CheckAuthenticate(model.GrapherEmail, model.GrapherPassword, out msg);

                switch (resultType)
                {
                    case LogOnResultType.SUCCESS:   //Login success
                        if (!string.IsNullOrEmpty(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("GrapherRegister", "Grapher");
                        }
                    //case LogOnResultType.PASSWORDEXPIRED:   //Password expired.
                    //    return RedirectToAction("PasswordExpired", "User");
                    //case LogOnResultType.USEREXPIRED:       //User Expired.
                    //    ModelState.AddModelError("", msg);
                    //    break;
                    case LogOnResultType.USERLOCKED:        //User Locked.
                        ModelState.AddModelError("", msg);
                        break;
                    case LogOnResultType.FAILED:            //Login failed.
                        ModelState.AddModelError("", msg);
                        break;
                    default: break;
                }
            }
            else
            {
                ModelState.AddModelError("", "[ VALIDATION FAILED ].");
            }

            return View(model);
        }
        #endregion
    }
}
