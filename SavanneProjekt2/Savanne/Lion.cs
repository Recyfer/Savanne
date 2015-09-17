using System;
using System.Threading;

namespace SavanneProjekt2.Savanne
{
    internal class Lion : Animal
    {
        public Lion(Savannah s, int x, int y)
            : base(s,x,y)
        {
            weight = 49 + s.rand1.NextDouble();
            //move();
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
                    if (posX >= 0 && posX <= 19 && posY >= 0 && posY <= 19)
                    {
                        if (savannah.fields[posX, posY] == null)
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
                    else
                    {
                        posX = oldX;
                        posY = oldY;
                    }
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
            while (true)
            {
                for (int i = 0; i < 2; i++)
                {
                    savannah.createLion();
                }
            }
        }
    }
}
