using System;
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
    #endregion

    #region Place
    public bool getPlaceListByProvinceID(out DataSet ds, out string errMsg, int provinceID)
    {
        PlaceDL dl = new PlaceDL();
        return dl.getPlaceListByProvinceID(out ds, out errMsg, provinceID);
    }
    #endregion

    #region Grapher
    public bool insertGrapherRegister(out string errMsg, string GrapherEmail, string GrapherName, string GrapherSurname,
    string GrapherPersonalID, byte[] GrapherPhoto, string GrapherMobileNumber, string GrapherSex, string Password, int ProvinceID)
    {
        GrapherDL dl = new GrapherDL();
        return dl.insertGrapherRegister(out errMsg, GrapherEmail, GrapherName, GrapherSurname, GrapherPersonalID, GrapherPhoto, GrapherMobileNumber, GrapherSex, Password, ProvinceID);
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
    #endregion
}
