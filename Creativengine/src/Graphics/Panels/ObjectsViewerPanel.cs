using Creativengine.Framework;
using Creativengine.Framework.Components;
using MyGui;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Creativengine.Graphics
{
    public class ObjectViewerPanel
    {
        public MyGuiPanel myGuiPanel;

        public TreeView objectTreeView;
        public Button addObjectButton;

        public ObjectViewerPanel()
        {
            myGuiPanel = new MyGuiPanel("Object Viewer", new Size(200, 200), DockStyle.Left, Window.GetForm());
        }

        public void Show()
        {
            myGuiPanel.Init();

            addObjectButton = new Button()
            {
                Dock = DockStyle.Top,
                Text = "Create Object"
            };

            objectTreeView = new TreeView()
            {
                Dock = DockStyle.Fill,
                BackColor = Color.LightGray
            };

            objectTreeView.MouseClick += ObjectTreeView_MouseClick;
            addObjectButton.MouseClick += AddObjectButton_MouseClick;

            RefreshObjectViewer();

            myGuiPanel.addControl(objectTreeView);
            myGuiPanel.addControl(addObjectButton);
        }

        private void AddObjectButton_MouseClick(object sender, MouseEventArgs e)
        {
            GameObject gameObject = new GameObject() { name = "New Object " + Application.GetOpenedScene().objects.Count, components = new List<Component>() };

            gameObject.components.Add(new Transform(new Vector2(10, 10), new Vector2(10, 10)));

            Application.GetOpenedScene().objects.Add(gameObject);

            Console.WriteLine(Application.GetOpenedScene().objects.Count);

            Application.GlobalRefresh();
        }

        private void ObjectTreeView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var clickedNode = objectTreeView.GetNodeAt(e.X, e.Y);
                if (clickedNode != null)
                {
                    Application.SetSelectedObject(Application.GetOpenedScene().objects.FindIndex(obj => obj.name == clickedNode.Text));
                    Application.GlobalRefresh();
                }
            }
        }

        public void RefreshObjectViewer()
        {
            objectTreeView.Nodes.Clear();

            foreach (var item in Application.GetOpenedScene().objects)
            {
                objectTreeView.Nodes.Add(item.name);
            }
        }
    }
}
