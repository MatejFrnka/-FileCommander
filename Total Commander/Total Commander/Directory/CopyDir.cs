using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Total_Commander
{
    public class CopyDir
    {
        PopUp pop = new PopUp();
        public void Copy(string Source, string Dest, string folder)
        {
            DirectoryInfo S = new DirectoryInfo(Path.Combine(Source,folder));
            DirectoryInfo T = new DirectoryInfo(Path.Combine(Dest,folder));
            FileInfo f = new FileInfo(Path.Combine(Source, folder));
            if (S != T)
            {
                try
                {
                    f.CopyTo(Path.Combine(Dest, folder));
                }
                catch
                {
                    if (S.GetDirectories().Length != 0)
                    {
                        CopyFilesRecursively(S, T);
                    }
                    else
                    {
                        T.Create();
                        foreach (FileInfo item in S.GetFiles())
                        {
                            item.CopyTo(Path.Combine(T.FullName, item.Name));
                        }
                    }
                }
            }
            else
                pop.drawwindow("Nelze kopírovat do stejné složky");
        
        }
        public void Move(string Source, string Dest, string folder,bool n)
        {
            DirectoryInfo S = new DirectoryInfo(Path.Combine(Source, folder));
            DirectoryInfo T = new DirectoryInfo(Path.Combine(Dest, folder));
            FileInfo f = new FileInfo(Path.Combine(Source, folder));
            if (S != T)
            {
                try
                {
                    f.MoveTo(Path.Combine(Dest, folder));
                }
                catch
                {
                    if (S.GetDirectories().Length != 0)
                    {
                        CopyFilesRecursively(S, T);
                        S.Delete();
                    }
                    else
                    {
                        T.Create();
                        foreach (FileInfo item in S.GetFiles())
                        {
                            item.MoveTo(Path.Combine(T.FullName, item.Name));
                        }
                    }
                }
            }
            else
                pop.drawwindow("Nelze přesunot do stejné složky");


        }
        public static void CopyFilesRecursively(DirectoryInfo source, DirectoryInfo target)
        {
            foreach (DirectoryInfo dir in source.GetDirectories())
                CopyFilesRecursively(dir, target.CreateSubdirectory(dir.Name));
            foreach (FileInfo file in source.GetFiles())
            {
                try
                {
                    file.CopyTo(Path.Combine(target.FullName, file.Name));
                }
                catch (IOException)
                {
                    try
                    {
                        FileInfo tmp = new FileInfo(Path.Combine(target.FullName, file.Name));
                        tmp.Delete();
                        file.CopyTo(Path.Combine(target.FullName, file.Name));
                    }
                    catch
                    {
                        PopUp p = new PopUp();
                        p.drawwindow("Přístup odepřen");
                    }
                }
            }
        }
    }
}
