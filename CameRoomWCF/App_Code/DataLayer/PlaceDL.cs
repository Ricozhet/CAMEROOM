using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PlaceDL
/// </summary>
public class PlaceDL
{
    private DataHelper dbh;
	public PlaceDL()
	{
        try
        {
            dbh = new DataHelper();
        }
        catch (Exception ex)
        {

        }
	}

    public bool getPlaceListByProvinceID(out DataSet ds, out string errMsg, int provinceID)
    {
        bool result = false;
        ds = new DataSet();
        errMsg = "";
        SqlConnection conn = dbh.getConnection();
        try
        {
            conn.Open();
            ds = SqlHelper.ExecuteDataset(conn, "cmr_getPlaceListByProvinceID", provinceID);
            result = true;
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