using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Total_Commander
{
    public class PopUp : Object
    {
        public int windowwidth = 40;
        public PopUp()
        {
            c = 0;
        }
        public ConsoleColor color = ConsoleColor.Black;
        Line line = new Line();
        int width = Console.WindowWidth;
        int height = Console.WindowHeight;
        private bool _stop = false;
        private bool _endit = false;
        public override void current(ConsoleKeyInfo info)
        {
            if (info.Key == ConsoleKey.LeftArrow)
            {
                if (c==1)
                {
                    c = 0;
                    drawbuttons();
                }
            }
            if (info.Key == ConsoleKey.RightArrow)
            {
                if (c==0)
                {
                    c = 1;
                    drawbuttons();
                }
            }
            if(info.Key == ConsoleKey.Enter)
            {
                _stop = true;
            }
            if (info.Key == ConsoleKey.Escape)
            {
                _endit = true;
            }
        }
        public void drawwindow(string text)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            windowwidth = text.Length + 4;
            Console.SetCursorPosition(width / 2 - windowwidth / 2, height / 2-1);
            line.DrawLine(true, false, windowwidth);
            Console.SetCursorPosition(width / 2 - windowwidth / 2, height / 2 + 1);
            line.DrawLine(false, false, windowwidth);
            Console.SetCursorPosition(width / 2 - windowwidth / 2, height / 2);
            Console.WriteLine("║ " + text + " ║");
                Console.ReadLine();
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public void drawwindow(string text,ConsoleColor color)
        {
            Console.BackgroundColor = color;
            windowwidth = text.Length + 4;
            Console.SetCursorPosition(width / 2 - windowwidth / 2, height / 2 - 1);
            line.DrawLine(true, false, windowwidth);
            Console.SetCursorPosition(width / 2 - windowwidth / 2, height / 2 + 1);
            line.DrawLine(false, false, windowwidth);
            Console.SetCursorPosition(width / 2 - windowwidth / 2, height / 2);
            Console.WriteLine("║ " + text + " ║");
            //Console.ReadLine();
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public bool drawaskwindow(string text)
        {
            Console.BackgroundColor = color;
            Console.SetCursorPosition(width / 2 - windowwidth / 2, height / 2 - 4);//line 1
            line.DrawLine(true, false, windowwidth);
            Console.SetCursorPosition(width / 2 - windowwidth / 2, height / 2 + 2);//line last
            line.DrawLine(false, false, windowwidth);
            Console.SetCursorPosition(width / 2 - windowwidth / 2, height / 2);
            for (int i = 0; i < 5; i++)
            {
                for (int o = 0; o < windowwidth; o++)
                {
                    if (o == 0)
                    {
                        Console.SetCursorPosition(width / 2 - windowwidth / 2, height / 2 - 3 + i);
                        Console.Write("║");
                    }
                    else if (o == windowwidth - 1)
                    {
                        Console.SetCursorPosition(width / 2 + windowwidth / 2 - 1, height / 2 - 3 + i);
                        Console.Write("║");
                    }
                    else
                        Console.Write(" ");
                }
            }

            Console.SetCursorPosition(width / 2 - text.Length / 2, height / 2-2);
            Console.Write(text);
            return drawbuttons();
            
        }
        private bool drawbuttons()
        {
            while (true)
            {

                
                if (c == 0)
                    Console.BackgroundColor = ConsoleColor.Blue;
                else
                    Console.BackgroundColor = color;
                Console.SetCursorPosition(width / 2 - windowwidth / 4 - 1, height / 2);
                Console.WriteLine("Ano");
                if (c == 1)
                    Console.BackgroundColor = ConsoleColor.Blue;
                else
                    Console.BackgroundColor = color;

                Console.SetCursorPosition(width / 2 + windowwidth / 4 - 1, height / 2);
                Console.WriteLine("Ne");

                Console.BackgroundColor = color;
                ConsoleKeyInfo info = Console.ReadKey();
                current(info);
                if (_stop)
                {
                    _stop = false;
                    if (c == 0)
                        return true;
                    else
                        return false;
                }
                if(_endit)
                {
                    return false;
                }
            }
        }
        public override void render()
        {
            throw new NotImplementedException();
        }
    }
}
