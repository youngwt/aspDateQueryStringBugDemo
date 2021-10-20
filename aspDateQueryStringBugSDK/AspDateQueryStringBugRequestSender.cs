using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace aspDateQueryStringBugSDK
{
    public class AspDateQueryStringBugRequestSender
    {
        private readonly HttpClient _httpClient;

        public AspDateQueryStringBugRequestSender()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:5001")
            };
        }

        public async Task<HttpResponseMessage> IsItChristmas(DateTime date)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            query.Add("date", date.ToString());

            var requestUri = $"/isitchristmas?{query}";

            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);

            return await _httpClient.SendAsync(request);
        }
    }
}
