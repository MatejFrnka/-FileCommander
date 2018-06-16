using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Total_Commander
{
    public class Keyboard
    {
        List<string> list = new List<string>();
        private bool end = false;
        private string originaltext;
        int topindex = 0;
        PopUp pop = new PopUp();
        Graphics g = new Graphics();
        public string type(string text)
        {
            if (text.Length != 0)
                text = text.Remove(text.Length - 1, 1);
            if (text.Length != 0)
                text = text.Remove(text.Length - 1, 1);
            end = false;
            g.txtrender();
            originaltext = text;
            testdraw(text);
            while (true)
            {
                Console.SetCursorPosition(Console.WindowWidth-4, Console.WindowHeight-4);
                ConsoleKeyInfo info = Console.ReadKey();
                if (info.Key == ConsoleKey.Escape)
                {
                    end = true;
                }
                else if (info.Key == ConsoleKey.Enter)
                {
                    text += "\n";
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (text.Length != 0)
                        text = text.Remove(text.Length - 1, 1);
                }
                else if (info.Key == ConsoleKey.Spacebar)
                {
                    text += " ";
                }
                else
                {
                    text += info.KeyChar;
                }
                if (end)
                {
                    if (pop.drawaskwindow("Chcete uložit?"))
                        return text;
                    else
                        return originaltext;
                }
                else
                    testdraw(text);
            }
        }
        public string typetxtbox(string text)
        {
            int len = text.Length + 20;
            pop.drawwindow(text.PadRight(text.Length+20), ConsoleColor.Black);
            text = "";
            while (true)
            {
                Console.SetCursorPosition(Console.WindowWidth - 4, Console.WindowHeight - 4);
                ConsoleKeyInfo info = Console.ReadKey();
                if (info.Key == ConsoleKey.Enter)
                {
                    return text;
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (text.Length == 0)
                    {

                    }
                    else
                        text = text.Remove(text.Length - 1, 1);
                }
                else if (info.Key == ConsoleKey.Spacebar)
                {
                    text += " ";
                }
                else
                {
                    if(text.Length<20)
                        text += info.KeyChar;
                }
                string maxtxt = text.PadRight(20);
                Console.SetCursorPosition(Console.WindowWidth / 2 +(len-20)/8, Console.WindowHeight / 2);
                Console.WriteLine(maxtxt);
            }
        }
        private void testdraw(string text)
        {
            list.Clear();
            int lenght = Console.WindowWidth - 5;
            for (int i = 0; i < text.Split('\n').Length; i++)
            {
                int o;
                for (o = 0; o < text.Split('\n')[i].Length - lenght; o += lenght)
                {
                    list.Add(text.Split('\n')[i].Substring(o, lenght));
                }
                list.Add(text.Split('\n')[i].Substring(o, text.Split('\n')[i].Length - o));
            }
            for (int i = 0; i < list.Count; i++)
            {
                Console.SetCursorPosition(2, i + 2 - topindex);
                if (i == list.Count-1)
                {
                    if (list[i].Length == lenght)
                    {
                        Console.WriteLine(list[i].PadRight(lenght - list[i].Length + 1));
                        Console.SetCursorPosition(2, i + 2 - topindex + 1);
                        Console.Write("_");
                    }
                    else
                    {
                        Console.WriteLine(list[i] + "_".PadRight(lenght - 1 - list[i].Length + 1));
                        Console.SetCursorPosition(2, i + 2 - topindex + 1);
                        Console.Write("".PadRight(lenght));
                    }
                }
                else
                {
                    Console.WriteLine(list[i].PadRight(lenght-list[i].Length));
                }
                    

                Console.SetCursorPosition(3, i + 2 - topindex+1);

            }

        }
        
    }
}
