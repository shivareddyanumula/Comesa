<%@ WebHandler Language="C#" Class="DownloadHandler" %>

using System;
using System.Web;
using System.Net;
using System.IO;
public class DownloadHandler : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {

        string fileName = context.Request.QueryString["fileName"];
        string filePath = context.Request.QueryString["filePath"];
        context.Response.Clear();
        context.Response.ContentType = "application/vnd.ms-excel";
        context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
        string fileSeverPath = filePath;
        if (fileSeverPath != null)
        {
            byte[] fileBytes = GetFileBytes(fileSeverPath);
            context.Response.BinaryWrite(fileBytes);
            context.Response.Flush();
            File.Delete(fileSeverPath);
        }


    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

    protected byte[] GetFileBytes(string url)
    {
        WebRequest webRequest = WebRequest.Create(url);
        byte[] fileBytes = null;
        byte[] buffer = new byte[4096];
        WebResponse webResponse = webRequest.GetResponse();
        try
        {
            Stream stream = webResponse.GetResponseStream();
            MemoryStream memoryStream = new MemoryStream();
            int chunkSize = 0;
            do
            {
                chunkSize = stream.Read(buffer, 0, buffer.Length);
                memoryStream.Write(buffer, 0, chunkSize);
            } while (chunkSize != 0);

            fileBytes = memoryStream.ToArray();

        }
        catch (Exception ex)
        {

            // log it somewhere

        }
        return fileBytes;

    }
}
