using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SavanneProjekt2
{
    public partial class Form1 : Form
    {
        private Bitmap bmp;
        private Graphics grp;
        private int x = 0;
        private int y = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width,pictureBox1.Height);
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
            grp.DrawRectangle(p,x,y,20,20);
            pictureBox1.Image = bmp;
        }
    }
}
