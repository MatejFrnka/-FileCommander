using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Total_Commander
{
    public class Graphics
    {
        Line line = new Line();
        Body body = new Body();
        Controls controls = new Controls();

        public void render()
        {
            line.DrawLine(true, true);
            body.DrawBody(true);
            line.DrawLine(false, true);
            controls.DrawControls();
        }
        public void txtrender()
        {
            line.DrawLine(true, false);
            body.DrawBody(false);
            line.DrawLine(false, false);
            controls.DrawtxtControls();
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
