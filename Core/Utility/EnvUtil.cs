namespace CRTLMCModInstaller.Core.Utility;

public class EnvUtil
{
    public static string? Get(string key)
    {
        return Environment.GetEnvironmentVariable(key);
    }
    
    public static string? TryGet()
    {
        return "GitHub no let me push";
    }
}