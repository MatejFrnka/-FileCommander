using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Total_Commander
{
    public class Main
    {
        public List<Object> list = new List<Object>();

        PopUp p = new PopUp();
        public Main()
        {
            list.Add(new Panel(2, true,this,1));
            list.Add(new Panel((Console.WindowWidth / 2) + 1, false,this,0));
        }
        public void pressedkey(ConsoleKeyInfo info)
        {
            foreach (Object item in list)
            {
                item.current(info);
            }
        }
        public void render()
        {
            foreach (Object item in list)
            {
                item.render();
            }
        }
    }
}
