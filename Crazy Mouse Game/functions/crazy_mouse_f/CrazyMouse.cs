using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Crazy_Mouse_Game.functions.crazy_mouse_f
{
    class CrazyMouse
    {
        //public static int userScore;
        public static Random _random = new Random();
        public static void CrazyFunctionCall()
        {
            Thread crazyMouseThread = new Thread(new ThreadStart(CrazyMouseThread));
            crazyMouseThread.Start();
            
        }
        static void CrazyMouseThread()
        {
            int moveX = 0;
            int moveY = 0;

            while (globals.values.stop == false)
            {
                moveX = _random.Next(globals.values.xMouseLocation) - (globals.values.xMouseLocation / 2);
                moveY = _random.Next(globals.values.yMouseLocation) - (globals.values.yMouseLocation / 2);


                System.Windows.Forms.Cursor.Position = new System.Drawing.Point(System.Windows.Forms.Cursor.Position.X + moveX, System.Windows.Forms.Cursor.Position.Y + moveY);
                Thread.Sleep(50);
            }
        }
    }
}
