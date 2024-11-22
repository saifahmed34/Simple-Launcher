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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace Epic
{
    public partial class Register : Form
    {
        bool mouseDown;
        AccountManger account;
       
    
        public Register(ref AccountManger accounts)
        {
            account = accounts;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void button4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
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
            if (mouseDown)
            {
                int mousex = MousePosition.X - 400;
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
        
            if (textBox3.PasswordChar == '*')
            {
                textBox3.PasswordChar = '\0';
            }
            else
            {
                textBox3.PasswordChar = '*';
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox4.PasswordChar == '*')
            {
                textBox4.PasswordChar = '\0';
            }
            else
            {
                textBox4.PasswordChar = '*';
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void label5_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string userName = textBox2.Text;
            string email = textBox3.Text;
            string password = textBox4.Text;
            double balance = 0.0;
            if (radioButton1.Checked)
            {
                User newUser = new User(name, userName, email, password, balance);
                account.AddAccount(newUser);
                Store store = new Store();
                store.Show();
            }
            else if (radioButton2.Checked)
            {
                Developer newDev = new Developer(name, userName, email, password, balance);
                account.AddAccount(newDev);
                AdminProfile admin = new AdminProfile(ref account);
                admin.Show();
            }
      
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            label5_Click(sender, e);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
