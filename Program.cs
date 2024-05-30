using CRTLMCModInstaller.Core;

namespace CRTLMCModInstaller;

internal class Program
{
    static void Main(string[] args)
    {
        string id = "xYL9nIiR";
        Console.WriteLine(Directory.GetCurrentDirectory());
        InstallationManager.DownloadFileFromUrl($"https://api.modrinth.com/v2/version/{id}",
            Path.Join(Directory.GetCurrentDirectory(), "hello.jar"));
    }
}
