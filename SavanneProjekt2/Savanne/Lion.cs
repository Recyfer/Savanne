using System;
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


        public void vicinity()
        {
            for (int i = -1; i < 2; i++)
            {
                for (int j = 1; j < 2; j++)
                {
                    if (posX + i < 0 || posY + j < 0 || posX + i > 19 || posY + j > 19)
                    {

                    }
                    else
                    {
                        if (posX + i != posX && posY + j != posY)
                        {
                            if (savannah.fields[posX + i, posY + j].animal != null)
                            {
                                if (savannah.fields[posX + i, posY + j].animal is Rabbit)
                                {
                                    eat(posX + i, posY + j);
                                }
                                else if (savannah.fields[posX + i, posY + j].animal is Lion && gender == true &&
                                         savannah.fields[posX + i, posY + j].animal.gender == false)
                                {
                                    mate();
                                }
                            }
                        }
                    }
                }
            }
        }

        public void eat(int x, int y)
        {
            this.weight += savannah.fields[x, y].animal.weight;
            savannah.removeAnimal(x, y);
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
