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
    public partial class Login : Form
    {
        private static string userLogged;
        private static string permissionLvl;
        public Login()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            DBConnector db = new DBConnector();
            if (db.login(username, password))
            {
                MessageBox.Show("Welcome " + username);
                userLogged = username;
                permissionLvl = position.getPermissionLevelByID(employee.GetEmployeeByUsername(username).getPositionID());
                DashboardAdmin AdminDash = new DashboardAdmin();
                AdminDash.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid combination of username/password.");
            }
        }

        private void lblForget_Click(object sender, EventArgs e)
        {
            ForgetPassword forgetPassword = new ForgetPassword();
            forgetPassword.ShowDialog();
        }

        private void lblShow_Click(object sender, EventArgs e)
        {
            bool boolean = txtPassword.UseSystemPasswordChar == true ? false : true;
            txtPassword.UseSystemPasswordChar = boolean;
        }
        public static string getLoggedUser()
        {
            return userLogged;
        }
        /**
         * 
         */
        public static string getPermissionLevel()
        {
            return permissionLvl;
        }
    }
}
