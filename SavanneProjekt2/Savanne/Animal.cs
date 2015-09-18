using System;
using System.Threading;

namespace SavanneProjekt2.Savanne
{

    abstract class Animal
    {
        public double weight;
        protected bool isAlive;
        public bool gender;
        public int posX;
        public int posY;
        public int speed;
        protected Random newPosX;
        protected Random newPosY;


        protected Savannah savannah;

        protected Animal(Savannah s, int x, int y)
        {
            savannah = s;
            newPosX = s.rand1;
            newPosY = s.rand2;
            posX = x;
            posY = y;
            gender = s.rand1.NextDouble() >= 0.5;
        }

        public void move()
        {
            //Console.WriteLine("{0} og {1}", posX, posY);
            //Console.WriteLine("Speed er {0}",speed);
            int x;
            int y;
            int i = 0;

            //if (savannah.getAvailableNearbyField(this) == true)
            //{
            do
            {
                x = this.posX;
                y = this.posY;
                x += newPosX.Next(-speed, speed + 1);
                y += newPosY.Next(-speed, speed + 1);

                x = Math.Max(x, 0); // Nu går dyret aldrig udover venstre kant
                x = Math.Min(x, 19); // Nu går dyret aldrig udover højre kant
                y = Math.Max(y, 0); // Nu går dyret aldrig udover toppen
                y = Math.Min(y, 19); // Nu går dyret aldrig udover bunden
                i++;

            } while (savannah.fields[x, y] == null && i < 5);
            this.posX = x;
            this.posY = y;
            //}





            //savannah.addAnimal(posX, posY, this);
            //savannah.removeAnimal(x, y);


            savannah.drawAll();
            //Console.WriteLine("{0} og {1}", posX, posY);
        }

        public abstract void vicinity();

        /*
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
        //*/

        /*
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

        //*/

        /*
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
         //*/




    }





}
