using System.Data.SqlClient;

namespace ISDP_FinalProject
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection();
        }
    }
}