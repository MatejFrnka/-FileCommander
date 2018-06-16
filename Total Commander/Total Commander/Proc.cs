using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Total_Commander
{
    public class Proc
    {
        TextEditor t = new TextEditor();
        Graphics graphics = new Graphics();
        public void start(string path)
        {
            try
            {
                if (path.Remove(0, path.Length - 4) == ".txt")
                {
                    Console.Clear();
                    t.Edit(path);
                }
                else
                    Process.Start(path);
            }
            catch
            { }
        }
        public void edit(string path)
        {
            Console.Clear();
                t.Edit(path);
        }
    }
}
