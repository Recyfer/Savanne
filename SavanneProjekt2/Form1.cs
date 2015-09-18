using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SavanneProjekt2.Savanne;

namespace SavanneProjekt2
{
    public partial class Form1 : Form
    {
        private Random rand;
        private Random rand2;
        private Savannah savannah;
        public Form1()
        {
            InitializeComponent();
            rand = new Random();
            rand2 = new Random(DateTime.Now.Millisecond + 5);

            savannah = new Savannah(rand, rand2, pictureBox1);
            /*
            savannah.printAll();
            Console.WriteLine("----------------------------------------");
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (savannah.fields[i, j].animal is Lion)
                    {
                        Console.Write("L ");
                    }
                    if (savannah.fields[i, j].animal is Rabbit)
                    {
                        Console.Write("R ");
                    }
                    if (savannah.fields[i, j].animal == null)
                    {
                        Console.Write("  ");
                    }
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("----------------------------------------");
             //*/
            this.Closing += Form1_Closing;
        }

        void Form1_Closing(object sender, EventArgs e)
        {
            if (thread.IsAlive)
            {
                thread.Abort();
            }
        }

        private Thread thread;
        private void startButton_Click(object sender, EventArgs e)
        {
            thread = new Thread(new ThreadStart(savannah.startAll));
            savannah.drawAll();
            thread.Start();
                //savannah.startAll();
            

            //savannah.printAll();
        }
    }
}
