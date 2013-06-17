using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CameRoomWeb.Models.ProvinceModel
{
    public class ProvinceModel
    {
    }

    public class Province
    {
        [Display(Name = "No.")]
        public int RowNo { get; set; }
        public int ProvinceID { get; set; }
        public string ProvinceName { get; set; }
    }

}