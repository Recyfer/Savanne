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
        protected Rabbit(Savannah s)
            : base(s)
        {
            weight = 9 + new Random().NextDouble();
        }

        public void move()
        {
            while (true)
            {
                oldX = posX;
                oldY = posY;
                posX += newPosX.Next(-2, 3);
                posY += newPosY.Next(-2, 3);
                if (savannah.field[posX, posY] == null)
                {
                    savannah.addAnimal(posX, posY, this);
                    savannah.removeAnimal(posX, posY);
                    vicinity();
                }
                else
                {
                    posX = oldX;
                    posY = oldY;
                    move();
                }
                Thread.Sleep(3000);
            }
        }

        public void vicinity()
        {
            for (int i = -1; i < 2; i++)
            {
                for (int j = 1; j < 2; j++)
                {
                    if (posX + i != posX && posY + j != posY)
                    {
                        if (savannah.field[posX + i, posY + j].animal != null)
                        {
                            if (savannah.field[posX + i, posY + j].animal is Rabbit && gender == true &&
                                savannah.field[posX + i, posY + j].animal.gender == false)
                            {
                                mate();
                            }
                        }
                        else if (savannah.field[posX + i, posY + j].grass != null)
                        {
                            eat(posX + i, posY + j);
                        }
                    }
                }
            }
        }

        public void eat(int x, int y)
        {

            this.weight += savannah.field[x, y].grass.weight;
            savannah.removeGrass(x, y);
        }

        public void mate()
        {
            while (true)
            {
                int x = newPosX.Next(0, 20);
                int y = newPosY.Next((0, 20);
                if (savannah.field[x, y].animal == null)
                {
                    savannah.field[x, y].animal = new Rabbit(savannah);
                }
                else
                {
                    continue;
                }
                break;
            }
        }
    }
}
