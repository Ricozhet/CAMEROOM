using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;

/// <summary>
/// Summary description for BookingDL
/// </summary>
public class BookingDL
{
    private DataHelper dbh;
	public BookingDL()
	{
        try
        {
            dbh = new DataHelper();
        }
        catch (Exception ex)
        {

        }
	}
    public bool updateBookingStatus(out DataSet ds, out string errMsg, long bookingID, string bookingStatus)
    {
        bool result = false;
        errMsg = "";
        ds = new DataSet();
        SqlConnection conn = dbh.getConnection();
        try
        {
            conn.Open();
            ds = SqlHelper.ExecuteDataset(conn, "ptg_updateBookingStatus", bookingID, bookingStatus);
        }
        catch (Exception ex)
        {
            errMsg = ex.Message;
        }
        finally
        {
            if (conn != null)
                conn.Close();
        }
        return result;
    }
}