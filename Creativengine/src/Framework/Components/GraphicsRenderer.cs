using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creativengine.Framework.Components
{
    public class GraphicsRenderer : Component
    {
        public Color color;

        public GraphicsRenderer(Color color) : base("Graphics Renderer")
        {
            this.color = color;
        }
    }
}
