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

    public bool insertGrapherRegister(out string errMsg, out long GrapherID, string GrapherEmail, string GrapherName, string GrapherSurname, 
    string GrapherPersonalID, byte[] GrapherPhoto, string GrapherMobileNumber, string GrapherSex, string Password, int ProvinceID)
    {
        bool result = false;
        DataSet ds = new DataSet();
        errMsg = "";
        GrapherID = 0;
        SqlConnection conn = dbh.getConnection();
        try
        {
            conn.Open();
            ds = SqlHelper.ExecuteDataset(conn, "cmr_insertGrapherRegister", GrapherEmail, GrapherName, GrapherSurname, GrapherPersonalID,
                GrapherPhoto, GrapherMobileNumber, GrapherSex, Password, ProvinceID);
            GrapherID = Convert.ToInt64(ds.Tables[0].Rows[0][0]);
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

    public bool insertGrapherRegisterMapEarningRate(out string errMsg, long GrapherID, int EventTypeID, double MorningRate, double AfternoonRate, 
        double EveningRate, double FullDayRate)
    {
        bool result = false;
        DataSet ds = new DataSet();
        errMsg = "";
        SqlConnection conn = dbh.getConnection();
        try
        {
            conn.Open();
            ds = SqlHelper.ExecuteDataset(conn, "cmr_insertGrapherRegisterMapEarningRate", GrapherID, EventTypeID, MorningRate, AfternoonRate, EveningRate, FullDayRate);
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

    public bool getGrapherProfileByEmail(out string errMsg, out long GrapherID, out string GrapherName, out string GrapherSurname, out string GrapherPersonalID, 
        out string GrapherMobileNumber, out string GrapherSex, out int ProvinceID, string GrapherEmail)
    {
        bool result = false;
        DataSet ds = new DataSet();
        errMsg = "";
        GrapherID = 0;
        GrapherName = "";
        GrapherSurname = "";
        GrapherPersonalID = "";
        //GrapherPhoto= Enumerable.Repeat((byte)0x20, 1).ToArray();
        GrapherMobileNumber = "";
        GrapherSex = "";
        ProvinceID = 0;
        SqlConnection conn = dbh.getConnection();
        try
        {
            conn.Open();
            ds = SqlHelper.ExecuteDataset(conn, "cmr_getGrapherProfileByEmail", GrapherEmail);
            GrapherID = Convert.ToInt64(ds.Tables[0].Rows[0]["GRAPHERID"]);
            GrapherName = ds.Tables[0].Rows[0]["NAME"].ToString();
            GrapherSurname = ds.Tables[0].Rows[0]["SURNAME"].ToString();
            GrapherPersonalID = ds.Tables[0].Rows[0]["PERSONALID"].ToString();
            GrapherMobileNumber = ds.Tables[0].Rows[0]["TELEPHONENUMBER"].ToString();
            GrapherSex = ds.Tables[0].Rows[0]["SEX"].ToString();
            ProvinceID = Convert.ToInt32(ds.Tables[0].Rows[0]["ProvinceID"]);
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

    public bool getGrapherEarningRateProfileByGrapherIDandGrapherEmail(out string errMsg, out double MorningRate, 
        out double AfternoonRate, out double EveningRate, out double FulldayRate, long GrapherID, int EventTypeID)
    {
        bool result = false;
        DataSet ds = new DataSet();
        errMsg = "";
        MorningRate = 0;
        AfternoonRate = 0;
        EveningRate = 0;
        FulldayRate = 0;
        SqlConnection conn = dbh.getConnection();
        try
        {
            conn.Open();
            ds = SqlHelper.ExecuteDataset(conn, "cmr_getGrapherProfileByEmail", GrapherID, EventTypeID);
            MorningRate = Convert.ToDouble(ds.Tables[0].Rows[0]["MORNINGRATE"]);
            AfternoonRate = Convert.ToDouble(ds.Tables[0].Rows[0]["AFTERNOONRATE"]);
            EveningRate = Convert.ToDouble(ds.Tables[0].Rows[0]["EVENINGRATE"]);
            FulldayRate = Convert.ToDouble(ds.Tables[0].Rows[0]["FULLDAYRATE"]);
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