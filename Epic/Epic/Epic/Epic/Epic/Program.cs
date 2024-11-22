using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccountMan;
namespace Epic
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AccountManger accountManger = new AccountManger();
           // accountManger.AddAccount(new User("mostafa", "mostafa", "sadfadf", "sadfadf", 150));
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(ref accountManger));
        }
    }
}
