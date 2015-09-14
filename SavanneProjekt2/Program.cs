using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            var rand = new Random();
            int test;
            int inc = 0;
            var savannah = new Savannah();
            for (int i = 0; i < 901; i++)
            {
                test = rand.Next(-1, 2);
                if (test == 0 || test == 2)
                {
                    inc++;
                    Console.WriteLine("{0} har været der {1} gange.",test,inc);
                }
            }
            
            Console.Read();
        }
    }

}
