using System;
using WeatherAppConsoleAras.src.service;

namespace WeatherAppConsoleAras
{
    class Program
    {
        static void Main(string[] args)
        {
            bool endOfProgram;
            do
            {
                endOfProgram = false;

                Console.WriteLine("Please, enter the city's name");
                var city = Console.ReadLine();
                try
                {
                    Console.WriteLine($"You have entered {city}");

                    string weatherInfo = WeatherHelper.getWeatherFor(city);
                    Console.WriteLine($"The weather is '{weatherInfo}'");

                    endOfProgram = tryAgain(endOfProgram);
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERROR =========>>>>>> " + e);
                    Console.WriteLine($"Sorry, but this city [{city}] has not yet been built.");
                    endOfProgram = tryAgain(endOfProgram);
                }
            } while (endOfProgram);

        }

        private static bool tryAgain(bool end)
        {
            if (end.Equals(true))
            {
                return end;
            }

            Console.WriteLine("Try again? (yes/no)");

            var result = Console.ReadLine().ToLower();

            if (result.Trim().Equals("yes"))
            {
                return true;
            }
            if (result.Trim().Equals("no"))
            {
                return false;
            }
            Console.WriteLine("You have only these options. (yes/no)");
            return tryAgain(end);
        }
    }
}
