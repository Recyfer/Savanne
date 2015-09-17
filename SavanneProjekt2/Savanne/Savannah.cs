using System;
using System.Drawing;
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
        private PictureBox pictureBox1;

        public Savannah(Random random1, Random random2, PictureBox pictBox)
        {
            rand1 = random1;
            rand2 = random2;
            pictureBox1 = pictBox;

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    fields[i, j] = new Field();
                }
            }

            for (int i = 0; i < random1.Next(3, 6);)
            {
                posX = rand1.Next(0, 20);
                posY = rand2.Next(0, 20);
                if (fields[posX, posY].animal == null)
                {
                    createLion(posX, posY);
                    i++;
                }
            }

            for (int i = 0; i < random1.Next(5, 10);)
            {
                posX = rand1.Next(0, 20);
                posY = rand2.Next(0, 20);
                if (fields[posX, posY].animal == null)
                {
                    createRabbit(posX, posY);
                    i++;
                }
            }

            for (int i = 0; i < random1.Next(5, 10);)
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

        public void removeAnimal(int x, int y)
        {
            this.fields[x, y].animal = null;
        }

        public void removeGrass(int x, int y)
        {
            this.fields[x, y].grass = null;
        }

        public void addAnimal(int x, int y, Animal animal)
        {
            this.fields[x, y].animal = animal;
        }

        public void addGrass(int x, int y, Grass grass)
        {
            this.fields[x, y].grass = grass;
        }

        public void printAll()
        {
            foreach (var field1 in fields)
            {
                if (field1.animal != null)
                {
                    Console.WriteLine(field1.animal.GetType());
                    Console.WriteLine(field1.animal.weight);
                    Console.WriteLine("X er {0}, Y er {1}", field1.animal.posX, field1.animal.posY);
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
                getAvailableField().animal = new Lion(this, posX, posY);
            }
        }

        public void createLion(int x, int y)
        {
            if (fields[x, y].animal == null)
            {
                fields[x, y].animal = new Lion(this, x, y);
            }
        }

        public void createRabbit()
        {
            getAvailableField().animal = new Rabbit(this, posX, posY);
        }

        public void createRabbit(int x, int y)
        {
            if (fields[x, y].animal == null)
            {
                fields[x, y].animal = new Rabbit(this, x, y);
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
                    fields[posX, posY].grass = new Grass(this, posX, posY);
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
                fields[posX, posY].grass = new Grass(this, x, y);
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
            foreach (var field in fields)
            {
                if (field.animal != null)
                {
                    if (field.animal is Lion)
                    {
                        grp.DrawRectangle(penLion, (field.animal.posY*20 + 1 + 4), (field.animal.posX*20 + 1 + 4), 10, 10);
                    }

                    if (field.animal is Rabbit)
                    {
                        grp.DrawRectangle(penRabbit, (field.animal.posY*20 + 1 + 4), (field.animal.posX*20 + 1 + 4), 10, 10);
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
        }

        public void startAll()
        {
            for (int i = 0; i < 5; i++)
            {
                drawAll();
                Thread.Sleep(1000);
                foreach (var field in fields)
                {
                    if (field.animal != null)
                    {
                        field.animal.move();
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
