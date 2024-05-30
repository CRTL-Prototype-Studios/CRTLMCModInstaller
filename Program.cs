using CRTLMCModInstaller.Core;

namespace CRTLMCModInstaller;

internal class Program
{
    static void Main(string[] args)
    {
        string id = "xYL9nIiR";
        InstallationManager.DownloadFileFromUrl($"https://api.modrinth.com/v2/version/{id}", "Test");
    }
}
