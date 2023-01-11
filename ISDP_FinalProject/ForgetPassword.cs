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
            if(!passwordCheck(txtPswrd.Text))
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
        /*
         * Name: passwordCheck
         * Return: bool
         * Arguements: String
         * Description: Take a password, give it a number of tests,
         * depending if that password passes, returns true. Else, return false.
         */
        private bool passwordCheck(string Password)
        {
            string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
            int capitalLength = 0;
            int specialLength = 0;
            int testInt;
            bool result = false;
            //Is there at least one capital letter?
            foreach (char c in Password)
            {
                if (Char.IsUpper(c) == true)
                {
                    capitalLength++;
                }
            }
            //Is at least one character a special character
            foreach (char c in Password)
            {
                if (specialChar.Contains(c) == true)
                {
                    specialLength++;
                }
            }
            //Does it have 8 characters?
            if (Password.Length < 8)
            {
                result = false;
            }
            //Does the password start with a letter?
            else if (int.TryParse(Password[0].ToString(), out testInt))
                {
                result = false;
                }
           
            //Did those two foreach pass?
            else if (capitalLength > 0 && specialLength > 0)
            {
                result = true;
            }
            
            System.Diagnostics.Debug.WriteLine(specialLength + "" + capitalLength + " Test");
            return result;
        }

        private void lblShow_Click(object sender, EventArgs e)
        {
            bool boolean = txtPswrd.UseSystemPasswordChar == true ? false : true;
            txtPswrd.UseSystemPasswordChar = boolean;
        }
    }
}
