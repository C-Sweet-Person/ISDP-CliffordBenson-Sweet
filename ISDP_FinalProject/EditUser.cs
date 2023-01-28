﻿using System;
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
            if (employee.EditEmployee(employee))
            {
                MessageBox.Show(employee.getFirstName() + " has been edited.");
                Close();
            }
            else
            {
                MessageBox.Show(employee.getFirstName() + " could not be edited.");

            }
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
            txtEmail.Text = worker.getEmail();
            cbox_Position.Text = position.getPermissionLevelByID(worker.getPositionID());
            cbox_Site.Text = site.getSiteNameByID(worker.getSiteID());
            check_Active.Checked = worker.getActive();
            check_Locked.Checked = worker.getLocked();


        }
    }
}
