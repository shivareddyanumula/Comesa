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
using System.Data.SqlClient;

namespace SMHR
{
    // ----------------------------------------------------------------------------------------
    // Author:                    Dhanush InfoTech Pvt Ltd
    // Company:   Dhanush InfoTech Pvt Ltd
    // Assembly version:          
    // Date:                      7/22/2010
    // Time:                      16:30
    // Project Item Name:         Dal
    // Project Item Filename:     Dal.cs
    // Project Item Kind:         Code
    // Class FullName:            SMHR.Dal
    // Class Name:                Dal
    // Class Kind Description:    Class
    // Purpose:                   Data Access Layer
    // ----------------------------------------------------------------------------------------
    public static class Dal
    {
        static string strConn = ConfigurationManager.ConnectionStrings["connection"].ToString();
        //static string str_conn = ConfigurationManager.ConnectionStrings["connection1"].ToString();
        //static string strConn_Rec = ConfigurationManager.ConnectionStrings["connection2"].ToString();
        //static string strProvider_Rec = ConfigurationManager.ConnectionStrings["connection2"].ProviderName.ToString();
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
                case "ORACLE":
                    dt = OleDbHelper.ExecuteDataset(strConn, CommandType.Text, Query).Tables[0];
                    break;
                default:
                    dt = OleDbHelper.ExecuteDataset(strConn, CommandType.Text, Query).Tables[0];
                    break;
            }
           return dt;
        }

        //public static DataTable ExecuteQuery_1(string Query)
        //{
        //    dt = new DataTable();
        //    switch (strProvider.ToUpper())
        //    {
        //        case "SQLSERVER":
        //            dt = SqlHelper.ExecuteDataset(str_conn, CommandType.Text, Query).Tables[0];
        //            break;
        //        case "ORACLE":
        //            dt = OleDbHelper.ExecuteDataset(str_conn, CommandType.Text, Query).Tables[0];
        //            break;
        //        default:
        //            dt = OleDbHelper.ExecuteDataset(strConn, CommandType.Text, Query).Tables[0];
        //            break;
        //    }
        //    return dt;
        //}
        public static int ExecuteNonQuery(string spName, SqlParameter[] sqlParameters)
        {
            SqlConnection con = new SqlConnection(strConn);
            int result = 0;
            try
            {                
                con.Open();
                SqlCommand cmd = new SqlCommand(spName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(sqlParameters);
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return result;
        }
        public static bool ExecuteNonQuery(string Query)
        {
            bool Exec = false;
            switch (strProvider.ToUpper())
            {
                case "SQLSERVER":
                    Exec = Convert.ToBoolean(SqlHelper.ExecuteNonQuery(strConn, CommandType.Text, Query));
                    break;
                case "ORACLE":
                    Exec = Convert.ToBoolean(OleDbHelper.ExecuteNonQuery(strConn, CommandType.Text, Query));
                    break;
                default:
                    Exec = Convert.ToBoolean(OleDbHelper.ExecuteNonQuery(strConn, CommandType.Text, Query));
                    break;
            }
            SqlConnection con1 = new SqlConnection(strConn);
            //string s1 = "SmartHR";
            //string s2 = "";
            //int id = 0;
            //SqlCommand cmd1 = new SqlCommand();
            ////if (dt.Rows[0][0] != DBNull.Value)
            ////{
            //cmd1 = new SqlCommand("insert into SMHR_TRACELOG(SMHR_TRCLOG_USERID,SMHR_TRCLOG_QUERY,SMHR_TRCLOG_CONCT,SMHR_TRCLOG_FORMNME,SMHR_TRCLOG_DATE,SMHR_TRCLOG_TIME)values('" +1 + "','" + Query.Replace("'", "''") + "','" + s2 + "','" + s1 + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "')", con1);
            //con1.Open();
            //cmd1.ExecuteNonQuery();
            //}
           return Exec;
        }

        //public static DataTable ExecuteQuery_New(string Query)
        //{
        //    dt = new DataTable();
        //    switch (strProvider_Rec.ToUpper())
        //    {
        //        case "SQLSERVER":
        //            dt = SqlHelper.ExecuteDataset(strConn_Rec, CommandType.Text, Query).Tables[0];
        //            break;
        //        case "ORACLE":
        //            dt = OleDbHelper.ExecuteDataset(strConn_Rec, CommandType.Text, Query).Tables[0];
        //            break;
        //        default:
        //            dt = OleDbHelper.ExecuteDataset(strConn_Rec, CommandType.Text, Query).Tables[0];
        //            break;
        //    }
        //    return dt;
        //}

    }
}