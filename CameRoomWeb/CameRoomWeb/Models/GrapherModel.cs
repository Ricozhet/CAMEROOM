using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Linq;
using System.Web.Mvc;

namespace CameRoomWeb.Models.GrapherModel
{
    public class GrapherModel
    {
    }

    public class Grapher
    {
        public long GrapherID { get; set; }
        [Display(Name = "Email : ")]
        public string GrapherEmail { get; set; }
        [Display(Name = "Name : ")]
        public string GrapherName { get; set; }
        [Display(Name = "Surname : ")]
        public string GrapherSurname { get; set; }
        [Display(Name = "PersonalID : ")]
        public string GrapherPersonalID { get; set; }
        [Display(Name = "Mobile Number : ")]
        public string GrapherMobileNumber { get; set; }
        [Display(Name = "Sex : ")]
        public string GrapherSex { get; set; }
        public string GrapherLevel { get; set; }
        [Display(Name = "Status : ")]
        public string GrapherStatus { get; set; }
        [Display(Name = "Password : ")]
        public string GrapherPassword { get; set; }
    }
    public class GrapherRegisterModel
    {
        public long GrapherID { get; set; }
        [Display(Name = "Email : ")]
        public string GrapherEmail { get; set; }
        [Display(Name = "Name : ")]
        public string GrapherName { get; set; }
        [Display(Name = "Surname : ")]
        public string GrapherSurname { get; set; }
        [Display(Name = "PersonalID : ")]
        public string GrapherPersonalID { get; set; }
        [Display(Name = "Mobile Number : ")]
        public byte[] GrapherPhoto { get; set; }
        [Display(Name = "Photo : ")]
        public string GrapherMobileNumber { get; set; }
        [Display(Name = "Sex : ")]
        public string GrapherSex { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Password : ")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Password : ")]
        //[Compare("Password", ErrorMessage = "The confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

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
        public byte[] imageData { get; set; }
        public string imageMimeType { get; set; }
        public int imgWidth { get; set; }
        public int imgHeight { get; set; }
        public int maxSize { get; set; }
        public string SystemMessage { get; set; }
        public bool isError { get; set; }
        public bool isEditMode { get; set; }
    }
}