using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Total_Commander
{
    public class Body
    {
        public void DrawBody(bool middle)
        {
            for (int a = 0; a < Console.WindowHeight - 3; a++)
            {
                for (int i = 0; i < Console.WindowWidth - 1; i++)
                {
                    if (i == 0 || i == Console.WindowWidth - 2 || (i == Console.WindowWidth / 2 - 1&&middle))
                    {
                        Console.Write('║');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
