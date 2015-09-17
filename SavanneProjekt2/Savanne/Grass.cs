using System;
using System.Threading;

namespace SavanneProjekt2.Savanne
{


    class Grass
    {
        public double weight;
        private bool isAlive;
        public int posX;
        public int posY;


        public Grass(Savannah s, int x, int y)
        {
            weight = 1 + s.rand1.NextDouble();
            isAlive = true;
            posX = x;
            posY = y;
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
