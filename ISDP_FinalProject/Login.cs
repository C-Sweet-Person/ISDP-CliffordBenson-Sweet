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
        string userLogged;
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
                DashboardAdmin AdminDash = new DashboardAdmin();
                AdminDash.Show();
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
    }
}
