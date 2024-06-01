using System.Web;

namespace CRTLMCModInstaller.Core.Utility;

public class NetworkUtil
{
    public enum RequestMethod
    {
        Get,
        Post
    }
    
    public static Uri Morph(string uri)
    {
        string head = uri.Contains("https://") || uri.Contains("http://") ? "" : "https://";
        return new Uri(head + uri);
    }

    public static HttpRequestMessage BuildRequest(RequestMethod method, Uri requestUri, bool withUserAgent = true)
    {
        
        HttpRequestMessage msg =
            new HttpRequestMessage(new HttpMethod(method == RequestMethod.Get ? "GET" : "POST"), requestUri);
        
        if (withUserAgent)
            msg.Headers.Add("User-Agent", EnvUtil.TryGet("USER_AGENT_HEADER_VALUE", "Type-32/CRTLMCModInstaller/0.1.0-alpha (type32alt@outlook.com)"));

        return msg;
    }

    public class QueryBuilder
    {
        protected readonly Uri baseUri;

        public QueryBuilder(Uri uri)
        {
            this.baseUri = uri;
        }
        
        public QueryBuilder AddQuery(string name, string value)
        {
            var httpValueCollection = HttpUtility.ParseQueryString(baseUri.Query);

            httpValueCollection.Remove(name);
            httpValueCollection.Add(name, value);

            var ub = new UriBuilder(baseUri);
            ub.Query = httpValueCollection.ToString();

            return new QueryBuilder(ub.Uri);
        }

        public Uri Get()
        {
            return baseUri;
        }
    }
}