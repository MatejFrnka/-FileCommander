using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Total_Commander
{
    public class RenderDrives
    {
        Panel k;
        public RenderDrives(Panel panel)
        {
            k = panel;
        }
        public void render(int c, bool Active, int x, int _lift)
        {
            for (int i = 0; i < DriveInfo.GetDrives().Length; i++)
            {
                if (i == c && Active)
                    Console.BackgroundColor = ConsoleColor.Blue;
                else
                    Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(x, i + _lift);
                Console.WriteLine(DriveInfo.GetDrives()[i]);
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
        }
    }
}
