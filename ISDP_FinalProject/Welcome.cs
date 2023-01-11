using System.Data.SqlClient;

namespace ISDP_FinalProject
{
    public partial class FormWelcome : Form
    {
        public FormWelcome()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
        }
        private void BtnUserLogin_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("localhost:3000/login.php");
        }
    }
}