using Creativengine.Dialogs;
using Creativengine.Framework;
using Creativengine.Framework.Components;
using MyGui;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Creativengine.Graphics
{
    public class PropertiesPanel
    {
        public MyGuiPanel myGuiPanel;

        public TextBox nameTextBox;

        public GroupBox componentsGroupBox;

        public Button addComponentButton;

        public PropertiesPanel()
        {
            myGuiPanel = new MyGuiPanel("Properties Panel", new Size(200, 200), DockStyle.Right, Window.GetForm());
        }

        public void Show()
        {
            myGuiPanel.Init();

            nameTextBox = new TextBox()
            {
                Dock = DockStyle.Top
            };
            componentsGroupBox = new GroupBox()
            {
                Dock = DockStyle.Top,
                Size = new Size(200, 400)
            };
            addComponentButton = new Button()
            {
                Dock = DockStyle.Top,

                Text = "Add Component"
            };

            addComponentButton.MouseClick += AddComponentButton_MouseClick;

            RefreshPropertiesPanel();

            myGuiPanel.addControl(componentsGroupBox);
            myGuiPanel.addControl(addComponentButton);
            myGuiPanel.addControl(nameTextBox);
        }

        private void AddComponentButton_MouseClick(object sender, MouseEventArgs e)
        {
            AddComponentDialog acd = new AddComponentDialog();
            
            if (acd.ShowDialog() != DialogResult.OK)
            {
                Application.GetOpenedScene().objects[Application.GetSelectedObject()].components =
                    Application.GetOpenedScene().objects[Application.GetSelectedObject()].components.Prepend(acd.Component).ToList();
            }

            Application.GlobalRefresh();
        }

        public void RefreshPropertiesPanel()
        {
            if (Application.GetSelectedObject() != -1)
            {
                nameTextBox.Text = Application.GetOpenedScene().objects[Application.GetSelectedObject()].name;
                
                nameTextBox.Enabled = true;
                addComponentButton.Enabled = true;
            }
            else
            {
                nameTextBox.Text = "";

                nameTextBox.Enabled = false;
                addComponentButton.Enabled = false;
            }

            componentsGroupBox.Controls.Clear();

            CreativeScene scn = Application.GetOpenedScene();
            int selectedObject = Application.GetSelectedObject();

            if (selectedObject != -1)
            {
                foreach (Component item in scn.objects[Application.GetSelectedObject()].components)
                {
                    Type type = item.GetType();

                    if (type == typeof(Transform))
                    {
                        GroupBox groupBox = new GroupBox()
                        {
                            Dock = DockStyle.Top,
                            Size = new Size(200, 100),

                            Text = item.GetComponentName(),
                        };

                        GroupBox positionGB = new GroupBox()
                        {
                            Dock = DockStyle.Top,
                            Size = new Size(200, 40),

                            Text = "Position"
                        };

                        NumericUpDown posXNumericUpDown = new NumericUpDown() { Dock = DockStyle.Left, Size = new Size(80, 100), Name = "px" };
                        posXNumericUpDown.Maximum = int.MaxValue;
                        posXNumericUpDown.Minimum = int.MinValue;
                        posXNumericUpDown.DecimalPlaces = 4;

                        posXNumericUpDown.Value = new decimal(((Transform)item).position.x);

                        posXNumericUpDown.ValueChanged += TransformValuesChanged;

                        positionGB.Controls.Add(posXNumericUpDown);

                        NumericUpDown posYNumericUpDown = new NumericUpDown() { Dock = DockStyle.Right, Size = new Size(80, 100), Name = "py" };
                        posYNumericUpDown.Maximum = int.MaxValue;
                        posYNumericUpDown.Minimum = int.MinValue;
                        posYNumericUpDown.DecimalPlaces = 4;

                        posYNumericUpDown.Value = new decimal(((Transform)item).position.y);

                        posYNumericUpDown.ValueChanged += TransformValuesChanged;

                        positionGB.Controls.Add(posYNumericUpDown);


                        GroupBox scaleGB = new GroupBox()
                        {
                            Dock = DockStyle.Top,
                            Size = new Size(200, 40),

                            Text = "Scale"
                        };

                        NumericUpDown scaleXNumericUpDown = new NumericUpDown() { Dock = DockStyle.Left, Size = new Size(80, 100), Name = "sx" };
                        scaleXNumericUpDown.Maximum = int.MaxValue;
                        scaleXNumericUpDown.Minimum = int.MinValue;
                        scaleXNumericUpDown.DecimalPlaces = 4;

                        scaleXNumericUpDown.Value = new decimal(((Transform)item).scale.x);

                        scaleXNumericUpDown.ValueChanged += TransformValuesChanged;

                        scaleGB.Controls.Add(scaleXNumericUpDown);

                        NumericUpDown scaleYNumericUpDown = new NumericUpDown() { Dock = DockStyle.Right, Size = new Size(80, 100), Name = "sy" };
                        scaleYNumericUpDown.Maximum = int.MaxValue;
                        scaleYNumericUpDown.Minimum = int.MinValue;
                        scaleYNumericUpDown.DecimalPlaces = 4;

                        scaleYNumericUpDown.Value = new decimal(((Transform)item).scale.y);

                        scaleYNumericUpDown.ValueChanged += TransformValuesChanged;

                        scaleGB.Controls.Add(scaleYNumericUpDown);

                        groupBox.Controls.Add(scaleGB);
                        groupBox.Controls.Add(positionGB);

                        componentsGroupBox.Controls.Add(groupBox);
                    }
                    if (type == typeof(GraphicsRenderer))
                    {
                        GroupBox groupBox = new GroupBox()
                        {
                            Dock = DockStyle.Top,
                            Size = new Size(200, 60),

                            Text = item.GetComponentName()
                        };

                        Panel topPanel = new Panel()
                        {
                            Dock = DockStyle.Top,
                            Size = new Size(20, 20)
                        };
                        Button deleteComponentButton = new Button()
                        {
                            Dock = DockStyle.Right,
                            Size = new Size(20, 20),

                            Text = "X"
                        };

                        PictureBox colorPreviewImage = new PictureBox()
                        {
                            Dock = DockStyle.Left,
                            Size = new Size(40, 20),

                            BackColor = ((GraphicsRenderer)item).color
                        };

                        deleteComponentButton.MouseClick += (sender, args) =>
                        {
                            Application.GetOpenedScene().objects[Application.GetSelectedObject()].components.Remove(item);

                            Application.GlobalRefresh();
                        };

                        colorPreviewImage.MouseClick += ColorPreviewImage_MouseClick;

                        topPanel.Controls.Add(deleteComponentButton);

                        groupBox.Controls.Add(colorPreviewImage);
                        groupBox.Controls.Add(topPanel);

                        componentsGroupBox.Controls.Add(groupBox);
                    }
                }
            }
        }

        private void ColorPreviewImage_MouseClick(object sender, MouseEventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                ((GraphicsRenderer)Application.GetOpenedScene().objects[Application.GetSelectedObject()].components.Find(comp => comp is GraphicsRenderer)).color =
                    colorDialog.Color;

                Application.GlobalRefresh();
            }
        }

        private void TransformValuesChanged(object sender, EventArgs e)
        {
            if (((Control)sender).Name == "px")
            {
                // Position X
                ((Transform)Application.GetOpenedScene().objects[Application.GetSelectedObject()].components.Find(comp => comp is Transform)).position.x =
                    (float)((NumericUpDown)sender).Value;
            }
            if (((Control)sender).Name == "py")
            {
                // Position Y
                ((Transform)Application.GetOpenedScene().objects[Application.GetSelectedObject()].components.Find(comp => comp is Transform)).position.y =
                    (float)((NumericUpDown)sender).Value;
            }
            
            if (((Control)sender).Name == "sx")
            {
                // Scale X
                ((Transform)Application.GetOpenedScene().objects[Application.GetSelectedObject()].components.Find(comp => comp is Transform)).scale.x =
                    (float)((NumericUpDown)sender).Value;
            }
            if (((Control)sender).Name == "sy")
            {
                // Scale Y
                ((Transform)Application.GetOpenedScene().objects[Application.GetSelectedObject()].components.Find(comp => comp is Transform)).scale.y =
                    (float)((NumericUpDown)sender).Value;
            }

            Application.GlobalRefresh();
        }
    }
}
