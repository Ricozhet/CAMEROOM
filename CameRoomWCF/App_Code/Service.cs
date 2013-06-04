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
    public bool insertGrapherRegister(out string errMsg, string GrapherEmail, string GrapherName, string GrapherSurname,
    string GrapherPersonalID, string GrapherMobileNumber, string GrapherSex, string Password, int ProvinceID)
    {
        GrapherDL dl = new GrapherDL();
        return dl.insertGrapherRegister(out errMsg, GrapherEmail, GrapherName, GrapherSurname, GrapherPersonalID, GrapherMobileNumber, GrapherSex, Password, ProvinceID);
    }
    #endregion


}
