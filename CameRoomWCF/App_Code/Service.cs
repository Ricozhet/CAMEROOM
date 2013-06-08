using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

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

    public bool getGrapherProfileByEmail(out string errMsg, out long GrapherID, out string GrapherName, out string GrapherSurname, out string GrapherPersonalID,
       out string GrapherMobileNumber, out string GrapherSex, out int ProvinceID, string GrapherEmail)
    {
        GrapherDL dl = new GrapherDL();
        return dl.getGrapherProfileByEmail(out errMsg, out GrapherID, out GrapherName, out GrapherSurname, out GrapherPersonalID,
        out GrapherMobileNumber, out GrapherSex, out ProvinceID, GrapherEmail);
    }

    public bool getGrapherEarningRateProfileByGrapherIDandGrapherEmail(out string errMsg, out double MorningRate,
        out double AfternoonRate, out double EveningRate, out double FulldayRate, long GrapherID, int EventTypeID)
    {
        GrapherDL dl = new GrapherDL();
        return dl.getGrapherEarningRateProfileByGrapherIDandGrapherEmail(out errMsg, out MorningRate,
        out AfternoonRate, out EveningRate, out FulldayRate, GrapherID, EventTypeID);
    }

    #endregion


}
