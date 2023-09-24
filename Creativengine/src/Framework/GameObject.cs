using Creativengine.Framework.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Creativengine.Framework
{
    public class GameObject
    {
        public string name;

        public List<Component> components;
        
        public Panel Render()
        {
            foreach (var item in components)
            {
                if (item.GetType() == typeof(GraphicsRenderer))
                {
                    Transform transform = (Transform)components.Find(comp => comp is Transform);
                    GraphicsRenderer graphicsRenderer = (GraphicsRenderer)components.Find(comp => comp is GraphicsRenderer);

                    int roundedPosX = (int)Math.Round(transform.position.x);
                    int roundedPosY = (int)Math.Round(transform.position.y);
                    int roundedScaleX = (int)Math.Round(transform.scale.x);
                    int roundedScaleY = (int)Math.Round(transform.scale.y);

                    Panel panel = new Panel()
                    {
                        Location = new Point(roundedPosX, roundedPosY),
                        Size = new Size(roundedScaleX, roundedScaleY),

                        BackColor = graphicsRenderer.color,

                        Name = name
                    };

                    panel.MouseClick += Panel_MouseClick;

                    return panel;
                }
            }

            return null;
        }

        private void Panel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Application.SetSelectedObject(Application.GetOpenedScene().objects.FindIndex(obj => obj.name == name));

                Application.GlobalRefresh();
            }
        }
    }
}
