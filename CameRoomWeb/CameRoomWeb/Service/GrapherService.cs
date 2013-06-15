using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using CameRoomWeb.Enumeric;
using CameRoomWeb.Models;
using CameRoomWeb.Utilities;

namespace CameRoomWeb.Service
{
    public class GrapherService
    {
        private CameRoomService.ServiceClient service;
        public GrapherService()
        {
            try
            {
                service = new CameRoomService.ServiceClient();
            }
            catch (Exception ex)
            {

            }
        }
        public LogOnResultType CheckAuthenticate(string loginID, string password, out string msg)
        {
            DataSet ds = null;
            msg = "";
            if (service.IsAuthenticateForLogOn(loginID, password, out ds, out msg))
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
                    if (service.updateLoginFailCount(loginID,out LoginFailCount, out msg))
                    {
                        SetAuthenInfo(loginID);
                        int MaxLogAttempt = Convert.ToInt16(ConfigurationManager.AppSettings["MaxLogAttempt"].ToString());
                        if (Convert.ToInt16(LoginFailCount) >= MaxLogAttempt)
                        {
                            if (service.LockedGrapher(loginID, out msg))
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
            if (!service.getGrapherInfo(user, out ds, out errMsg))
            {
                //WriteLog("getUserInfo (Error) : " + errMsg);
            }

            if (ds != null)
            {
                AuthenInfo info = new AuthenInfo();
                info.With(m =>
                {
                    m.LoginUserID = user;
                    m.LoginUserName = Convert.ToString(ds.Tables[0].Rows[0]["NAME"]);
                    m.ClientIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    m.UserLevel = Convert.ToString(ds.Tables[0].Rows[0]["GRAPHERLEVEL"]);
                    m.LastLogin = DateTime.Now;

                });

                HttpContext.Current.Session["LoginInfo"] = info;
                System.Web.SessionState.HttpSessionState ss = HttpContext.Current.Session;
                //Updated login info.
                //UpdateAuthenUsers(info, ss.SessionID);
                if (!service.updatedAuthenGrapher(info.LoginUserID, info.ClientIP, ss.SessionID, out errMsg))
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
                if (!service.getGrapherInfo(userID, out ds, out errMsg))
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
            bool success = service.forceGrapherLogout(_info.LoginUserID, out errMsg);
            HttpContext.Current.Session.Abandon();
            if (!success)
            {
                //WriteLog(errMsg);
            }
        }
    }
}