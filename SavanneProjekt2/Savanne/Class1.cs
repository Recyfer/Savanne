using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SavanneProjekt2
{
    class Savannah
    {
        public Field[,] field = new Field[20, 20];

        public Savannah()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    field[i, j] = new Field();
                }
            }
        }

        public void removeAnimal(int x, int y)
        {
            this.field[x, y].animal = null;
        }

        public void removeGrass(int x, int y)
        {
            this.field[x, y].grass = null;
        }

        public void addAnimal(int x, int y, Animal animal)
        {
            this.field[x, y].animal = animal;
        }

        public void addGrass(int x, int y, Grass grass)
        {
            this.field[x, y].grass = grass;
        }

    }
    class Field
    {
        public Animal animal;
        public Grass grass;
    }

    abstract class Animal
    {
        private double weight;
        private bool isAlive;
        private bool gender;
        private int oldX;
        private int oldY;
        private int posX;
        private int posY;
        private Random newPosX;
        private Random newPosY;

        private Savannah savannah;

        public Animal(Savannah s)
        {
            savannah = s;
            newPosX = new Random();
            newPosY = new Random();
        }

        public void move()
        {
            if (this is Lion)
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
                    move();
                }
            }
            else if (this is Rabbit)
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
                            if (this is Lion && savannah.field[posX + i, posY + j].animal is Rabbit)
                            {
                                eat(posX + i, posY + j);
                            }
                            else if (this is Lion && savannah.field[posX + i, posY + j].animal is Lion && this.gender == true && savannah.field[posX + i, posY + j].animal.gender == false)
                            {
                                mate();
                            }
                            else if (this is Rabbit && savannah.field[posX + i, posY + j].animal is Rabbit && this.gender == true && savannah.field[posX + i, posY + j].animal.gender == false)
                            {
                                mate();
                            }
                        }
                        else if (this is Rabbit && savannah.field[posX + i, posY + j].grass != null)
                        {
                            eat(posX + i, posY + j);
                        }
                    }
                }
            }
        }


        public void eat(int x, int y)
        {
            if (this is Lion)
            {
                this.weight += savannah.field[x, y].animal.weight;
                savannah.removeAnimal(x, y);
            }
            else if (this is Rabbit)
            {
                this.weight += savannah.field[x, y].grass.weight;
                savannah.removeGrass(x, y);
            }
        }

        public void mate()
        {
            int x = newPosX.Next(0, 20);
            int y = newPosY.Next((0, 20);
            if (savannah.field[x, y].animal == null && this is Lion)
            {
                savannah.field[x, y].animal = new Lion(savannah);
            }
            else if (savannah.field[x, y].animal == null && this is Rabbit)
            {
                savannah.field[x, y].animal = new Rabbit(savannah);
            }
            else
            {
                mate();
            }
        }




    }

    class Lion : Animal
    {
        public Lion(Savannah s)
            : base(s)
        {

        }
    }

    class Rabbit : Animal
    {
        public Rabbit(Savannah s)
            : base(s)
        {

        }
    }

    class Grass
    {
        public double weight;
        private bool isAlive;


        public void grow()
        {
            while (isAlive == true)
            {
                weight *= 1.1;
            }
        }
    }
}
