using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace CameRoomWeb.Utilities
{
    public static class Utility
    {
        public static System.Web.Mvc.SelectList DT2SelectList(DataTable dt, string valueField, string textField)
        {
            if (dt == null || valueField == null || valueField.Trim().Length == 0
                || textField == null || textField.Trim().Length == 0)
                return null;

            var list = new List<Object>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                list.Add(new
                {
                    value = dt.Rows[i][valueField].ToString().Trim(),
                    text = dt.Rows[i][textField].ToString().Trim()
                });
            }
            return new System.Web.Mvc.SelectList(list.AsEnumerable(), "value", "text");
        }

        public static IEnumerable<SelectListItem> getPlaceListByProvinceID(int provinceID)
        {
            CameRoomService.ServiceClient cmrWS = new CameRoomService.ServiceClient();
            string errMsg = "";
            DataSet ds = null;
            DataTable dt = null;
            if (!cmrWS.getPlaceListByProvinceID(provinceID,out ds, out errMsg))
            {
                return null;
            }
            else
            {
                dt = ds.Tables[0];
                return DT2SelectList(dt, "PLACEID", "PLACENAME");
            }
        }

        public static void With<T>(this T item, Action<T> work)
        {
            work(item);
        }

        public static string stringToBase64(string st)
        {
            byte[] b = new byte[st.Length];
            for (int i = 0; i < st.Length; i++)
            {
                b[i] = Convert.ToByte(st[i]);
            }
            return Convert.ToBase64String(b);
        }

        public static string base64ToString(string st)
        {
            byte[] b;
            string s = "";
            try
            {
                b = Convert.FromBase64String(st);
            }
            catch (Exception e)
            {
                return e.Message;
            }
            for (int i = 0; i < b.Length; i++)
            {
                s += Convert.ToChar(b[i]);
            }
            return s;
        }
    }
}