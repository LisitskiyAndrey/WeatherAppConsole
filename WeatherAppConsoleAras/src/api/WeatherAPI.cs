using System;
using WeatherAppConsoleAras.src.ws;

namespace WeatherAppConsoleAras.src.api
{
    public class WeatherAPI
    {
        private static WebClient webClient = WebClient.builder("https://openweathermap.org/data/2.5").build();

        protected static Request request = Request.builder().getWebClient(webClient).build();

        public string authUser() { return new UserAPI().getUserKey(); }

        public Response getWeather(string cityName)
        {
            string wather = $"/weather?q={cityName}&appid={authUser()}";

            return request.get(wather)
                          .execute();
        }

        public WeatherAPI weather() { return new WeatherAPI(); }
    }
}
