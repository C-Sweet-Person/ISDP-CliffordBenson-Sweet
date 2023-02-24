using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            dataViewLocations.Columns.Add("country", "deliveryID");
            dataViewLocations.Columns.Add("employeeID", "employeeID");
            dataViewLocations.Columns.Add("notes", "notes");


            foreach (site site
                in sites)
            {

                dataViewLocations.Rows.Add(site.returnList());
            }
        }
    }
}
