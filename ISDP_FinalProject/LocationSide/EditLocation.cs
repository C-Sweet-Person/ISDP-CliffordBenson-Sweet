﻿using System;
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

        }
        public void ChangeText(site site)
        {
        txtName.Text = site.getName();
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