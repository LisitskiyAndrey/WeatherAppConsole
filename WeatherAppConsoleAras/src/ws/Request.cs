namespace WeatherAppConsoleAras.src.ws
{
    public class Request
    {
        private WebClient webClient;

        Request(WebClient webClient)
        {
            this.webClient = webClient;
        }

        public GetRequestBuilder get(string uri)
        {
            return new GetRequestBuilder(uri, webClient);
        }

        public class GetRequestBuilder
        {
            private string uri;
            private WebClient webClient;

            public GetRequestBuilder() { }

            public GetRequestBuilder(string uri, WebClient webClient)
            {
                this.uri = uri;
                this.webClient = webClient;
            }

            public Response execute()
            {
                return webClient.executeGetRequest(uri).getResponse();
            }
        }

        public static BuilderExampleBuilder builder()
        {
            return new BuilderExampleBuilder();
        }

        public class BuilderExampleBuilder
        {
            private WebClient webClient;

            public WebClient getClient()
            {
                return webClient;
            }

            public BuilderExampleBuilder getWebClient(WebClient webClient)
            {
                this.webClient = webClient;
                return this;
            }

            public Request build()
            {
                return new Request(webClient);
            }
        }
    }
}
