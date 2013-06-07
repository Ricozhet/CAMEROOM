using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GrapherDL
/// </summary>
public class GrapherDL
{

    private DataHelper dbh;
    public GrapherDL()
	{
        try
        {
            dbh = new DataHelper();
        }
        catch (Exception ex)
        {

        }
	}

    public bool insertGrapherRegister(out string errMsg, string GrapherEmail, string GrapherName, string GrapherSurname, 
    string GrapherPersonalID, byte[] GrapherPhoto, string GrapherMobileNumber, string GrapherSex, string Password, int ProvinceID)
    {
        bool result = false;
        DataSet ds = new DataSet();
        errMsg = "";
        SqlConnection conn = dbh.getConnection();
        try
        {
            conn.Open();
            ds = SqlHelper.ExecuteDataset(conn, "cmr_insertGrapherRegister", GrapherEmail, GrapherName, GrapherSurname, GrapherPersonalID,
                GrapherPhoto, GrapherMobileNumber, GrapherSex, Password, ProvinceID);
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