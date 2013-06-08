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
    bool getGrapherProfileByEmail(out string errMsg, out long GrapherID, out string GrapherName, out string GrapherSurname, out string GrapherPersonalID,
        out string GrapherMobileNumber, out string GrapherSex, out int ProvinceID, string GrapherEmail);

    [OperationContract]
    bool getGrapherEarningRateProfileByGrapherIDandGrapherEmail(out string errMsg, out double MorningRate,
        out double AfternoonRate, out double EveningRate, out double FulldayRate, long GrapherID, int EventTypeID);
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
