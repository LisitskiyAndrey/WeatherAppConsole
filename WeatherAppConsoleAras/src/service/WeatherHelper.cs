using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WeatherAppConsoleAras.src.service
{
    public class WeatherHelper : ServiceWether
    {
        public static string getWeatherFor(string city)
        {
            var path = $"{GetProjectpath()}weather.txt";

            if (!File.Exists(path))
            {
                File.AppendAllText(path, Environment.NewLine);
            }

            string weatherInfo = null;
            string line;

            DateTime previousRequest = new DateTime();
            List<string> list = new List<string>();

            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }

            foreach (string weatherIn in list)
            {
                string[] words = weatherIn.Trim().Split(new char[] { '|' });
                if (words[0].Equals(city))
                {
                    weatherInfo = words[2].Trim().Split(new char[] { ':' })[2];
                    previousRequest = Convert.ToDateTime(words[1]);
                }
            }

            TimeSpan time = DateTime.Now - previousRequest;

            if (weatherInfo != null && time.Minutes < 60)
            {
                return weatherInfo.Trim();
            }
            weatherInfo = weather.getWeather(city).getResponseBodyAs<WeatherInfo>().weather.First().ToString();
            File.AppendAllText(path, city + "|" + DateTime.Now.ToString() + "|" + weatherInfo);
            File.AppendAllText(path, Environment.NewLine);

            return weatherInfo;
        }

        private static string GetProjectpath()
        {
            var directory = Directory.GetCurrentDirectory();
            return directory.Split("bin")[0];
        }
    }
}
