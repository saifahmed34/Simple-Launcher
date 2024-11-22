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

    public partial class AdminProfile : Form
    {
        bool mouseDown;
        AccountManger Data;
        AddingGame AddingGame = new AddingGame();
        public AdminProfile(ref AccountManger data)
        {
            Data = data;
            InitializeComponent();


            Account Acc = null;
            Data.GetAccountCurLogin(ref Acc);
          
        }

        private void label1_Click(object sender, EventArgs e)
        {
            AddingGame.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AddingGame.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
            }
            
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
                this.SetDesktopLocation(mousex, mousey);
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Store store = new Store(ref Data);
            store.ShowDialog();
        }
    }
}
