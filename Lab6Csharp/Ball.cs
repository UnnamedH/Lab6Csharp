using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6Csharp
{
    class Ball
    {
        int x, y;
        private int currentX = 100, currentY = 100;
        private static object locker = new object();
        private Random random = new Random();

        public Ball()
        {
            x = random.Next(30, 150);
            y = random.Next(30, 150);
        }

        public int[] moveBall()
        {
            int maxX = 400, maxY = 400;
            currentX = x + currentX;
            currentY = y + currentY;
            int[] nums = { currentX, currentY };
            return nums;
        }

        public void drawCircle(Form menu, Graphics grap)
        {
            lock (locker)
            {
                int[] resCoordinates;
                do {
                    resCoordinates = moveBall();
                    Pen blackPen = new Pen(Color.Black, 3);
                    Pen whitePen = new Pen(menu.BackColor, 3);
                    SolidBrush blackBrush = new SolidBrush(Color.Black);
                    SolidBrush whiteBrush = new SolidBrush(menu.BackColor);
                    Rectangle rect = new Rectangle(resCoordinates[0], resCoordinates[1], 30, 30);
                    grap.DrawEllipse(blackPen, rect);
                    grap.FillEllipse(blackBrush, rect);
                    Thread.Sleep(300);
                    grap.DrawEllipse(whitePen, rect);
                    grap.FillEllipse(whiteBrush, rect);
                }
                while 
                (resCoordinates[0] < 500 && resCoordinates[0] > 0 && resCoordinates[0] < 500 && resCoordinates[0] > 0);
            }
        }

    }
}
