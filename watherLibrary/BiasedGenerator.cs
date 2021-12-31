using System;
namespace weatherLibrary
{
    public class BiasedGenerator : IRandomGenerator
    {
        private Random generator;

        public BiasedGenerator(Random generator)
        {
            this.generator = generator;
        }

        public double NextCustom(double min, double max)
        {
            if(generator.NextDouble() <= 2.0/3.0)
            {
                return generator.NextDouble() * (((max+min)/2) - min) +  min; //0,1,2, 0 naprema 1,2 => 1 naprema 2
            }
            return generator.NextDouble() * (max - ((max + min) / 2)) + (max + min) / 2;
        }
    }
}
