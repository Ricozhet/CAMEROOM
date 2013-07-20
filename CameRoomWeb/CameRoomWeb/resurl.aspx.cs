using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CameRoomWeb.Utilities;

namespace CameRoomWeb
{
    public partial class resurl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.InnerText = "";
            if (Request.QueryString.Count == 0)
            {
                lblMsg.InnerText = "Invalid request.";
                return;
            }
            else
            {
                if (Request.QueryString[0].ToString().Trim() == "")
                {
                    lblMsg.InnerText = "Invalid request.";
                    return;
                }
            }
            if (!IsPostBack)
            {
                string errMsg = "";
                DataSet ds = new DataSet();
                CameRoomService.ServiceClient _cmrWF = new CameRoomService.ServiceClient();
                string rawMsg = Request.QueryString[0].ToString();
                string reqMessage = Utility.base64ToString(rawMsg.Substring(0, rawMsg.ToString().Length - 1));
                string reqCode = reqMessage.Substring(0, 2);
                long BookingID = Convert.ToInt64(reqMessage.Substring(2, reqMessage.Length - 2));
                _cmrWF.updateBookingStatus(BookingID, reqCode, out ds, out errMsg);
                string BookingStatus = ds.Tables[0].Rows[0]["BOOKINGSTATUS"].ToString();

                if (BookingStatus == "AP")
                {
                    lblMsg.InnerText = "Booking Approved!";
                }
                else if (BookingStatus == "CA")
                {
                    lblMsg.InnerText = "Booking Cancelled!";
                }
                else
                {
                    lblMsg.InnerText = "Booking Failed!";
                }
            }
            return;
        }
    }
}