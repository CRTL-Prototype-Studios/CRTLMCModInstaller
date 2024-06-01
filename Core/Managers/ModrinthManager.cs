using System.Net;
using CRTLMCModInstaller.Core.Foundation.Modrinth;
using CRTLMCModInstaller.Core.References;
using CRTLMCModInstaller.Core.Utility;

namespace CRTLMCModInstaller.Core;

public class ModrinthManager
{
    public static Uri BaseUrl = NetworkUtil.Morph(EnvUtil.TryGet(EnvReferences.StagingApiUrlBase));
    public static string DownloadDirectory = Directory.GetCurrentDirectory();

    public static async Task<bool> TestRequest()
    {
        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = BaseUrl;

            HttpResponseMessage res = await client.GetAsync(new Uri(""));
            return res.IsSuccessStatusCode;
        }
    }

    public static async Task<HttpContent> SearchProjects(string query)
    {
        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = BaseUrl;
            Uri queryUri = new NetworkUtil.QueryBuilder(new Uri("search"))
                .AddQuery("query", query)
                .Get();
            HttpRequestMessage req = NetworkUtil.BuildRequest(NetworkUtil.RequestMethod.Get, queryUri);
            
            HttpResponseMessage res = await client.SendAsync(req);

            return res.Content;
        }
    }

    public static async Task<HttpContent> SearchProjects(string query, ModrinthFoundations.ModrinthCategories mdlCategories, string[] modMcVersions)
    {
        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = BaseUrl;

            string versions = "";
            foreach (string i in modMcVersions)
            {
                versions += $"\"versions:{i}\"";
            }
            
            Uri queryUri = new NetworkUtil.QueryBuilder(new Uri("search"))
                .AddQuery("query", query)
                .AddQuery("facets",$"[[\"categories:{ModrinthFoundations.GetCategoryString(mdlCategories)}\"],[{versions}]]")
                .Get();
            HttpRequestMessage req = NetworkUtil.BuildRequest(NetworkUtil.RequestMethod.Get, queryUri);
            
            HttpResponseMessage res = await client.SendAsync(req);

            return res.Content;
        }
    }

    public static async Task<HttpContent> GetProject(string projectId)
    {
        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = BaseUrl;
            HttpRequestMessage mes = NetworkUtil.BuildRequest(NetworkUtil.RequestMethod.Get,
                new Uri(Path.Join("project", projectId)));

            HttpResponseMessage res = await client.SendAsync(mes);

            return res.Content;
        }
    }
}