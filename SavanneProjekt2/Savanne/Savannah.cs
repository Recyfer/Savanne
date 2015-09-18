using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using SavanneProjekt2;

namespace SavanneProjekt2.Savanne
{
    class Savannah
    {
        public Random rand1;
        public Random rand2;
        private int posX;
        private int posY;
        public Field[,] fields = new Field[20, 20];
        public List<Animal> animalList = new List<Animal>();
        public List<Grass> grassList = new List<Grass>();
        private PictureBox pictureBox1;

        public Savannah(Random random1, Random random2, PictureBox pictBox)
        {
            pictureBox1 = pictBox;
            rand1 = random1;
            rand2 = random2;

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    fields[i, j] = new Field();
                }
            }

            for (int i = 0; i < random1.Next(4, 7); )
            {
                posX = rand1.Next(0, 20);
                posY = rand2.Next(0, 20);
                if (fields[posX, posY].animal == null)
                {
                    createLion(posX, posY);
                    i++;
                }
            }

            for (int i = 0; i < random1.Next(10, 16); )
            {
                posX = rand1.Next(0, 20);
                posY = rand2.Next(0, 20);
                if (fields[posX, posY].animal == null)
                {
                    createRabbit(posX, posY);
                    i++;
                }
            }

            for (int i = 0; i < random1.Next(10, 16); )
            {
                posX = rand1.Next(0, 20);
                posY = rand2.Next(0, 20);
                if (fields[posX, posY].grass == null)
                {
                    createGrass(posX, posY);
                    i++;
                }

            }


        }

        protected Field getAvailableField()
        {
            while (true)
            {
                posX = rand1.Next(0, 20);
                posY = rand2.Next(0, 20);
                if (fields[posX, posY].animal == null)
                {
                    return fields[posX, posY];
                }
            }
        }

        public bool getAvailableNearbyField(Animal animal)
        {
            for (int i = -animal.speed; i < animal.speed; i++)
            {
                for (int j = -animal.speed; j < animal.speed; j++)
                {
                    int x = animal.posX + i;
                    int y = animal.posY + j;
                    x = Math.Max(x, 0); // Nu går dyret aldrig udover venstre kant
                    x = Math.Min(x, 19); // Nu går dyret aldrig udover højre kant
                    y = Math.Max(y, 0); // Nu går dyret aldrig udover toppen
                    y = Math.Min(y, 19); // Nu går dyret aldrig udover bunden

                    if (this.fields[x, y].animal == null)
                    {
                        return true;
                    }
                }
            }
            return false;


        }

        public void removeAnimal(int x, int y)
        {
            animalList.Remove(this.fields[x, y].animal);
            this.fields[x, y].animal = null;
        }

        public void removeGrass(int x, int y)
        {
            grassList.Remove(this.fields[x, y].grass);
            this.fields[x, y].grass = null;
        }

        //public void addAnimal(int x, int y, Animal animal)
        //{
        //    this.fields[x, y].animal = animal;
        //}

        public void addGrass(int x, int y, Grass grass)
        {
            grassList.Add(grass);
            this.fields[x, y].grass = grass;
        }




        public void printAll()
        {
            Console.Clear();
            foreach (var field1 in fields)
            {
                if (field1.animal != null)
                {
                    Console.WriteLine(field1.animal.GetType());
                    Console.WriteLine(field1.animal.weight);
                    Console.WriteLine("X er {0}, Y er {1}", field1.animal.posX, field1.animal.posY);
                }
                //if (field1.grass != null)
                //{
                //    Console.WriteLine(field1.grass.GetType());
                //    Console.WriteLine(field1.grass.weight);
                //}
            }
        }

        public void createLion()
        {
            var field = getAvailableField();
            Lion tempLion = new Lion(this, posX, posY);
            field.animal = tempLion;
            animalList.Add(tempLion);
        }

        public void createLion(int x, int y)
        {

            if (fields[x, y].animal == null)
            {
                Lion tempLion = new Lion(this, x, y);
                animalList.Add(tempLion);
                fields[x, y].animal = tempLion;
            }
        }

        public void createRabbit()
        {
            var field = getAvailableField();
            Rabbit tempRabbit = new Rabbit(this, posX, posY);
            field.animal = tempRabbit;
            animalList.Add(tempRabbit);
        }

        public void createRabbit(int x, int y)
        {
            Rabbit tempRabbit = new Rabbit(this, x, y);
            if (fields[x, y].animal == null)
            {
                animalList.Add(tempRabbit);
                fields[x, y].animal = tempRabbit;
            }
        }

        public void createGrass()
        {
            while (true)
            {
                posX = rand1.Next(0, 20);
                posY = rand2.Next(0, 20);
                if (fields[posX, posY].grass == null)
                {
                    Grass tempGrass = new Grass(this, posX, posY);
                    grassList.Add(tempGrass);
                    fields[posX, posY].grass = tempGrass;
                }
                else if (fields[posX, posY].grass != null)
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
            if (fields[posX, posY].grass == null)
            {
                Grass tempGrass = new Grass(this, x, y);
                grassList.Add(tempGrass);
                fields[posX, posY].grass = tempGrass;
            }
        }
        Bitmap bmp;
        Graphics grp;

        public void drawGrid()
        {

            int x = 0;
            int y = 0;
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            grp.Clear(Color.White);
            Pen p = new Pen(Color.Black);
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    grp.DrawRectangle(p, x, y, 20, 20);
                    x += 20;
                }
                y += 20;
                x = 0;
            }
            grp.DrawRectangle(p, x, y, 20, 20);
            pictureBox1.Image = bmp;
        }

        public void drawAnimals()
        {
            Pen penLion = new Pen(Color.Red, 10);
            Pen penRabbit = new Pen(Color.Blue, 10);
            for(int i = 0; i < animalList.Count; i++)
            {
                if (animalList[i] != null)
                {
                    if (animalList[i] is Lion)
                    {
                        grp.DrawRectangle(penLion, (animalList[i].posY * 20 + 5), (animalList[i].posX * 20 + 5), 10, 10);
                    }

                    if (animalList[i] is Rabbit)
                    {
                        grp.DrawRectangle(penRabbit, (animalList[i].posY * 20 + 5), (animalList[i].posX * 20 + 5), 10, 10);
                    }
                }
            }
        }

        public void drawGrass()
        {
            Pen penGrass = new Pen(Color.Green, 10);
            foreach (var field in fields)
            {
                if (field.grass != null)
                {
                    grp.DrawRectangle(penGrass, (field.grass.posY * 20 + 1 + 4), (field.grass.posX * 20 + 1 + 4), 10, 10);
                }
            }
        }

        public void drawAll()
        {
            drawGrid();
            drawGrass();
            drawAnimals();
            Thread.Sleep(10);
        }

        public void startAll()
        {

            while (animalList.Any(x => x is Rabbit))
            {

                Thread.Sleep(100);
                for (int j = 0; j < animalList.Count; j++)
                {
                    animalList[j].vicinity();
                }
                for (int i = 0; i < animalList.Count; i++)
                {
                    if (animalList[i] != null)
                    {
                        int oldX = animalList[i].posX;
                        int oldY = animalList[i].posY;

                        animalList[i].move();

                        this.fields[oldX, oldY].animal = null;
                        this.fields[animalList[i].posX, animalList[i].posY].animal = animalList[i];
                    }
                }

            }

        }

    }
    class Field
    {
        public Animal animal;
        public Grass grass;
    }

}
