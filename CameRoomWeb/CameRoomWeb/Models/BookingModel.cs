using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CameRoomWeb.Models.BookingModel
{
    public class BookingModel
    {

    }

    public class Booking
    {
        public long bookingID { get; set; }
        public string bookingDatetime { get; set; }
        public string bookingType { get; set; }
        public string eventTypeID { get; set; }
        public int userID { get; set; }
        public string provinceName { get; set; }
        public string BookingDate { get; set; }
        public IEnumerable<SelectListItem> ListDay
        {
            get
            {
                return new SelectListItem[]
                    {   
                        new SelectListItem { Value = "01",Text="01"},
                        new SelectListItem { Value = "02",Text="02"},
                        new SelectListItem { Value = "03",Text="03"},
                        new SelectListItem { Value = "04",Text="04"},
                        new SelectListItem { Value = "05",Text="05"},
                        new SelectListItem { Value = "06",Text="06"},
                        new SelectListItem { Value = "07",Text="07"},
                        new SelectListItem { Value = "08",Text="08"},
                        new SelectListItem { Value = "09",Text="09"},
                        new SelectListItem { Value = "10",Text="10"},
                        new SelectListItem { Value = "11",Text="11"},
                        new SelectListItem { Value = "12",Text="12"},
                        new SelectListItem { Value = "13",Text="13"},
                        new SelectListItem { Value = "14",Text="14"},
                        new SelectListItem { Value = "15",Text="15"},
                        new SelectListItem { Value = "16",Text="16"},
                        new SelectListItem { Value = "17",Text="17"},
                        new SelectListItem { Value = "18",Text="18"},
                        new SelectListItem { Value = "19",Text="19"},
                        new SelectListItem { Value = "20",Text="20"},
                        new SelectListItem { Value = "21",Text="21"},
                        new SelectListItem { Value = "22",Text="22"},
                        new SelectListItem { Value = "23",Text="23"},
                        new SelectListItem { Value = "24",Text="24"},
                        new SelectListItem { Value = "25",Text="25"},
                        new SelectListItem { Value = "26",Text="26"},
                        new SelectListItem { Value = "27",Text="27"},
                        new SelectListItem { Value = "28",Text="28"},
                        new SelectListItem { Value = "29",Text="29"},
                        new SelectListItem { Value = "30",Text="30"},
                        new SelectListItem { Value = "31",Text="31"}
                    };
            }
        }
        public string BookingMounth { get; set; }
        public IEnumerable<SelectListItem> ListMounth
        {
            get
            {
                return new SelectListItem[]
                    {   
                        new SelectListItem { Value = "01",Text="01"},
                        new SelectListItem { Value = "02",Text="02"},
                        new SelectListItem { Value = "03",Text="03"},
                        new SelectListItem { Value = "04",Text="04"},
                        new SelectListItem { Value = "05",Text="05"},
                        new SelectListItem { Value = "06",Text="06"},
                        new SelectListItem { Value = "07",Text="07"},
                        new SelectListItem { Value = "08",Text="08"},
                        new SelectListItem { Value = "09",Text="09"},
                        new SelectListItem { Value = "10",Text="10"},
                        new SelectListItem { Value = "11",Text="11"},
                        new SelectListItem { Value = "12",Text="12"}
                    };
            }
        }
        public string BookingYear { get; set; }
        public IEnumerable<SelectListItem> ListYear
        {
            get
            {
                return new SelectListItem[]
                    {   
                       new SelectListItem { Value = DateTime.Now.ToString("yyyy") ,Text= DateTime.Now.ToString("yyyy")},
                       new SelectListItem { Value = DateTime.Now.AddYears(1).ToString("yyyy"),Text= DateTime.Now.AddYears(1).ToString("yyyy")}
                    };
            }
        }
        public int ProvinceID { get; set; }
        private CameRoomService.ServiceClient _cmrWS = new CameRoomService.ServiceClient();
        public IEnumerable<SelectListItem> listProvince
        {
            get
            {
                string errMsg = "";
                DataSet ds = null;
                DataTable dt = null;
                if (!_cmrWS.getProvinceList(out ds, out errMsg))
                {
                    return null;
                }
                else
                {
                    dt = ds.Tables[0];
                    return Utilities.Utility.DT2SelectList(dt, "PROVINCEID", "PROVINCENAME");
                }
            }
        }
        public string PlaceID { get; set; }
        public string placeName { get; set; }
        public IEnumerable<SelectListItem> ListPlace { get; set; }
        public int grapherID { get; set; }
        public DataSet SearchGrapher { get; set; }

        //public IEnumerable<SelectListItem> listPicture
        //{
        //    get
        //    {
        //        string errMsg = "";
        //        DataSet ds = null;
        //        DataTable dt = null;
        //        if (!_cmrWS.getPictureListByEventTypeID(out ds, out errMsg))
        //        {
        //            return null;
        //        }
        //        else
        //        {
        //            dt = ds.Tables[0];
        //            return Utilities.Utility.DT2SelectList(dt, "GRAPHERID", "GRAPHERID");
        //        }
        //    }
        //}
        
    }
}