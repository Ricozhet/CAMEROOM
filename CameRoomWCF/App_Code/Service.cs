﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Microsoft.ApplicationBlocks.Data;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
	public string GetData(int value)
	{
		return string.Format("You entered: {0}", value);
	}

	public CompositeType GetDataUsingDataContract(CompositeType composite)
	{
		if (composite == null)
		{
			throw new ArgumentNullException("composite");
		}
		if (composite.BoolValue)
		{
			composite.StringValue += "Suffix";
		}
		return composite;
    }


    private DataHelper dbh = new DataHelper();

    #region Province
    public bool getProvinceList(out DataSet ds, out string errMsg)
    {
        ProvinceDL dl = new ProvinceDL();
        return dl.getProvinceList(out ds, out errMsg);
    }

    public bool getProvinceListByGrapherID(out DataSet ds, out string errMsg, long GrapherID)
    {
        ProvinceDL dl = new ProvinceDL();
        return dl.getProvinceListByGrapherID(out ds, out errMsg, GrapherID);
    }

    public bool getProvinceListException(out DataSet ds, out string errMsg, long GrapherID)
    {
        ProvinceDL dl = new ProvinceDL();
        return dl.getProvinceListException(out ds, out errMsg, GrapherID);
    }
    #endregion

    #region Place
    public bool getPlaceListByProvinceID(out DataSet ds, out string errMsg, int provinceID)
    {
        PlaceDL dl = new PlaceDL();
        return dl.getPlaceListByProvinceID(out ds, out errMsg, provinceID);
    }
    #endregion

    #region Grapher
    public bool insertGrapherRegister(out string errMsg, out long GrapherID, string GrapherEmail, string GrapherName, string GrapherSurname,
    string GrapherPersonalID, byte[] GrapherPhoto, string GrapherMobileNumber, string GrapherSex, string Password, int ProvinceID)
    {
        GrapherDL dl = new GrapherDL();
        return dl.insertGrapherRegister(out errMsg, out GrapherID, GrapherEmail, GrapherName, GrapherSurname, GrapherPersonalID, GrapherPhoto, GrapherMobileNumber, GrapherSex, Password, ProvinceID);
    }

    public bool insertGrapherRegisterMapEarningRate(out string errMsg, long GrapherID, int EventTypeID, double MorningRate, double AfternoonRate,
        double EveningRate, double FullDayRate)
    {
        GrapherDL dl = new GrapherDL();
        return dl.insertGrapherRegisterMapEarningRate(out errMsg, GrapherID, EventTypeID, MorningRate, AfternoonRate, EveningRate, FullDayRate);
    }

    public bool getGrapherProfileByGrapherID(out string errMsg, out string GrapherEmail, out string GrapherName, out string GrapherSurname, out string GrapherPersonalID,
        out string GrapherMobileNumber, out string GrapherSex, out int ProvinceID, long GrapherID)
    {
        GrapherDL dl = new GrapherDL();
        return dl.getGrapherProfileByGrapherID(out errMsg, out GrapherEmail, out GrapherName, out GrapherSurname, out GrapherPersonalID, 
        out GrapherMobileNumber, out GrapherSex, out ProvinceID, GrapherID);
    }

    public bool getGrapherEarningRateProfileByGrapherIDandEventTypeID(out string errMsg, out double MorningRate,
        out double AfternoonRate, out double EveningRate, out double FulldayRate, long GrapherID, int EventTypeID)
    {
        GrapherDL dl = new GrapherDL();
        return dl.getGrapherEarningRateProfileByGrapherIDandEventTypeID(out errMsg, out MorningRate,
        out AfternoonRate, out EveningRate, out FulldayRate, GrapherID, EventTypeID);
    }

    public bool IsAuthenticateForLogOn(out DataSet ds, out string errMsg, string userID, string password)
    {
        GrapherDL dl = new GrapherDL();
        return dl.IsAuthenticateForLogOn(out ds, out errMsg, userID, password);
    }

    public bool updateLoginFailCount(out int LoginFailCount, out string errMsg, string userID)
    {
        GrapherDL dl = new GrapherDL();
        return dl.updateLoginFailCount(out LoginFailCount, out errMsg, userID);
    }

    public bool getGrapherInfo(string userID, out DataSet ds, out string errMsg)
    {
        GrapherDL dl = new GrapherDL();
        return dl.getGrapherInfo(userID, out ds, out errMsg);
    }

    public bool updatedAuthenGrapher(string userID, string loginIP, string sessionId, out string errMsg)
    {
        GrapherDL dl = new GrapherDL();
        return dl.updatedAuthenGrapher(userID, loginIP, sessionId, out errMsg);
    }

    public bool forceGrapherLogout(string userID, out string errMsg)
    {
        GrapherDL dl = new GrapherDL();
        return dl.forceGrapherLogout(userID, out errMsg);
    }
    public bool LockedGrapher(out string errMsg, string userID)
    {
        GrapherDL dl = new GrapherDL();
        return dl.LockedGrapher(out errMsg, userID);
    }
    public bool insertMapProvince(out string errMsg, long GrapherID, int ProvinceID)
    {
        GrapherDL dl = new GrapherDL();
        return dl.insertMapProvince(out errMsg, GrapherID, ProvinceID);
    }
    public bool deleteMapProvince(out string errMsg, long GrapherID, int ProvinceID)
    {
        GrapherDL dl = new GrapherDL();
        return dl.deleteMapProvince(out errMsg, GrapherID, ProvinceID);
    }
    #endregion

    #region Booking
    public bool getGrapherForBooking(out DataSet ds, out string errMsg, string bookingDatetime, int bookingTypeID, int eventType, int provinceID, int placeID)
    {
        bool result = false;
        ds = new DataSet();
        errMsg = "";
        SqlConnection conn = dbh.getConnection();
        try
        {
            conn.Open();
            ds = SqlHelper.ExecuteDataset(conn, "cmr_getGrapherForBooking", bookingDatetime, bookingTypeID, eventType, provinceID, placeID);
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

    public bool insertBooking(out long bookingID, out string errMsg, string bookingDatetime, int bookingTypeID, int userID, int grapherID, int eventType, int provinceID, int placeID)
    {
        bool result = false;
        DataSet ds = new DataSet();
        errMsg = "";
        bookingID = 0;
        SqlConnection conn = dbh.getConnection();
        try
        {
            conn.Open();
            ds = SqlHelper.ExecuteDataset(conn, "cmr_insertBooking", bookingDatetime, bookingTypeID, userID, grapherID, eventType, provinceID, placeID);
            bookingID = Convert.ToInt64(ds.Tables[0].Rows[0][0]);
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

    public bool updateBookingStatus(out DataSet ds, out string errMsg, long bookingID, string bookingStatus)
    {
        BookingDL dl = new BookingDL();
        return dl.updateBookingStatus(out ds, out errMsg, bookingID, bookingStatus);
    }
    #endregion

    #region MiscellaneousDL
    public Byte[] getGrapherImage(int grapherID)
        {
            DataSet ds = null;
            byte[] _ImgData = null;
            SqlConnection conn = dbh.getConnection();
            try
            {
                ds = SqlHelper.ExecuteDataset(conn, "cmr_getGrapherPhotoByID", grapherID);
                if (ds != null)
                {
                    if (ds.Tables[0].Rows[0]["PHOTO"].ToString() == "") return null;
                    _ImgData = (Byte[])ds.Tables[0].Rows[0]["PHOTO"];
                }
            }
            catch
            {
                return null;
            }
            return _ImgData;
        }
    #endregion
}
