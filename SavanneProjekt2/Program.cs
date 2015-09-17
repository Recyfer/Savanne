using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SavanneProjekt2.Savanne;

namespace SavanneProjekt2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            var rand = new Random();
            var rand2 = new Random(DateTime.Now.Millisecond + 5);

            var savannah = new Savannah(rand, rand2);

            savannah.printAll();
            Console.WriteLine("----------------------------------------");
            for (int i = 0; i < 20; i++)
            {
                for (int ii = 0; ii < 20; ii++)
                {
                    if (savannah.field[i, ii].animal is Lion)
                    {
                        Console.Write("L ");
                    }
                    if (savannah.field[i, ii].animal is Rabbit)
                    {
                        Console.Write("R ");
                    }
                    if (savannah.field[i, ii].animal == null)
                    {
                        Console.Write("  ");
                    }
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("----------------------------------------");


            Console.Read();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

}
