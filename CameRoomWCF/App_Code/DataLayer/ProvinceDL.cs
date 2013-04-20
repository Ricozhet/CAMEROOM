using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;

/// <summary>
/// Summary description for ProvinceDL
/// </summary>
public class ProvinceDL
{
    private DataHelper dbh;
	public ProvinceDL()
	{
        try
        {
            dbh = new DataHelper();
        }
        catch (Exception ex)
        { 
        
        }
	}

    public bool getProvinceList(out DataSet ds, out string errMsg)
    {
        bool result = false;
        ds = new DataSet();
        errMsg = "";
        SqlConnection conn = dbh.getConnection();
        try
        {
            conn.Open();
            ds = SqlHelper.ExecuteDataset(conn, "cmr_getProvinceList");
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