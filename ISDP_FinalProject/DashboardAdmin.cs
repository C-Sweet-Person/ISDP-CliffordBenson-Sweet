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
            refresh();
        }

        private void btn_editUser_Click(object sender, EventArgs e)
        {
            if (dataGridUsers.SelectedRows.Count == 1)
            {
                MessageBox.Show((string)dataGridUsers.SelectedCells[0].Value, "EmployeeID");
                string username = (string)dataGridUsers.SelectedCells[1].Value;
                employee selected = employee.GetEmployeeByUsername(username);
                EditUser editUser = new EditUser();
                editUser.ChangeText(selected);
                editUser.ShowDialog();
                refresh();
            }
            else if (dataGridUsers.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Please select a value.", "Error");

            }
            else
            {
                MessageBox.Show("Can only select one row at a time", "Error");
            }
        }
        private void refresh()
        {
            dataGridUsers.Rows.Clear();
            dataGridUsers.Columns.Clear();
            DBConnector db = new DBConnector();
            List<employee> employees = new List<employee>();
            List<string> list = employee.GetUsernamesNotActive();
            foreach (string s in list)
            {
                employees.Add(employee.GetEmployeeByUsername(s));
            }
            employee employee1 = employee.GetEmployeeByUsername("admin");
            dataGridUsers.Columns.Add("ID", "id");
            dataGridUsers.Columns.Add("Username", "username");
            dataGridUsers.Columns.Add("Password", "password");
            dataGridUsers.Columns.Add("FirstName", "firstName");
            dataGridUsers.Columns.Add("LastName", "lastName");
            dataGridUsers.Columns.Add("Email", "email");
            dataGridUsers.Columns.Add("active", "active");
            dataGridUsers.Columns.Add("locked", "locked");
            dataGridUsers.Columns.Add("siteID", "siteID");
            dataGridUsers.Columns.Add("positionID", "positionID");

            foreach (employee worker in employees)
            {

                dataGridUsers.Rows.Add(worker.returnList());
            }
        }

        private void btn_removeUser_Click(object sender, EventArgs e)
        {
            string username = (string)dataGridUsers.SelectedCells[1].Value;
            if (employee.deleteEmployee(username))
            {
                MessageBox.Show(username + " deleted sucessfully", "Notice");
                DateTime datetimenow = DateTime.Now;
                string sqlDate = datetimenow.ToString("yyyy-MM-dd HH:mm:ss.fff");
                Transaction transaction = new Transaction(0, 0, "DeleteUser", "N/A", sqlDate, 1, 1, employee.GetEmployeeByUsername("admin").getID(), "Deleted user " + username);
                transaction.createTransaction();
                refresh();
            }
            else
            {
                MessageBox.Show(username + " could not be deleted.", "Error");
            }
        }

        private void btn_newUser_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.ShowDialog();
            refresh();
        }

        private void btn_closeAdminDashboard_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            Hide();
        }
        private void lockFunctions()
        {
            btn_editUser.Enabled = false;
            btn_newUser.Enabled = false;
            btn_removeUser.Enabled = false;
        }

        private void btnViewTransactions_Click(object sender, EventArgs e)
        {
            ViewTransactions viewTransactions = new ViewTransactions();
            viewTransactions.ShowDialog();
        }
    }
}
