using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Threading;
using System.Data;

public partial class HR_XML : System.Web.UI.Page
{
    private DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            dt.Columns.Clear();
            dt.Columns.Add("FILENAME");
            dt.Columns.Add("CDATE");
            dt.Columns.Add("PATH");

            DirectoryInfo parentDir;
            FileInfo[] childFiles;

            parentDir = new DirectoryInfo(Server.MapPath("~/XML/"));
            childFiles = parentDir.GetFiles();
            foreach (FileInfo chDir in childFiles)
            {
                if (chDir.Extension != ".scc" && chDir.Name.Contains("MST"))
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = Convert.ToString(chDir.Name);
                    dr[1] = Convert.ToString(chDir.CreationTime);
                    dr[2] = Convert.ToString(chDir.FullName);
                    dt.Rows.Add(dr);
                }
            }

            RG_Files.DataSource = dt;
            RG_Files.DataBind();
        }
    }

    protected void lnk_Download_onCommand(object sender, CommandEventArgs e)
    {
        bool success = ResponseFile(Page.Request, Page.Response, Convert.ToString(e.CommandName), Convert.ToString(e.CommandArgument), 1024000);
        if (!success)
            Response.Write("Downloading Error!");
        Page.Response.End();

    }

    public static bool ResponseFile(HttpRequest _Request, HttpResponse _Response, string _fileName, string _fullPath, long _speed)
    {
        try
        {
            FileStream myFile = new FileStream(_fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            BinaryReader br = new BinaryReader(myFile);
            try
            {
                _Response.AddHeader("Accept-Ranges", "bytes");
                _Response.Buffer = false;
                long fileLength = myFile.Length;
                long startBytes = 0;

                int pack = 10240; //10K bytes
                int sleep = (int)Math.Floor((double)(1000 * pack / _speed)) + 1;
                if (_Request.Headers["Range"] != null)
                {
                    _Response.StatusCode = 206;
                    string[] range = _Request.Headers["Range"].Split(new char[] { '=', '-' });
                    startBytes = Convert.ToInt64(range[1]);
                }
                _Response.AddHeader("Content-Length", (fileLength - startBytes).ToString());
                if (startBytes != 0)
                {
                    _Response.AddHeader("Content-Range", string.Format(" bytes {0}-{1}/{2}", startBytes, fileLength - 1, fileLength));
                }
                _Response.AddHeader("Connection", "Keep-Alive");
                _Response.ContentType = "application/octet-stream";
                _Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(_fileName, System.Text.Encoding.UTF8));

                br.BaseStream.Seek(startBytes, SeekOrigin.Begin);
                int maxCount = (int)Math.Floor((double)((fileLength - startBytes) / pack)) + 1;

                for (int i = 0; i < maxCount; i++)
                {
                    if (_Response.IsClientConnected)
                    {
                        _Response.BinaryWrite(br.ReadBytes(pack));
                        Thread.Sleep(sleep);
                    }
                    else
                    {
                        i = maxCount;
                    }
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                br.Close();
                myFile.Close();
            }
        }
        catch
        {
            return false;
        }
        return true;
    }
}
