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
        /*
         * Need to find out way to make datagrid info visible via DBConnector function (GetUsers) and (GetPermissions)
         * And of course move those functions into their own function.
         */
        private void btn_refreshInfo_Click(object sender, EventArgs e)
        {
           DBConnector db = new DBConnector();
           employee employee1 = employee.GetEmployeeByUsername("admin");
           MessageBox.Show(employee1.returnAll());
        }
    }
}
