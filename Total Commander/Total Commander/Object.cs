using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Total_Commander
{
    public abstract class Object
    {
        public DirectoryInfo dir;
        protected int x;
        public int c;
        public bool _drivesactive;
        public virtual bool Active { get; set; }
        public abstract void current(ConsoleKeyInfo info);
        public abstract void render();

    }
}
