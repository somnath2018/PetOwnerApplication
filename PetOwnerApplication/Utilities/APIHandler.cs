namespace PetOwnerApplication.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using Models;

    public class ApiHandler
    {
        public static string GetApiResult(string apiUri, Dictionary<string, string> headerDetails = null, bool useProxy = false, ProxyDetail proxyDetail = null)
        {
            var httpClientHandler = new HttpClientHandler();
            if (useProxy && proxyDetail != null)
            {
                httpClientHandler.Proxy = new WebProxy($"{proxyDetail.Url}:{proxyDetail.Port}", false);
                httpClientHandler.UseProxy = true;
            }
            using (var httpClient = new HttpClient(httpClientHandler))
            {
                httpClient.DefaultRequestHeaders.Clear();
                if (headerDetails != null)
                {
                    foreach (KeyValuePair<string, string> header in headerDetails)
                    {
                        httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }

                    httpClient.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                }

                return httpClient.GetStringAsync(new Uri(apiUri)).Result;
            }
        }
    }
}
