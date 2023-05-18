using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Creativengine.Graphics
{
    public class Window
    {
        private int m_Width, m_Height;
        private string m_Title;

        private Form m_Form;

        public Window(int width, int height, string title)
        {
            m_Width = width;
            m_Height = height;
            m_Title = title;
        }

        public void CreateForm()
        {
            m_Form = new Form();

            m_Form.Width = m_Width;
            m_Form.Height = m_Height;
            m_Form.Text = m_Title;

            m_Form.StartPosition = FormStartPosition.CenterScreen;
        }

        public Form GetForm() { return m_Form; }
    }
}
