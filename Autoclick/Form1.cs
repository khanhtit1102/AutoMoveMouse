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

namespace Autoclick
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string FirstPossion_X = Cursor.Position.X.ToString();
        private string FirstPossion_Y = Cursor.Position.Y.ToString();
        private string SecondPossion_X;
        private string SecondPossion_Y;

        private void button1_Click(object sender, EventArgs e)
        {
            lbStatus.Text = "RUNNING";
            lbStatus.ForeColor = Color.Blue;
            timer1.Start();
        }
        private int countTick = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            countTick++;
            Console.WriteLine(countTick);
            this.Cursor = new Cursor(Cursor.Current.Handle);
            if(countTick == 150)
            {
                SecondPossion_X = Cursor.Position.X.ToString();
                SecondPossion_Y = Cursor.Position.Y.ToString();
                if (FirstPossion_X == SecondPossion_X && FirstPossion_Y == SecondPossion_Y)
                {
                    Console.WriteLine("True");
                    Cursor.Position = new Point(Cursor.Position.X + 1, Cursor.Position.Y);
                    this.countTick = 0;
                }
            }
            else
            {
                FirstPossion_X = Cursor.Position.X.ToString();
                FirstPossion_Y = Cursor.Position.Y.ToString();
                Console.WriteLine(FirstPossion_X + ":" + FirstPossion_Y);
            }
            if (this.countTick == 170)
            {
                this.countTick = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lbStatus.Text = "STOPED";
            lbStatus.ForeColor = Color.Red;
            timer1.Stop();
        }
    }
}
