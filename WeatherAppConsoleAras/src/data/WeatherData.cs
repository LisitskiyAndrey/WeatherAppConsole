using System;
using Newtonsoft.Json;

namespace WeatherAppConsoleAras.src.data
{
    [Serializable]
    public class WeatherData
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("main")]
        public string main { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        public override string ToString()
        {
            return "Main: " + main + ", description: " + description;
        }
    }
}
