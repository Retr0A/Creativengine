using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creativengine.Framework.Components
{
    public class Transform : Component
    {
        public Vector2 position;
        public Vector2 scale;

        public Transform(Vector2 position, Vector2 scale) : base("Transform")
        {
            this.position = position;
            this.scale = scale;
        }
    }
}
