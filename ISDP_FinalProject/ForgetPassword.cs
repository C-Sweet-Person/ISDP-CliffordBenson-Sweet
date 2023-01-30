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
            if(!Validation.passwordCheck(txtPswrd.Text))
            {
                MessageBox.Show("Please enter a valid password matching the criteria.", "notice", MessageBoxButtons.OK);
            }
            else if (txtPswrd.Text != txtPasswordConfirm.Text)
            {
                MessageBox.Show("Both passwords do not match. Please enter the password again.", "notice", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Password is good", "notice", MessageBoxButtons.OK);
            }
        }


        private void lblShow_Click(object sender, EventArgs e)
        {
            bool boolean = txtPswrd.UseSystemPasswordChar == true ? false : true;
            txtPswrd.UseSystemPasswordChar = boolean;
        }
    }
}
