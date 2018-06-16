using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Total_Commander
{
    public class RenderDirectories
    {

        public List<string> list = new List<string>();
        public List<DateTime> fsize = new List<DateTime>();
        public List<string> tsize = new List<string>();
        Graphics g = new Graphics();
        PopUp p = new PopUp();
        Panel k;
        public RenderDirectories(Panel panel)
        {
            k = panel;
        }
        public string size(int s)
        {
            return s.ToString() ;
        }
        public void render(int c, int topIndex, bool Active, int x,int _lift)
        {
            try
            {
                list.Clear();
                for (int i = 0; i < k.dir.GetDirectories().Length; i++)
                {
                    list.Add("/" + k.dir.GetDirectories()[i].ToString());
                    fsize.Add(k.dir.GetDirectories()[i].CreationTime);
                    tsize.Add("");
                }
                for (int i = 0; i < k.dir.GetFiles().Length; i++)
                {
                    list.Add(k.dir.GetFiles()[i].ToString());
                    fsize.Add(k.dir.GetFiles()[i].CreationTime);
                }
                //-------
                int max = list.Count > (Console.WindowHeight - 8) ? Console.WindowHeight - 8 + topIndex : list.Count;

                for (int i = topIndex; i < max; i++)
                {
                    if (c == i && Active)
                        Console.BackgroundColor = ConsoleColor.Blue;
                    else
                        Console.BackgroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(x, i - topIndex + 1 + _lift);
                    if (i == -1)
                        Console.WriteLine(@"/..".PadRight(Console.WindowWidth / 2 - 5));
                    else
                    {
                        if (list[i].Length < ((Console.WindowWidth) / 2) - 17)
                        {
                            Console.Write(list[i].PadRight(Console.WindowWidth / 2 - 17));
                            Console.WriteLine(fsize[i].ToShortDateString());
                        }
                        else
                        {
                            Console.Write(list[i].Substring(0, (Console.WindowWidth / 2) - 20));
                            Console.Write("...");
                            Console.WriteLine(fsize[i].ToShortDateString());
                        }
                    }
                }
            }
            catch
            {
                p.drawwindow("Přístup je odepřen");
                k.dir = k.dir.Parent;
                Console.Clear();
                g.render();
                k.render();
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
        }
    }
}