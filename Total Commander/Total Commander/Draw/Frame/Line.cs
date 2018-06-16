using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Total_Commander
{
    public class Line
    {
        public void DrawLine(bool top,bool middle)
        {
            for (int i = 0; i < Console.WindowWidth - 1; i++)
            {
                if (i == 0)
                {
                    Console.Write(top ? '╔' : '╚');
                }
                else if (i == Console.WindowWidth - 2)
                {
                    Console.Write(top ? '╗' : '╝');
                }
                else if (i == (Console.WindowWidth) / 2 - 1&&middle)
                {
                    Console.Write(top ? '╦' : '╩');
                }
                else
                    Console.Write('═');
            }
            Console.WriteLine();
        }
        public void DrawLine(bool top, bool middle,int width)
        {
            for (int i = 0; i < width; i++)
            {
                if (i == 0)
                {
                    Console.Write(top ? '╔' : '╚');
                }
                else if (i == width-1)
                {
                    Console.Write(top ? '╗' : '╝');
                }
                else if (i == width/2 && middle)
                {
                    Console.Write(top ? '╦' : '╩');
                }
                else
                    Console.Write('═');
            }
            Console.WriteLine();
        }
    }
}
