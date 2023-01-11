using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISDP_FinalProject
{
    public partial class ForgetPassword : Form
    {
        public ForgetPassword()
        {
            InitializeComponent();
        }

        private void picHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A password must be at least 8 characters long, start with a letter, contain at least one capital letter and one special character.");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            passwordCheck(txtPswrd.Text);
        }
        /*
         * Name: passwordCheck
         * Return: bool
         * Arguements: String
         * Description: Take a password, give it a number of tests,
         * depending if that password passes, returns true. Else, return false.
         */
        private bool passwordCheck(string Password)
        {
            bool result = true;
            
            return result;
        }
    }
}
