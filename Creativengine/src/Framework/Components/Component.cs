using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creativengine.Framework
{
    public abstract class Component
    {
        protected string m_ComponentName;

        protected Component(string componentName)
        {
            m_ComponentName = componentName;
        }

        public string GetComponentName()
        {
            return m_ComponentName;
        }
    }
}
