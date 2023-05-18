using Creativengine.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Creativengine
{
    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            Window window = new Window(1080, 720, "Creativengine");

            window.CreateForm();

            Application.Run(window.GetForm());
        }
    }
}
