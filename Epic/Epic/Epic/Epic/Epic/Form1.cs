using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccountMan;
namespace Epic
{
    public partial class Form1 : Form
    {
        bool mouseDown;
        public static AccountManger Data;
      
        public Form1(ref AccountManger data)
        {
            Data = data;
            InitializeComponent();
        }
        private void label2_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin(ref Data);
            admin.Show();
         
            
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin(ref Data);

            admin.Show();
            
            
            
        }

    





        private void button4_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Normal) {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
           mouseDown = true;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if(mouseDown)
            {
                int mousex = MousePosition.X-400;
                int mousey = MousePosition.Y - 20;
                SetDesktopLocation(mousex, mousey);
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown= false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
            Register register = new Register(ref Data);
            register.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            pictureBox2_Click(sender, e);
        }
    }
}
