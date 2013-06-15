using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CameRoomWeb.Models
{
    public class AuthenInfo
    {
        public string LoginUserID { get; set; }
        public string LoginUserName { get; set; }
        public string ClientIP { get; set; }
        public string UserLevel { get; set; }
        public DateTime? LastLogin { get; set; }

        //public int MinLenght { get; set; }
        //public int MinUpper { get; set; }
        //public int MinNumber { get; set; }
        //public int MinSpecial { get; set; }
        //public int RecentPassword { get; set; }
    }
}