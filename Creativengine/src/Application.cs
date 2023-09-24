using Creativengine.Framework;
using Creativengine.Framework.Components;
using Creativengine.Graphics;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Creativengine
{
    public class Application
    {
        private static CreativeScene openedScene = new CreativeScene();
        private static int selectedObject = -1;

        private static Timer timer = new Timer { Enabled = true };

        public static EventHandler tickHandler;

        static ViewportPanel viewportPanel;
        static ObjectViewerPanel objectsViewerPanel;
        static PropertiesPanel propertiesPanel;

        public static void RunEngineApplication(string[] args)
        {
            // Temporary
            openedScene.skyColor = Color.White;
            openedScene.objects = new List<GameObject> {new GameObject() { name = "MyObject", components = new List<Component>() }};
            openedScene.objects[0].components.Add(new GraphicsRenderer(Color.Green));
            openedScene.objects[0].components.Add(new Transform(new Vector2(100, 100), new Vector2(100, 100)));
            //

            System.Windows.Forms.Application.EnableVisualStyles();

            Window window = new Window(1080, 720, "Creativengine");

            window.CreateForm();

            timer.Tick += tickHandler;
            timer.Start();

            viewportPanel = new ViewportPanel();
            objectsViewerPanel = new ObjectViewerPanel();
            propertiesPanel = new PropertiesPanel();

            viewportPanel.Show();

            objectsViewerPanel.Show();

            propertiesPanel.Show();

            #region Toolbar
            ToolStrip toolStrip = new ToolStrip();
            ToolStripDropDown fileDropDown = new ToolStripDropDown();
            
            fileDropDown.Items.Add("");

            #endregion

            System.Windows.Forms.Application.Run(Window.GetForm());
        }

        public static CreativeScene GetOpenedScene() { return openedScene; }
        public static int GetSelectedObject() { return selectedObject; }

        public static void SetSelectedObject(int value) { selectedObject = value; }

        public static void GlobalRefresh()
        {
            viewportPanel.RefreshRenderPanel();
            objectsViewerPanel.RefreshObjectViewer();
            propertiesPanel.RefreshPropertiesPanel();
        }
    }
}
