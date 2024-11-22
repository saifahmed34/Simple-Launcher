using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

using System.IO;
using AccountMan;
namespace Epic
{
    public partial class Store : Form
    {
        bool MouseDown;
        public Store()
        {
            InitializeComponent();
            List<Game> games;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDown = true;
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {

        }
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseDown)
            {
                int mousex = MousePosition.X - 400;
                int mousey = MousePosition.Y - 20;
                this.SetDesktopLocation(mousex, mousey);
            }
        }
        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            MouseDown=false;
        }
  

    }
}
