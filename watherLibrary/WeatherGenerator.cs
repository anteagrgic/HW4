using System;
namespace weatherLibrary
{
    public class WeatherGenerator
    {
        private double minTemperature;
        private double maxTemperature;
        private double minHumidity;
        private double maxHumidity;
        private double minWindSpeed;
        private double maxWindSpeed;
        private IRandomGenerator randomGenerator;

        public WeatherGenerator(double minTemperature, double maxTemperature, double minHumidity, double maxHumidity, double minWindSpeed, double maxWindSpeed, IRandomGenerator randomGenerator)
        {
            this.minTemperature = minTemperature;
            this.maxTemperature = maxTemperature;
            this.minHumidity = minHumidity;
            this.maxHumidity = maxHumidity;
            this.minWindSpeed = minWindSpeed;
            this.maxWindSpeed = maxWindSpeed;
            this.randomGenerator = randomGenerator;
        }

        public void SetGenerator(IRandomGenerator randomGenerator)
        {
            this.randomGenerator = randomGenerator;
        }

        public Weather Generate()
        {
            return new Weather(randomGenerator.NextCustom(minTemperature,maxTemperature),
                randomGenerator.NextCustom(minHumidity,maxHumidity),
                randomGenerator.NextCustom(minWindSpeed,maxWindSpeed));
        }
    }
}
