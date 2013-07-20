using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CameRoomWeb.Enumeric;
using CameRoomWeb.Models;
using CameRoomWeb.Models.ProvinceModel;
using CameRoomWeb.Utilities;

namespace CameRoomWeb.Service
{
    public class GrapherService
    {
        private CameRoomService.ServiceClient _cmrWS;
        public GrapherService()
        {
            try
            {
                _cmrWS = new CameRoomService.ServiceClient();
            }
            catch (Exception ex)
            {

            }
        }
        public LogOnResultType CheckAuthenticate(string loginID, string password, out string msg)
        {
            DataSet ds = null;
            msg = "";
            if (_cmrWS.IsAuthenticateForLogOn(loginID, password, out ds, out msg))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    SetAuthenInfo(loginID);
                    bool IsActive = ds.Tables[0].Rows[0]["STATUS"].ToString() == "Y";
                    int LoginFailCount = Convert.ToInt16(ds.Tables[0].Rows[0]["LOGINFAILCOUNT"].ToString());
                    if (IsActive)
                    {
                        return LogOnResultType.SUCCESS;
                    }
                    else
                    {
                        msg = "User Locked.";
                        return LogOnResultType.USERLOCKED;
                    }

                }
                else
                {
                    int LoginFailCount = 0;
                    if (_cmrWS.updateLoginFailCount(loginID,out LoginFailCount, out msg))
                    {
                        SetAuthenInfo(loginID);
                        int MaxLogAttempt = Convert.ToInt16(ConfigurationManager.AppSettings["MaxLogAttempt"].ToString());
                        if (Convert.ToInt16(LoginFailCount) >= MaxLogAttempt)
                        {
                            if (_cmrWS.LockedGrapher(loginID, out msg))
                            {
                                msg = "Your login account has been locked, please contact administrator.";
                                return LogOnResultType.USERLOCKED;
                            }
                            else
                            {
                                msg = "Error : " + msg;
                                return LogOnResultType.FAILED;
                            }
                        }
                        else
                        {
                            int LoginFail = Convert.ToInt16(LoginFailCount);

                            msg = "Invalid Password, You only have " + (MaxLogAttempt - LoginFail) + " time(s) attempt";
                            return LogOnResultType.FAILED;
                        }
                    }
                    else
                    {
                        msg = "The user name is incorrect. " + msg;
                        return LogOnResultType.FAILED;
                    }
                }
            }
            else
            {
                msg = "Error : " + msg;
                return LogOnResultType.FAILED;
            }
        }
        public void SetAuthenInfo(string user)
        {
            string errMsg = "";
            DataSet ds = new DataSet();
            if (!_cmrWS.getGrapherInfo(user, out ds, out errMsg))
            {
                //WriteLog("getUserInfo (Error) : " + errMsg);
            }

            if (ds != null)
            {
                AuthenInfo info = new AuthenInfo();
                info.With(m =>
                {
                    m.LoginUserID = Convert.ToInt64(ds.Tables[0].Rows[0]["GRAPHERID"]); ;
                    m.LoginUserName = Convert.ToString(ds.Tables[0].Rows[0]["NAME"]);
                    m.ClientIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    m.UserLevel = Convert.ToString(ds.Tables[0].Rows[0]["GRAPHERLEVEL"]);
                    m.LastLogin = DateTime.Now;

                });

                HttpContext.Current.Session["LoginInfo"] = info;
                System.Web.SessionState.HttpSessionState ss = HttpContext.Current.Session;
                //Updated login info.
                //UpdateAuthenUsers(info, ss.SessionID);
                if (!_cmrWS.updatedAuthenGrapher(Convert.ToString(info.LoginUserID), info.ClientIP, ss.SessionID, out errMsg))
                {
                    //WriteLog("updatedAuthenUser (Error) : " + errMsg);
                }
            }
        }
        public string getPasswordSalt(string userID)
        {
            string errMsg = "";
            DataSet ds = new DataSet();
            string salt = "";
            try
            {
                if (!_cmrWS.getGrapherInfo(userID, out ds, out errMsg))
                {
                    //WriteLog("getUserInfo (Error) : " + errMsg);
                }
                if (ds != null)
                {
                    salt = Convert.ToString(ds.Tables[0].Rows[0]["PASSWORDSALT"]);
                }
                return salt;
            }
            catch
            {
                return "";
            }
        }
        public void SignOff()
        {
            string errMsg = string.Empty;
            AuthenInfo _info = new AuthenInfo();
            _info = (AuthenInfo)HttpContext.Current.Session["LoginInfo"];
            bool success = _cmrWS.forceGrapherLogout((_info.LoginUserID).ToString(), out errMsg);
            HttpContext.Current.Session.Abandon();
            if (!success)
            {
                //WriteLog(errMsg);
            }
        }
        public List<Province> getProvinceData()
        {
            return this.Provinces;
        }
        public List<Province> Provinces
        {
            get
            {
                List<Province> Provinces = new List<Province>();
                InitProvinceData(ref Provinces);
                return Provinces;
            }
        }
        private void InitProvinceData(ref List<Province> list)
        {
            try
            {
                DataSet ds = null;
                DataTable dt = null;
                string errMsg = "";
                AuthenInfo info = new AuthenInfo();
                info = (AuthenInfo)HttpContext.Current.Session["LoginInfo"];
                if (_cmrWS.getProvinceListByGrapherID(info.LoginUserID, out ds, out errMsg))
                {
                    dt = ds.Tables[0];
                    //dt.AsEnumerable().ToList();
                    list = (from DataRow row in dt.Rows
                            select new Province
                            {
                                RowNo = Convert.ToInt16(row["rowNumber"]),
                                ProvinceID = Convert.ToInt16(row["PROVINCEID"]),
                                ProvinceName = Convert.ToString(row["PROVINCENAME"])
                            }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<SelectListItem> GetProvinceListExceptionByGrapherID(long GrapherID)
        {
            string errMsg = "";
            DataSet ds = null;
            DataTable dt = null;
            if (!_cmrWS.getProvinceListException(GrapherID , out ds, out errMsg))
            {
                return null;
            }
            else
            {
                dt = ds.Tables[0];
                return Utilities.Utility.DT2SelectList(dt, "PROVINCEID", "PROVINCENAME");
            }
        }
    }
}