using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6Csharp
{
    public partial class Form1 : Form
    {
        static object locker = new object();
        public Form1()
        {
            InitializeComponent();
        }

        public void prior(Thread obj, string status)
        {
            switch (status)
            {
                //Lowest, BelowNormal, Normal, AboveNormal, Highest
                case "Lowest":
                    obj.Priority = ThreadPriority.Lowest;
                    break;
                case "BelowNormal":
                    obj.Priority = ThreadPriority.BelowNormal;
                    break;
                case "Normal":
                    obj.Priority = ThreadPriority.Normal;
                    break;
                case "AboveNormal":
                    obj.Priority = ThreadPriority.AboveNormal;
                    break;
                case "Highest":
                    obj.Priority = ThreadPriority.Highest;
                    break;
                default:
                    obj.Priority = ThreadPriority.Normal;
                    break;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics grap = CreateGraphics();
            List<Ball> listBalls = new List<Ball>() { };
            List<Thread> threads = new List<Thread>() { };
            int numberBalls = 2;
            for (int i = 0; i < numberBalls; i++)
            {
                listBalls.Add(new Ball());
                threads.Add(new Thread(delegate ()
                {
                        listBalls[i-1].drawCircle(this, grap);
                }));
                threads[i].Start();
            }

                prior(threads[0], "Lowest");

            }
    }
}
