using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISDP_FinalProject
{
    internal class site
    {
        private int siteID;
        private string siteName;
        private string provinceID;
        private string address;
        private string address2;
        private string city;
        private string country;
        private string postalCode;
        private string phone;
        private string dayOfWeek;
        private int distanceFromWH;
        private string siteType;
        private string notes;
        private bool active;

        public site(int siteID, string siteName, string provinceID,string address, string address2,string city,string country,string postalCode,string phone,string dayOfWeek,int distanceFromWH,string siteType,string notes, bool active)
        {
            this.siteID = siteID;
            this.siteName = siteName;
            this.provinceID = provinceID;
            this.address = address;
            this.address2 = address2;
            this.city = city;
            this.country = country;
            this.postalCode = postalCode;
            this.phone = phone;
            this.dayOfWeek = dayOfWeek;
            this.distanceFromWH = distanceFromWH;
            this.siteType = siteType;
            this.notes = notes;
            this.active = active;
        }
        public int getID()
        {
            return siteID;
        }
        public string getName()
        {
            return siteName;
        }
        public static string getSiteNameByID(int id)
        {
            string name = null;
            DBConnector connector = new DBConnector();
            connector.cnn.Open();
            MySqlCommand cmd = connector.cnn.CreateCommand();
            cmd.CommandText = string.Format("select name from site where siteID = {0}",id);
            using MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                name = rdr.GetString(0);
            }
            return name;
        }
        public static List<site> GetSites()
        {
            List<site> sites = new List<site>();
            DBConnector connector = new DBConnector();
            connector.cnn.Open();
            MySqlCommand cmd = connector.cnn.CreateCommand();
            cmd.CommandText = "select siteID, name, provinceID, address, address2, city, country, postalCode,phone, dayOfWeek,distanceFromWH,siteType,notes,active from site";
            using MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                int siteID = rdr.GetInt32(0);
                string siteName = rdr.GetString(1);
                sites.Add(new site(siteID, siteName));
            }
            return sites;
        }
        public string[] returnList()
        {
            string[] ret = new string[9];
            ret[0] = this.getID.ToString();
            ret[1] = this.getTxnID().ToString();
            ret[2] = this.getTxnType();
            ret[3] = this.getStatus();
            ret[4] = this.getTxnDate();
            ret[5] = this.getSiteID().ToString();
            ret[6] = this.getDeliveryID().ToString();
            ret[7] = this.getEmployeeID().ToString();
            ret[8] = this.getNotes();
            return ret;
        }
    }
}
