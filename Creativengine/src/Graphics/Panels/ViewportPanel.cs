using Creativengine.Framework;
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

            renderPanel.MouseClick += RenderPanel_MouseClick;

            RefreshRenderPanel();

            myGuiPanel.addControl(renderPanel);
        }

        private void RenderPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Application.SetSelectedObject(-1);
                Application.GlobalRefresh();
            }
        }

        public void RefreshRenderPanel()
        {
            renderPanel.BackColor = Application.GetOpenedScene().skyColor;

            renderPanel.Controls.Clear();

            foreach (GameObject item in Application.GetOpenedScene().objects)
            {
                var panel = item.Render();

                if (panel != null) renderPanel.Controls.Add(panel);
            }
        }
    }
}
