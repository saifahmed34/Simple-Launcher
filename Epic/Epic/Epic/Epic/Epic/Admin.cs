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
    public partial class Admin : Form
    {
        private bool isEmailValid = true;
        private bool isPasswordValid = false;
        public bool mouseDown;
       
        AccountManger Data;
        public Admin(ref AccountManger data)
        {
            Data = data;
            InitializeComponent();
        }
        private void Admin_Load(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            isPasswordValid = textBox2.Text.Length > 0;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (isEmailValid && isPasswordValid)
            {
                try
                {
                    if (Data.LoginEmail(textBox1.Text, textBox2.Text))
                    {
                        Account account = null;
                        Data.GetAccountCurLogin(ref account);
                        if(account is Developer) {
                            MessageBox.Show("Dev");

                        }else if (account is User) {
                            MessageBox.Show("User");
                        }
                        else
                        {
                            throw new Exception("undefined");
                        }
                        
                        AdminProfile profile = new AdminProfile(ref Data);
                        profile.Show();
                    }
                    else
                    {
                        MessageBox.Show("Wrong Password and Email");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid email and password");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            label2_Click(sender, e);
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void button4_Click(object sender, EventArgs e)
        {
            WindowState |= FormWindowState.Minimized;
        }
    }
}
