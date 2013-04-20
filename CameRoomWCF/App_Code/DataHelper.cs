using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DataHelper
/// </summary>
public class DataHelper
{
	public DataHelper()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public SqlConnection getConnection()
    {
        string data = ConfigurationManager.ConnectionStrings["dbConnection"].ToString();
        return new SqlConnection(data);
    }
}