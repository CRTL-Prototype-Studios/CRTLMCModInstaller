namespace CRTLMCModInstaller.Core.Utility;

public class EnvUtil
{
    public static string? Get(string key)
    {
        return Environment.GetEnvironmentVariable(key);
    }
    
    public static string? TryGet(string key, string altValue = "")
    {
        return Get(key) == null ? altValue : Get(key);
    }
}