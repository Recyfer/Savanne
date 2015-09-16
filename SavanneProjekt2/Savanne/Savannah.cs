namespace SavanneProjekt2.Savanne
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

}
