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
    public partial class AddLocation : Form
    {
        public AddLocation()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
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
            if (MessageBox.Show("Do you want to add a new employee?", "Notice", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (site.EditLocation(new site(23213432, name, province, address, address2, city, country, postalCode, phone, dayOfWeek, WHDistance, siteType, Notes, true)))
                {
                    MessageBox.Show(name + " has been edited.");
                    Close();
                };
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
