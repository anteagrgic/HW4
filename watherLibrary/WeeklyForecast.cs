using System;

namespace weatherLibrary
{
    public class WeeklyForecast
    {
        private DailyForecast[] dailyForecasts;
        public WeeklyForecast(DailyForecast[] dailyForecasts)
        {
            this.dailyForecasts = dailyForecasts;
        }
        public override string ToString()
        {
            string weeklyForecast = "";
            foreach (DailyForecast dailyForecast in dailyForecasts)
            {
                weeklyForecast += dailyForecast.ToString() + "\n";
            }
            return weeklyForecast;
        }
        public double GetMaxTemperature()
        {
            double maxTemperature = 0;
            foreach (DailyForecast dailyForecast in dailyForecasts)
            {
                if (maxTemperature < dailyForecast)
                {
                    maxTemperature = dailyForecast.DayWeather.GetTemperature();
                }
            }
            return maxTemperature;
        }
        public DailyForecast this[int i]
        {
            get
            {
                return dailyForecasts[i];
            }
        }

    }
}
