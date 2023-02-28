using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISDP_FinalProject.LocationSide
{
    public partial class EditLocation : Form
    {
        public EditLocation()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);
            string name = txtName.Text;
            string address = txtAddress.Text;
            string address2 = txtAddress2.Text;
            string province = txtProvince.Text;
            string city = txtCity.Text;
            string country = txtCountry.Text;
            string postalCode = txtPostalCode.Text;
            int WHDistance = Convert.ToInt32(txtWHDistance.Text);
            string phone = txtPhone.Text;
            string dayOfWeek = cboxWeekDay.SelectedItem.ToString();
            string siteType = cboxSiteType.SelectedItem.ToString();
            string Notes = txtNotes.Text;
            if(MessageBox.Show("Do you want to edit this?", "Notice", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (site.EditLocation(new site(id, name, province, address, address2, city, country, postalCode, phone, dayOfWeek, WHDistance, siteType, Notes, true)))
                {
                    MessageBox.Show(id + " has been edited.");
                    Close();
                };
            }

           
        }
        public void ChangeText(site site)
        {
        txtID.Text = site.getID().ToString();
        txtName.Text = site.getName();
        txtAddress.Text = site.getAddress();
        txtAddress2.Text = site.getAddress2();
        txtProvince.Text = site.getProvince();
        txtCity.Text = site.getCity();
        txtCountry.Text = site.getCountry();
        txtPostalCode.Text = site.getPostalCode();
        txtWHDistance.Text = site.getDistanceFromWH().ToString();
        txtPhone.Text = site.getPhone();
        cboxWeekDay.Text = site.getDayOfWeek();
        addSiteTypes();
        txtNotes.Text = site.getNotes();
        
        }
        private void addSiteTypes()
        {
            List<string> siteTypes = site.getSiteTypes();
            foreach (string site in siteTypes)
            {
                MessageBox.Show(site);
                cboxSiteType.Items.Add(site);
            }
        }
    }
}
