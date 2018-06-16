using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Total_Commander
{
    public class Controls
    {
        List<string> menu = new List<string>();
        List<string> txt = new List<string>();
        public Controls()
        {
            menu.Add("");
            menu.Add("");
            menu.Add("Copy");
            menu.Add("Edit");
            menu.Add("Move");
            menu.Add("RenMov");
            menu.Add("Mkdir");
            menu.Add("Delete");
            menu.Add("Mkfile");
            menu.Add("Quit");
            txt.Add("Quit");

        }
        public void DrawControls()
        {
            for (int i = 0; i < menu.Count; i++)
            {
                if (menu[i] != "")
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(i == 0 ? "F" : " F" + (i + 1) + (i == menu.Count - 1 ? "" : " "));
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write(menu[i].PadRight(i == menu.Count-1?4:6));
                }
            }
        }
        public void DrawtxtControls()
        {
            for (int i = 0; i < txt.Count; i++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("Esc ");
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write(txt[i].PadRight(6));
            }
        }
    }
}
