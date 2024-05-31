using System.Net;
using CRTLMCModInstaller.Core.References;
using CRTLMCModInstaller.Core.Utility;

namespace CRTLMCModInstaller.Core;

public class ModrinthManager
{
    public static Uri BaseUrl = NetworkUtil.Morph(EnvUtil.TryGet(EnvReferences.StagingApiUrlBase));

    public static bool TestRequest()
    {
        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = BaseUrl;

            HttpResponseMessage msg = new HttpResponseMessage();
            // msg.Headers.Add();
        }

        return true;
    }
}