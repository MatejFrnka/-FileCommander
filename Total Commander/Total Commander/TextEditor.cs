using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Total_Commander
{
    public class TextEditor
    {
        
        Keyboard t = new Keyboard();
        private string Read(string loc)
        {
            string ctext;
            StreamReader sr = new StreamReader(loc);
            ctext = t.type(sr.ReadToEnd());
            sr.Close();
            return ctext;
        }
        private void Write(string inputtext,string loc)
        {
            StreamWriter sr = new StreamWriter(loc,false);
            sr.WriteLine(inputtext);
            sr.Close();
        }
        public void Edit(string loc)
        { 
            Write(Read(loc),loc);
        }
    }
}
