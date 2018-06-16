using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Total_Commander
{
    public class RenDir
    {
        PopUp pop = new PopUp();
        Keyboard keyboard = new Keyboard();
        public void rename(string path, string orName)
        {
            string finName = keyboard.typetxtbox("Zadejte jméno nové složky:");
            try
            {
                Directory.Move(path + (path[path.Length - 1] == '\\' ? "" : "\\") + orName, path + (path[path.Length - 1] == '\\' ? "" : "\\") + finName);
            }
            catch (IOException)
            {
                
            }
        }
    }
}
