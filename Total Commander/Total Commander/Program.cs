using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Total_Commander
{
    class Program
    {
        static void Main(string[] args)
        {

            PopUp pop = new PopUp();
            /*try
            {*/
                Console.CursorVisible = false;
                Main main = new Main();
                Graphics g = new Graphics();
                Console.BackgroundColor = ConsoleColor.Black;
                g.render();
                while (true)
                {
                    main.render();
                    ConsoleKeyInfo info = Console.ReadKey();
                    if (info.Key == ConsoleKey.F10)
                        break;
                    main.pressedkey(info);
                }
                /*
            }
            catch
            {
                pop.drawwindow("Unknown error");
            }*/
        }
    }
}
