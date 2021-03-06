﻿using System;
using System.Threading;

namespace SavanneProjekt2.Savanne
{
    internal class Lion : Animal
    {
        public Lion(Savannah s, int x, int y)
            : base(s, x, y)
        {
            weight = 49 + s.rand1.NextDouble();
            speed = 1;
        }


        public override void vicinity()
        {
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (posX + i < 0 || posY + j < 0 || posX + i > 19 || posY + j > 19)
                    {
                        continue;
                    }
                    else
                    {
                            if (savannah.fields[posX + i, posY + j].animal != null)
                            {
                                if (savannah.fields[posX + i, posY + j].animal is Rabbit)
                                {
                                    eat(posX + i, posY + j);
                                }
                                if (savannah.fields[posX + i, posY + j].animal is Lion && savannah.fields[posX + i, posY + j].animal.gender != this.gender)
                                {
                                    mate();
                                }
                            }
                    }
                }
            }
            savannah.drawAll();
        }

        public void eat(int x, int y)
        {
            this.weight += savannah.fields[x, y].animal.weight;
            savannah.removeAnimal(x, y);
            savannah.drawAll();
        }

        public void mate()
        {
            for (int i = 0; i < 2; i++)
            {
                savannah.createLion();
            }
        }
    }
}
