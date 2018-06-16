using System;
using System.IO;
using System.Collections.Generic;


namespace Total_Commander
{
    public class Panel : Object
    {
        Graphics g = new Graphics();
        CopyDir copyDir = new CopyDir();
        PopUp p = new PopUp();
        Proc proces = new Proc();
        RenDir renDir;
        public RenderDirectories dirrender;
        RenderDrives drirender;
        Create create;
        public Main main;
        private int _lift = 3;
        private int topIndex = -1;
        public int index;

        public Panel(int X, bool a, Main m,int i)
        {
            _drivesactive = false;
            index = i;
            renDir = new RenDir();
            dir = new DirectoryInfo(@"C:\");
            main = m;
            dirrender = new RenderDirectories(this);
            drirender = new RenderDrives(this);
            create = new Create();
            this.Active = a;
            x = X;
            c = 0;
        }
        
        public override void current(ConsoleKeyInfo info)
        {
            if (this.Active)
            {
                
                    if (info.Key == ConsoleKey.UpArrow)
                    {
                        if (c > -1 && _drivesactive == false)
                        {
                            c--;
                            if (c < this.topIndex)
                            {
                                this.topIndex--;
                            }
                        }
                        else if (c > 0 && _drivesactive == true)
                            c--;
                    }
                    if (info.Key == ConsoleKey.DownArrow)
                    {
                        if ((c < dirrender.list.Count-1) && (_drivesactive == false))
                        {
                            c++;
                            if (c > Console.WindowHeight - 8 + this.topIndex - 1)
                            {
                                this.topIndex++;
                            }
                        }
                        else if (_drivesactive == true && c < DriveInfo.GetDrives().Length - 1)
                            c++;
                    }
                    if (info.Key == ConsoleKey.Enter)
                    {
                        cls();
                    topIndex = -1;
                        if (c < 0)
                        {
                            if (dir.Parent != null)
                            {
                                dir = dir.Parent;
                                c = -1;
                            }
                            else
                            {
                                _drivesactive = true;
                                c = 0;
                            }
                        }
                        else
                        {
                            try
                            {
                                if (_drivesactive == false)
                                {
                                    dir = dir.GetDirectories()[c];
                                }
                                else
                                {
                                    dir = DriveInfo.GetDrives()[c].RootDirectory;
                                    _drivesactive = false;
                                }

                                c = -1;
                            }
                            catch
                            {
                                proces.start(dir.FullName + "\\" + dirrender.list[c]);
                                fullclear();
                            }
                        }

                    }
                if (!this._drivesactive)
                {
                    if (!main.list[index]._drivesactive)
                    {
                        if (info.Key == ConsoleKey.F3)
                        {
                            copyDir.Copy(dir.FullName, main.list[index].dir.FullName, genlist()[c]);
                            fullclear();
                        }
                        if (info.Key == ConsoleKey.F5)
                        {

                            copyDir.Move(dir.FullName, main.list[index].dir.FullName, genlist()[c], dir.Parent == null ? true: false);
                            cls();
                            fullclear();
                        }
                    }
                    if (info.Key == ConsoleKey.F4)
                    {
                        if (dirrender.list[c].Substring(dirrender.list[c].Length-4,4)== ".txt")
                        {
                            proces.edit(dir.FullName + "\\" + dirrender.list[c]);
                            fullclear();
                        }
                    }
                    if (info.Key == ConsoleKey.F6)
                    {
                        renDir.rename(dir.FullName, dirrender.list[c]);
                        fullclear();
                    }
                    if (info.Key == ConsoleKey.F7)
                    {
                        create.dir(this.dir);
                        fullclear();
                    }
                    if (info.Key == ConsoleKey.F8)
                    {
                        try
                        {
                            if (c >= 0 || !_drivesactive)
                            {
                                if (c < dir.GetDirectories().Length)
                                {
                                    if (p.drawaskwindow("Opravdu chcete smazat tuto slozku"))
                                    {
                                        dir.GetDirectories()[c].Delete(true);
                                    }
                                }
                                else if (c < dir.GetDirectories().Length + dir.GetFiles().Length)
                                {
                                    if (p.drawaskwindow("Opravdu chcete smazat tento soubor"))
                                    {
                                        dir.GetFiles()[c - dir.GetDirectories().Length].Delete();
                                    }
                                }
                                fullclear();
                            }
                        }
                        catch (UnauthorizedAccessException)
                        {
                            p.drawwindow("Přístup byl odepřen");
                        }
                    }
                    if (info.Key == ConsoleKey.F9)
                    {
                        create.file(this.dir);
                        fullclear();
                    }
                }
                //--------------------------------------------------------
            }
            if (info.Key == ConsoleKey.Tab)
            {
                this.Active = !this.Active;
            }
        }
        public override void render()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(x, 1);
            Console.WriteLine(_drivesactive ? "---" : dir.FullName.ToString());
            if (_drivesactive)
                drirender.render(c, Active, x, _lift);
            else
                dirrender.render(c, topIndex, Active, x, _lift);
        }
        private void fullclear()
        {
            Console.Clear();
            g.render();
            render();
        }
        private void cls()
        {
            for (int i = 1; i < Console.WindowHeight - 2; i++)
            {
                Console.SetCursorPosition(x, i);
                Console.WriteLine("".PadRight(Console.WindowWidth / 2 - 3));
            }
        }
        private List<string> genlist()
        {
            List<string> tmp = new List<string>();
            tmp.Clear();
            for (int i = 0; i < dir.GetDirectories().Length; i++)
            {
                tmp.Add(dir.GetDirectories()[i].ToString());
            }
            for (int i = 0; i < dir.GetFiles().Length; i++)
            {
                tmp.Add(dir.GetFiles()[i].ToString());
            }
            return tmp;
        }
    }
}
