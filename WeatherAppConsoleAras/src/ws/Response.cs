using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace WeatherAppConsoleAras.src.ws
{
    public class Response
    {
        private IRestResponse response;
        private string body;

        public Response(IRestResponse response)
        {
            this.response = response;
        }

        public string getBody()
        {
            body = response.Content;
            return body;
        }

        public JObject getBodyAsJson()
        {
            return JObject.Parse(getBody());
        }

        public T getResponseBodyAs<T>()
        {
            JsonSerializer s = new JsonSerializer();
            return s.Deserialize<T>(new JsonTextReader(new StringReader(getBody())));
        }
    }
}