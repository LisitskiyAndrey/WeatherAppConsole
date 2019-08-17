using RestSharp;

namespace WeatherAppConsoleAras.src.ws
{
    public class WebClient
    {
        private string baseUrl;
        private IRestResponse response;
        private RestClient httpClient;
        private RestRequest request;

        public WebClient() { }

        public WebClient(string baseUrl)
        {
            this.baseUrl = baseUrl;
            httpClient = new RestClient();
        }

        public static WebClientBuilder builder(string baseUrl)
        {
            return new WebClientBuilder(baseUrl);
        }

        public class WebClientBuilder
        {
            private string baseUrl;

            public WebClientBuilder(string baseUrl)
            {
                this.baseUrl = baseUrl;
            }

            public WebClient build()
            {
                return new WebClient(baseUrl);
            }
        }

        public WebClient executeGetRequest(string uri)
        {
            request = new RestRequest(baseUrl + uri, Method.GET);

            return processRequest();
        }

        public Response getResponse()
        {
            return new Response(response);
        }

        private WebClient processRequest()
        {
            response = httpClient.Execute(request);
            return this;
        }
    }

}
