using Creativengine.Framework.Components;
using MyGui;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Creativengine.Graphics
{
    public class ViewportPanel
    {
        public MyGuiPanel myGuiPanel;

        public Panel renderPanel;

        public ViewportPanel()
        {
            myGuiPanel = new MyGuiPanel("Viewport", new Size(100, 100), DockStyle.Fill, Window.GetForm());
        }

        public void Show()
        {
            myGuiPanel.Init();

            renderPanel = new Panel()
            {
                Dock = DockStyle.Fill,
            };

            RefreshRenderPanel();

            myGuiPanel.addControl(renderPanel);
        }

        public void RefreshRenderPanel()
        {
            renderPanel.BackColor = EntryPoint.GetOpenedScene().skyColor;

            foreach (var item in EntryPoint.GetOpenedScene().objects)
            {
                if (item.components.Exists(c => c is GraphicsRenderer))
                {
                    Transform transform = (Transform)item.components.Find(comp => comp is Transform);
                    GraphicsRenderer graphicsRenderer = (GraphicsRenderer)item.components.Find(comp => comp is GraphicsRenderer);

                    Panel panel = new Panel()
                    {
                        Location = new Point(transform.position.x, transform.position.y),
                        Size = new Size(transform.scale.x, transform.scale.y),

                        BackColor = graphicsRenderer.color
                    };

                    renderPanel.Controls.Add(panel);
                }
            }
        }
    }
}
