using System;
using System.Threading;

namespace SavanneProjekt2.Savanne
{
    internal class Lion : Animal
    {
        protected Lion(Savannah s)
            : base(s)
        {
            weight = 49 + new Random().NextDouble();
        }

        public void move()
        {
            while (true)
            {
                while (true)
                {
                    oldX = posX;
                    oldY = posY;
                    posX += newPosX.Next(-1, 2);
                    posY += newPosY.Next(-1, 2);
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
                        continue;
                    }
                    break;
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
                            if (savannah.field[posX + i, posY + j].animal is Rabbit)
                            {
                                eat(posX + i, posY + j);
                            }
                            else if (savannah.field[posX + i, posY + j].animal is Lion && gender == true &&
                                     savannah.field[posX + i, posY + j].animal.gender == false)
                            {
                                mate();
                            }
                        }
                    }
                }
            }
        }

        public void eat(int x, int y)
        {

            this.weight += savannah.field[x, y].animal.weight;
            savannah.removeAnimal(x, y);
        }

        public void mate()
        {
            while (true)
            {
                int x = newPosX.Next(0, 20);
                int y = newPosY.Next((0, 20);
                if (savannah.field[x, y].animal == null)
                {
                    savannah.field[x, y].animal = new Lion(savannah);
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
