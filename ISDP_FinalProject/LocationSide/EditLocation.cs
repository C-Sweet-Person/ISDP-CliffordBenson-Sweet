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
            string siteType = txtSiteType.Text;
            string Notes = txtNotes.Text;
            site.EditLocation(new site(33333, name, province, address, address2, city, country, postalCode, phone, dayOfWeek, WHDistance, siteType, Notes, true));
        }
        public void ChangeText(site site)
        {
        txtName.Text = site.getName();
        txtAddress = site.getAddress();
        txtAddress2 = site.getAddress2();
        txtProvince.Text = site.getProvince();
        txtCity.Text = site.getCity();
        txtCountry.Text = site.getCountry();
        txtPostalCode.Text = site.getPostalCode();
        txtWHDistance.Text = site.getDistanceFromWH().ToString();
        txtSiteType.Text = site.getSiteType();
        txtNotes.Text = site.getNotes();

        }
    }
}
