using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SavanneProjekt2.Savanne
{
    internal class Rabbit : Animal
    {
        public Rabbit(Savannah s, int x, int y)
            : base(s, x, y)
        {
            weight = 9 + s.rand1.NextDouble();
            speed = 2;
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
                        if (posX + i != posX && posY + j != posY)
                        {
                            if (savannah.fields[posX + i, posY + j].animal != null)
                            {
                                if (savannah.fields[posX + i, posY + j].animal is Rabbit && gender == true &&
                                    savannah.fields[posX + i, posY + j].animal.gender == false)
                                {
                                    mate();
                                }
                            }
                            else if (savannah.fields[posX + i, posY + j].grass != null)
                            {
                                eat(posX + i, posY + j);
                            }
                        }
                    }
                }
            }
        }

        public void eat(int x, int y)
        {

            this.weight += savannah.fields[x, y].grass.weight;
            savannah.removeGrass(x, y);
        }

        public void mate()
        {
            for (int i = 0; i < 4; i++)
            {
                savannah.createRabbit();
            }
        }
    }
}
