using Creativengine.Framework.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            Creativengine.Application.tickHandler += TestTick;

            Creativengine.Application.RunEngineApplication(args);
        }

        private static void TestTick(object sender, EventArgs e)
        {
            //((Transform)Creativengine.Application.GetOpenedScene().objects.Find(obj => obj.name == "MyObject").components.
                //Find(component => component is Transform)).position += new Creativengine.Framework.Vector2(2.5f, 0f);

            //Creativengine.Application.GlobalRefresh();
        }
    }
}
