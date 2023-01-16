using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
namespace ISDP_FinalProject
{
    public partial class DashboardAdmin : Form
    {
        public DashboardAdmin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBConnector db = new DBConnector();
           List<string> list = db.GetResults();
            foreach (string s in list)
            {
                MessageBox.Show(s, "Notice");
            }
           
        }
    }
}
