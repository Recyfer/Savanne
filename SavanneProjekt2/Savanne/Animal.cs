﻿using System;
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
        protected int speed;
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
            gender = new Random().NextDouble() >= 0.5;
        }

        public void move()
        {
            int x;
            int y;
            do
            {
                x = this.posX;
                y = this.posY;
                posX += newPosX.Next(-speed, speed + 1);
                posY += newPosY.Next(-speed, speed + 1);

                posX = Math.Max(posX, 0); // Nu går dyret aldrig udover venstre kant
                posX = Math.Min(posX, 19); // Nu går dyret aldrig udover højre kant
                posY = Math.Max(posY, 0); // Nu går dyret aldrig udover toppen
                posY = Math.Min(posY, 19); // Nu går dyret aldrig udover bunden

            } while (savannah.fields[x, y] != null);

            this.posX = x;
            this.posY = y;

            savannah.addAnimal(posX, posY, this);
            savannah.removeAnimal(posX, posY);
        }

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
