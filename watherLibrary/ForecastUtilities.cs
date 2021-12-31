using System;
using System.Globalization;
using System.Text;

namespace weatherLibrary
{
    public class ForecastUtilities
    {
        public ForecastUtilities()
        {
        }
        public static DailyForecast Parse(string dailyForecastParametar)
        {
            string[] dailyForecastParametars = dailyForecastParametar.Split(',');
            DateTime day = DateTime.ParseExact(dailyForecastParametars[0], "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            Weather dayWeather = new Weather(
                Convert.ToDouble(dailyForecastParametars[1]),
                Convert.ToDouble(dailyForecastParametars[3]),
                Convert.ToDouble(dailyForecastParametars[2]));
            DailyForecast dailyForecast = new DailyForecast(day, dayWeather);
            return dailyForecast;
        }

        public static Weather FindWeatherWithLargestWindchill(Weather[] weathers)
        {
            double largestWindchill = 0;
            int index = 0;
            for (int i = 0; i < weathers.Length; i++)
            {
                if (weathers[i].CalculateWindChill() > largestWindchill)
                {
                    largestWindchill = weathers[i].CalculateWindChill();
                    index = i;
                }
            }
            return weathers[index];
        }

        public static void PrintWeathers(IPrinter[] printers, Weather[] weathers)
        {
            StringBuilder builder = new StringBuilder();
            foreach(Weather weather in weathers)
            {
                builder.Append(weather.ToString() + "\n");
            }
            foreach(IPrinter printer in printers)
            {
                printer.Print(builder.ToString());
            }
        }
    }
}
