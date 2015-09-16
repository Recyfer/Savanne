using System;

namespace SavanneProjekt2.Savanne
{


    class Grass
    {
        public double weight;
        private bool isAlive;


        public Grass()
        {
            weight = 1 + new Random().NextDouble();
        }
        public void grow()
        {
            while (isAlive == true)
            {
                weight *= 1.1;
            }
        }
    }
}
