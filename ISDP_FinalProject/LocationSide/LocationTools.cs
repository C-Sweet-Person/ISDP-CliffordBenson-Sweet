using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ISDP_FinalProject.LocationSide;

namespace ISDP_FinalProject.Admin_Functions
{
    public partial class LocationTools : Form
    {
        public LocationTools()
        {
            InitializeComponent();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }
        private void refresh()
        {
            dataViewLocations.Rows.Clear();
            dataViewLocations.Columns.Clear();
            DBConnector db = new DBConnector();
            List<site> sites = site.GetSites();


            dataViewLocations.Columns.Add("ID", "siteID");
            dataViewLocations.Columns.Add("siteName", "Name");
            dataViewLocations.Columns.Add("provinceID", "province");
            dataViewLocations.Columns.Add("address", "address");
            dataViewLocations.Columns.Add("address2", "address2");
            dataViewLocations.Columns.Add("city", "city");
            dataViewLocations.Columns.Add("country", "country");
            dataViewLocations.Columns.Add("postalCode", "postalCode");
            dataViewLocations.Columns.Add("phone", "phoneNumber");
            dataViewLocations.Columns.Add("dayOfWeek", "dayOfWeek");
            dataViewLocations.Columns.Add("distanceFromWH", "distanceFromWH");
            dataViewLocations.Columns.Add("siteType", "siteType");
            dataViewLocations.Columns.Add("notes", "Notes");
            dataViewLocations.Columns.Add("active", "active");


            foreach (site site
                in sites)
            {
                if (site.getActive())
                dataViewLocations.Rows.Add(site.returnList());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(dataViewLocations.SelectedCells[0].Value.ToString()); 
            string name = dataViewLocations.SelectedRows[0].Cells[1].Value.ToString();
            if (site.deleteLocation(ID))
            {
                MessageBox.Show(name + " Location deleted.");
            }
            else
            {
                MessageBox.Show("Location could not be deleted.");
            }
        }

        private void btnEditLocation_Click(object sender, EventArgs e)
        {
            EditLocation editLocation = new EditLocation();
            int ID = Convert.ToInt32(dataViewLocations.SelectedCells[0].Value.ToString());
            site currentSite = site.getSiteByID(ID);
            editLocation.ChangeText(currentSite);
            editLocation.ShowDialog();
        }

        private void btnAddLocation_Click(object sender, EventArgs e)
        {
            AddLocation addLocation = new AddLocation();
            addLocation.ShowDialog();
        }

        private void LocationTools_Load(object sender, EventArgs e)
        {
            if (Login.getPermissionLevel() != "Administrator")
            {
                lockout();
            }
        }
        private void lockout()
        {
            btnAddLocation.Enabled = false;
            btnDelete.Enabled = false;
            btnEditLocation.Enabled = false;
        }
    }
}
