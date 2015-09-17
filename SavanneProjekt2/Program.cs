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
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            var rand = new Random();
            var rand2 = new Random(DateTime.Now.Millisecond + 5);

            var savannah = new Savannah(rand, rand2);
            
            savannah.printAll();

            Console.Read();
        }
    }

}
