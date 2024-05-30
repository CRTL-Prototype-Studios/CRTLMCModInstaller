using System.Net;

namespace CRTLMCModInstaller.Core;

public class InstallationManager
{
    public static void DownloadFileFromUrl(string url, string outputPath)
    {
        using (WebClient client = new WebClient())
        {
            try
            {
                Console.WriteLine("Downloading file from: " + url);
                client.DownloadFile(new Uri(url), outputPath);
                Console.WriteLine("File downloaded successfully!");
            }
            catch (WebException ex)
            {
                Console.WriteLine("An error occurred while downloading the file:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}