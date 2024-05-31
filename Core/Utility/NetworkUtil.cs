namespace CRTLMCModInstaller.Core.Utility;

public class NetworkUtil
{
    
    public static Uri Morph(string uri)
    {
        string head = uri.Contains("https://") || uri.Contains("http://") ? "" : "https://";
        return new Uri(head + uri);
    }
}