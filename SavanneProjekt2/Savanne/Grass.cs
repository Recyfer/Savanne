using System;
using System.Threading;

namespace SavanneProjekt2.Savanne
{


    class Grass
    {
        public double weight;
        private bool isAlive;


        public Grass(Savannah s)
        {
            weight = 1 + s.rand1.NextDouble();
            isAlive = true;
        }
        public void grow()
        {
            while (isAlive == true)
            {
                weight *= 1.1;
                Thread.Sleep(1000);
            }
        }
    }
}
