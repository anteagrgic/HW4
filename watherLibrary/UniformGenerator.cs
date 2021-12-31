using System;
namespace weatherLibrary
{
    public class UniformGenerator : IRandomGenerator
    {
        private Random generator;

        public UniformGenerator(Random generator)
        {
            this.generator = generator;
        }

        public double NextCustom(double min, double max)
        {
            return generator.NextDouble() * (max - min) + min;
        }
    }
}
