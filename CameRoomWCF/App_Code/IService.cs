using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{

	[OperationContract]
	string GetData(int value);

	[OperationContract]
	CompositeType GetDataUsingDataContract(CompositeType composite);

    #region Provice
    [OperationContract]
    bool getProvinceList(out DataSet ds, out string errMsg);
    #endregion

    #region Place
    [OperationContract]
    bool getPlaceListByProvinceID(out DataSet ds, out string errMsg, int provinceID);
    #endregion

    #region Grapher
    [OperationContract]
    bool insertGrapherRegister(out string errMsg, out long GrapherID, string GrapherEmail, string GrapherName, string GrapherSurname,
    string GrapherPersonalID, byte[] GrapherPhoto, string GrapherMobileNumber, string GrapherSex, string Password, int ProvinceID);

    [OperationContract]
    bool insertGrapherRegisterMapEarningRate(out string errMsg, long GrapherID, int EventTypeID, double MorningRate, double AfternoonRate,
        double EveningRate, double FullDayRate);

    [OperationContract]
    bool getGrapherProfileByGrapherID(out string errMsg, out string GrapherEmail, out string GrapherName, out string GrapherSurname, out string GrapherPersonalID,
        out string GrapherMobileNumber, out string GrapherSex, out int ProvinceID, long GrapherID);

    [OperationContract]
    bool getGrapherEarningRateProfileByGrapherIDandEventTypeID(out string errMsg, out double MorningRate,
        out double AfternoonRate, out double EveningRate, out double FulldayRate, long GrapherID, int EventTypeID);
    #endregion

    #region Booking
    [OperationContract]
    bool getGrapherForBooking(out DataSet ds, out string errMsg, string bookingDatetime, int bookingTypeID, int eventType, int provinceID, int placeID);
    #endregion

    #region Booking
    [OperationContract]
    bool getGrapherForBooking(out DataSet ds, out string errMsg, string bookingDatetime, int bookingTypeID, int eventType, int provinceID, int placeID);
    [OperationContract]
    bool insertBooking(out long bookingID, out string errMsg, string bookingDatetime, int bookingTypeID, int userID, int grapherID, int eventType, int provinceID, int placeID);
    #endregion

    #region MiscellaneousDL
    [OperationContract]
    Byte[] getGrapherImage(int grapherID);
    #endregion
    // TODO: Add your service operations here
}

// Use a data contract as illustrated in the sample below to add composite types to service operations.
[DataContract]
public class CompositeType
{
	bool boolValue = true;
	string stringValue = "Hello ";

	[DataMember]
	public bool BoolValue
	{
		get { return boolValue; }
		set { boolValue = value; }
	}

	[DataMember]
	public string StringValue
	{
		get { return stringValue; }
		set { stringValue = value; }
	}
}
