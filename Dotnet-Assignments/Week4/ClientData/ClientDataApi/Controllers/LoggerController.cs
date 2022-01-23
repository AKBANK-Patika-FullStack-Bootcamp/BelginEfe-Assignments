using Microsoft.AspNetCore.Mvc;

namespace ClientDataApi.Controllers
{
    public class LoggerController : ControllerBase
    {
        string LogPath = @"C:\Users\Belgin\Desktop\Akbank Full Stack Bootcamp\BelginEfe-Assignments\Dotnet-Assignments\Week1\ClientData\ClientDataApi\Log\";

        string LogFileName = DateTime.Now.ToString("yyyyMMdd") + ".txt";

        public void CreateLog(string message)

        {
            FileStream fs = new FileStream(LogPath + LogFileName, FileMode.Append, FileAccess.Write);

            StreamWriter streamWriter = new StreamWriter(fs);
            streamWriter.WriteLine(DateTime.Now.ToString() + " : " + message);
            streamWriter.Flush();
            streamWriter.Close();
            fs.Close();
        }
    }
}
