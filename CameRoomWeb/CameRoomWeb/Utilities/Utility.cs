using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CameRoomWeb.Utilities
{
    public class Utility
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
    }


}