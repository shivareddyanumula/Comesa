
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SMHR;

namespace SPMS
{
    public class Pms_dal
    {
        static string strConn = ConfigurationManager.ConnectionStrings["connection"].ToString();
        static string strpms = ConfigurationManager.ConnectionStrings["connection"].ToString();
        static string str_conn = ConfigurationManager.ConnectionStrings["connection"].ToString();

        static string strProvider = ConfigurationManager.ConnectionStrings["connection"].ProviderName.ToString();
        static DataTable dt;

        public static DataTable ExecuteQuery(string Query)
        {
            dt = new DataTable();
            switch (strProvider.ToUpper())
            {
                case "SQLSERVER":
                    dt = SqlHelper.ExecuteDataset(strConn, CommandType.Text, Query).Tables[0];
                    break;

            }
            return dt;
        }
        public static bool ExecuteNonQuery(string Query)
        {
            bool Exec = false;
            switch (strProvider.ToUpper())
            {
                case "SQLSERVER":
                    Exec = Convert.ToBoolean(SqlHelper.ExecuteNonQuery(strConn, CommandType.Text, Query));
                    break;

            }
            return Exec;
        }

    }
}
