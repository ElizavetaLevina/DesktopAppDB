
using FluentFTP;
using System.Net;

namespace WinFormsApp1.Logic
{
    public class DBLogic
    {
        public static void CopyDB(string path)
        {
            var pickDatabaseFrom = Environment.CurrentDirectory;
            var srcFile = Path.Combine(pickDatabaseFrom, "computerservice.db");
            var destFile = Path.Combine(pickDatabaseFrom, path);
            if (File.Exists(destFile))
                File.Delete(destFile);

            File.Copy(srcFile, destFile);
        }

        public static void UpdateDB()
        {
            CopyDB("./Service/computerservice.db");
            var path = Path.Combine(Environment.CurrentDirectory, "./Service/computerservice.db");
            FtpClient client = new()
            {
                Host = "198.37.116.30",
                Credentials = new NetworkCredential("lizaveta", "wYwu6@L?2mhUT2?")
            };
            client.Connect();
            client.UploadFile(path, "www.webappdb.somee.com//computerservice.db");
        }
    }
}
