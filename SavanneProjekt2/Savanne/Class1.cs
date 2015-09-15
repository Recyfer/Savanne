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
                    field[i,j] = new Field();
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
        private int posX;
        private int posY;
        private Random newPosX;
        private Random newPosY;

        private Savannah savannah;

        protected Animal(Savannah s)
        {
            savannah = s;
            newPosX = new Random();
            newPosY = new Random();
        }

        public void Move(Animal animal)
        {
            if (animal is Lion)
            {
                savannah.removeAnimal(posX, posY);
                posX += newPosX.Next(-1, 2);
                posY += newPosY.Next(-1, 2);
                savannah.addAnimal(posX, posY, this);
            }
        }

        public void Eat()
        {
            for (int i = -1; i < 2; i++)
            {
                for (int j = 1; j < 2; j++)
                {
                    if (savannah.field[posX + i, posY + j].animal != null)
                    {
                        if (this is Lion && savannah.field[posX + i, posY + j].animal is Rabbit)
                        {
                            this.weight += savannah.field[posX + i, posY + j].animal.weight;
                            savannah.removeAnimal(posX + i, posY + j);
                        }

                    }
                    else if (this is Rabbit && savannah.field[posX + i, posY + j].grass != null)
                    {
                        this.weight += savannah.field[posX + i, posY + j].animal.weight;
                        savannah.removeGrass(posX + i, posY + j);
                    }
                }
            }
        }

        public void Mate()
        {
            for (int i = -1; i < 2; i++)
            {
                for (int j = 1; j < 2; j++)
                {
                    if (savannah.field[posX + i, posY + j].animal != null)
                    {
                        if (this is Lion && savannah.field[posX + i, posY + j].animal is Lion)
                        {
                            savannah.removeAnimal(posX + i, posY + j);
                            // finish mating method
                        }
                        if (this is Rabbit && savannah.field[posX + i, posY + j].animal is Rabbit)
                        {
                            savannah.removeAnimal(posX + i, posY + j);
                            // finish mating method
                        }
                    }
                }
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
        private double weight;
        private bool isAlive;

        public double Eat()
        {
            return weight;
        }

        //private void remove()
        //{
        //    this = null;
        //}

        public void grow()
        {
            while (isAlive == true)
            {
                weight *= 1.1;
            }


        }
    }
}
