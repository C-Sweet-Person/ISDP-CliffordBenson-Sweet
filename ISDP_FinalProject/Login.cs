using System.Data.SqlClient;

namespace ISDP_FinalProject
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection();
        }
    }
}