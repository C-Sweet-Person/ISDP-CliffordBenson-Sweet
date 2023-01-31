using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ISDP_FinalProject.employee;

namespace ISDP_FinalProject
{
    public partial class EditUser : Form
    {
        public EditUser()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            List<position> positions = position.GetPositions();
            List<site> sites = site.GetSites();
            int id = Convert.ToInt32(txtID.Text);
            string password = txtPassword.Text;
            string firstName = txtFirstname.Text;
            string lastName = txtLastname.Text;
            bool active = check_Active.Checked;
            bool locked = check_Locked.Checked;
            int indexPos = cbox_Position.FindString(cbox_Position.Text);
            int indexSite = cbox_Site.FindString(cbox_Site.Text);
            MessageBox.Show(indexSite.ToString());
            int siteID = sites[indexSite].getID();
            int posID = positions[indexPos].getID();
            employee employee = new employee(id, "Dummy", password, firstName, lastName, "dummy", active, locked, posID, siteID);
            if (BoxChecker())
            {
                if (employee.EditEmployee(employee))
                {
                    MessageBox.Show(employee.getFirstName() + " has been edited.");
                    DateTime datetimenow = DateTime.Now;
                    string sqlDate = datetimenow.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    Transaction transaction = new Transaction(0, 0, "EditUser", "N/A", sqlDate, 1, 1, employee.GetEmployeeByUsername("admin").getID(), "Edited user " + id);
                    transaction.createTransaction();
                    Close();
                }
            }
            else
            {
                MessageBox.Show("User could not be edited.", "Error");

            }
        }
        /// <summary>
        /// Checks to see which fields are empty/validation testing.
        /// </summary>
        /// <returns></returns>
        private bool BoxChecker()
        {
            string error = "";
            bool check = true;
            if (txtPassword.Text == "")
            {
                error += "Please enter a password\n";
                txtPassword.Focus();
                check = false;
            }
            if (Validation.passwordCheck(txtPassword.Text) && String.IsNullOrWhiteSpace(txtPassword.Text) == false)
            {
                error += "Password not in the correct criteria.\n";
                txtPassword.Focus();
                check = false;
            }
            if (txtFirstname.Text == "")
            {
                error += "Please enter a first name\n";
                txtFirstname.Focus();
                check = false;
            }
            if (txtLastname.Text == "")
            {
                error += "Please enter a last name";
                txtFirstname.Focus();
                check = false;

            }
            if (error != "")
            {
                MessageBox.Show(error, "Error");
            }
            return check;
     
        }
        private void EditUser_Load(object sender, EventArgs e)
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
        public void ChangeText(employee worker)
        {
            txtID.Text = Convert.ToString(worker.getID());
            txtPassword.Text = worker.getPassword();
            txtFirstname.Text = worker.getFirstName();
            txtLastname.Text = worker.getLastName();
            cbox_Position.Text = position.getPermissionLevelByID(worker.getPositionID());
            cbox_Site.Text = site.getSiteNameByID(worker.getSiteID());
            check_Active.Checked = worker.getActive();
            check_Locked.Checked = worker.getLocked();


        }
    }
}
