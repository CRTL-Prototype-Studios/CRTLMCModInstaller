namespace CRTLMCModInstaller.Core.Utility;

public class EnvUtil
{
    public static string? Get(string key)
    {
        return Environment.GetEnvironmentVariable(key);
    }
}