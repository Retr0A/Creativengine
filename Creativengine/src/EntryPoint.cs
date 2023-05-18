using Creativengine.Framework;
using Creativengine.Framework.Components;
using Creativengine.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Creativengine
{
    public class EntryPoint
    {
        private static CreativeScene openedScene = new CreativeScene();

        public static void Main(string[] args)
        {
            // Temporary
            openedScene.skyColor = Color.White;
            openedScene.objects = new List<GameObject> {new GameObject() { name = "MyObject", components = new List<Component>() }};
            openedScene.objects[0].components.Add(new Transform(new Vector2(100, 100), new Vector2(100, 100)));
            openedScene.objects[0].components.Add(new GraphicsRenderer(Color.Green));
            //

            Window window = new Window(1080, 720, "Creativengine");

            window.CreateForm();

            ViewportPanel viewportPanel = new ViewportPanel();
            viewportPanel.Show();

            Application.Run(Window.GetForm());
        }

        public static CreativeScene GetOpenedScene()
        {
            return openedScene;
        }
    }
}
