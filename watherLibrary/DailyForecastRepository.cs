using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace weatherLibrary
{
    public class DailyForecastRepository : IEnumerator<DailyForecast>, IEnumerable<DailyForecast>
    {
        List<DailyForecast> dailyForecasts;

        private int currentIndex;
        private DailyForecast currentDailyForecast;

        public DailyForecast Current => currentDailyForecast;

        object IEnumerator.Current => Current;

        public void Add(DailyForecast a)
        {
            foreach (DailyForecast daily in dailyForecasts)
            {
                if (daily.Day.Date == a.Day.Date)
                {
                    dailyForecasts.Remove(daily);
                    break;
                }
            }

            int counter = 0;
            foreach (DailyForecast daily in dailyForecasts)
            {
                if (daily.Day.Date > a.Day.Date)
                {
                    dailyForecasts.Insert(counter, a);
                    break;
                }
                counter++;
            }

            if (counter == (dailyForecasts.Count))
            {
                dailyForecasts.Add(a);
            }
        }

        public DailyForecastRepository(DailyForecastRepository dailyForecastRepository)
        {
            dailyForecasts = new List<DailyForecast>();

            foreach (DailyForecast daily in dailyForecastRepository)
            {
                this.Add(daily);
            }
        }

        public void Add(List<DailyForecast> DailyForecasts)
        {
            foreach (DailyForecast daily in DailyForecasts)
            {
                this.Add(daily);
            }
        }

        public void Remove(DateTime dateTime)
        {
            foreach (DailyForecast daily in dailyForecasts)
            {
                if (daily.Day.Date == dateTime.Date)
                {
                    dailyForecasts.Remove(daily);
                    break;
                }
            }

            throw new NoSuchDailyWeatherException("No daily forecast for " + dateTime.Date);
        }

        public bool MoveNext()
        {
            if (++currentIndex >= dailyForecasts.Count)
            {
                return false;
            }
            else
            {
                currentDailyForecast = dailyForecasts[currentIndex];
            }

            return true;
        }

        public void Reset()
        {
            currentIndex = -1;
        }

        public void Dispose()
        {

        }

        public IEnumerator<DailyForecast> GetEnumerator()
        {
            return dailyForecasts.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public DailyForecastRepository()
        {
            dailyForecasts = new List<DailyForecast>();
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (DailyForecast daily in dailyForecasts)
            {
                builder.AppendLine(daily.ToString());
            }
            return builder.ToString();
        }
    }
}
