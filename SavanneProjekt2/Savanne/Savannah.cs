using System;

namespace SavanneProjekt2.Savanne
{
    class Savannah
    {
        public Random rand1;
        public Random rand2;
        private int posX;
        private int posY;
        public Field[,] field = new Field[20, 20];

        public Savannah(Random random1, Random random2)
        {
            rand1 = random1;
            rand2 = random2;

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    field[i, j] = new Field();
                }
            }

            for (int i = 0; i < random1.Next(3, 6); i++)
            {
                posX = rand1.Next(0, 20);
                posY = rand2.Next(0, 20);
                if (field[posX, posY].animal == null)
                {
                    createLion(posX, posY);
                }
                else
                {
                    i--;
                }
            }

            for (int i = 0; i < random1.Next(5, 10); i++)
            {
                posX = rand1.Next(0, 20);
                posY = rand2.Next(0, 20);
                if (field[posX, posY].animal == null)
                {
                    createRabbit(posX, posY);
                }
                else
                {
                    i--;
                }
            }

            for (int i = 0; i < random1.Next(5, 10); i++)
            {
                posX = rand1.Next(0, 20);
                posY = rand2.Next(0, 20);
                if (field[posX, posY].grass == null)
                {
                    createGrass(posX, posY);
                }
                else
                {
                    i--;
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

        public void printAll()
        {
            foreach (var field1 in field)
            {
                if (field1.animal != null)
                {
                    Console.WriteLine(field1.animal.GetType());
                    Console.WriteLine(field1.animal.weight);
                }
                if (field1.grass != null)
                {
                    Console.WriteLine(field1.grass.GetType());
                    Console.WriteLine(field1.grass.weight);
                }
            }
        }

        public void createLion()
        {
            while (true)
            {
                posX = rand1.Next(0, 20);
                posY = rand2.Next(0, 20);
                if (field[posX, posY].animal == null)
                {
                    field[posX, posY].animal = new Lion(this);
                }
                else if (field[posX, posY].animal != null)
                {
                    continue;
                }
                break;
            }
        }

        public void createLion(int x, int y)
        {
            posX = x;
            posY = y;
            if (field[posX, posY].animal == null)
            {
                field[posX, posY].animal = new Lion(this);
            }
        }

        public void createRabbit()
        {
            while (true)
            {
                posX = rand1.Next(0, 20);
                posY = rand2.Next(0, 20);
                if (field[posX, posY].animal == null)
                {
                    field[posX, posY].animal = new Rabbit(this);
                }
                else if (field[posX, posY].animal != null)
                {
                    continue;
                }
                break;
            }
        }

        public void createRabbit(int x, int y)
        {

            posX = x;
            posY = y;
            if (field[posX, posY].animal == null)
            {
                field[posX, posY].animal = new Rabbit(this);
            }
        }

        public void createGrass()
        {
            while (true)
            {
                posX = rand1.Next(0, 20);
                posY = rand2.Next(0, 20);
                if (field[posX, posY].grass == null)
                {
                    field[posX, posY].grass = new Grass(this);
                }
                else if (field[posX, posY].grass != null)
                {
                    continue;
                }
                break;
            }
        }

        public void createGrass(int x, int y)
        {
            posX = x;
            posY = y;
            if (field[posX, posY].grass == null)
            {
                field[posX, posY].grass = new Grass(this);
            }
        }

    }
    class Field
    {
        public Animal animal;
        public Grass grass;
    }

}
