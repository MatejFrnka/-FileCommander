using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Total_Commander
{
    public class Create
    {
        Keyboard keyboard = new Keyboard();
        PopUp pop = new PopUp();
        private string directory;
        private string msg;

        public void dir(DirectoryInfo dir)
        {
            try
            {
                string txt = keyboard.typetxtbox("Zadejte jméno složky:");
                directory = dir.FullName + (dir.FullName.Length == 3 ? "" : @"\") + txt;

                DirectoryInfo cdir = new DirectoryInfo(directory);
                if (cdir.Exists)
                {
                    pop.drawwindow("Tato složka již existuje");
                }
                else
                {
                    cdir.Create();
                }
            }
            catch (UnauthorizedAccessException)
            {
                pop.drawwindow("Přístup odepřen");
            }
            catch (System.ArgumentException)
            {
                pop.drawwindow("Použity neplatné znaky");
            }

        }
        
        public void file(DirectoryInfo dir)
        {
            msg = "Zadejte jméno souboru:";
            pop.drawwindow(msg, ConsoleColor.Black);
            Console.SetCursorPosition(Console.WindowWidth / 2 + msg.Length / 2 + 1, Console.WindowHeight / 2);
            directory = dir.FullName + (dir.FullName.Length == 3 ? "" : @"\") + keyboard.typetxtbox("Zadejte jméno souboru:");
            if (File.Exists(directory))
                pop.drawwindow("Tento soubor již existuje");
            else
            {
                try
                {
                    using (FileStream fs = File.Create(directory)) { };
                }
                catch (UnauthorizedAccessException)
                {
                    pop.drawwindow("Přístup odepřen");
                }
                catch (System.ArgumentException)
                {
                    pop.drawwindow("Použity neplatné znaky");
                }
            }
        }
    }
}
