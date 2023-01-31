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
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            List<site> sites = site.GetSites();
            List<position> positions = position.GetPositions();
            foreach (position position in positions)
            {
                cbox_Position.Items.Add(position.getPermissionLevel());
            }
            foreach (site site in sites)
            {
                cbox_Site.Items.Add(site.getName());
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            List<position> positions = position.GetPositions();
            List<site> sites = site.GetSites();
            string password = txtPassword.Text;
            string firstName = txtFirstname.Text;
            string lastName = txtLastname.Text;
            bool active = check_Active.Checked;
            bool locked = check_Locked.Checked;
            int indexPos = cbox_Position.SelectedIndex;
            int indexSite = cbox_Site.SelectedIndex;
            int siteID = sites[indexSite].getID();
            int posID = positions[indexPos].getID();
            employee employee = new employee(999, "Dummy", password, firstName, lastName, "Dummy", active, locked, posID, siteID);
            if (employee.addEmployee(employee))
            {
                MessageBox.Show(firstName + " has been added.");
                DateTime datetimenow = DateTime.Now;
                string sqlDate = datetimenow.ToString("yyyy-MM-dd HH:mm:ss.fff");
                Transaction transaction = new Transaction(0, 0, "AddUser", "N/A", sqlDate, 1, 1, employee.GetEmployeeByUsername("admin").getID(), "Added user " + employee.getLastEmployee().getUsername());
                transaction.createTransaction();
                Close();
            }
            else
            {
                MessageBox.Show(firstName + " could not be added.");
               
            }



        }
    }
}
