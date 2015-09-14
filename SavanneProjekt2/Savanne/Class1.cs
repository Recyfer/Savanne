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

        public void removeAnimal(int x, int y)
        {
            this.field[x, y].animal = null;
        }

        public void addAnimal(int x, int y, Animal animal)
        {
            this.field[x, y].animal = animal;
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
        private Random newPosX = new Random();
        private Random newPosY = new Random();
        private Savannah savannah;

        protected Animal(Savannah s)
        {
            savannah = s;
        }

        public void Move(Animal animal)
        {
            if (animal is Lion)
            {
                savannah.removeAnimal(posX, posY);
                posX += newPosX.Next(-1, 2);
                posY += newPosY.Next(-1, 2);
                savannah.addAnimal(posX,posY,this);
            }
        }

        public void Eat(double unitWeight)
        {
            weight += unitWeight * 200;
        }


    }

    class Lion : Animal
    {

    }

    class Rabbit : Animal
    {

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
