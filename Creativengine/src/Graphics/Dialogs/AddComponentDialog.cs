using Creativengine.Framework;
using Creativengine.Framework.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Creativengine.Dialogs
{
    public class AddComponentDialog
    {
        public Component Component { get; private set; }

        public DialogResult ShowDialog()
        {
            Form prompt = new Form();
            prompt.Width = 500;
            prompt.Height = 400;
            prompt.Text = "Add Component";
            Label textLabel = new Label() { Left = 50, Top = 20, Text = "Select Component" };
            
            ListView listView = new ListView() { Dock = DockStyle.Fill, Top = 100, Left = 100, View = View.List };
            listView.Items.Add("Graphics Renderer");

            listView.SelectedIndexChanged += ListView_SelectedIndexChanged;

            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70 };
            confirmation.Click += (sender, e) => { prompt.Close(); };

            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(listView);
            
            DialogResult result = prompt.ShowDialog();

            return result;
        }

        private void ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ListView)sender).SelectedIndices.Count > 0)
            {
                switch (((ListView)sender).SelectedIndices[0])
                {
                    case 0:
                        Component = new GraphicsRenderer(Color.White);

                        break;
                    default:
                        Component = null;

                        break;
                }
            }
        }
    }
}
