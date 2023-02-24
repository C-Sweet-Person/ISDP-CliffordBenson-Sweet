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
        /*
         * This is the getters section
         * There is a lot of them.
         * But this is where it starts.
         */
        public int getID()
        {
            return siteID;
        }
        public string getName()
        {
            return siteName;
        }
        private string getProvince()
        {
            return provinceID;
        }
        private string getAddress()
        {
            return address;
        }
        private string getAddress2()
        {
            return address2;
        }
        private string getCity()
        {
            return city;
        }
        private string getCountry()
        {
            return country;
        }
        private string getPostalCode()
        {
            return postalCode;
        }
        private string getPhone()
        {
            return phone;
        }
        private string getDayOfWeek()
        {
            return dayOfWeek;
        }
        private int getDistanceFromWH()
        {
            return distanceFromWH;
        }
        private string getSiteType()
        {
            return siteType;
        }
        private string getNotes()
        {
            return notes;
        }
         private bool getActive()
        {
            return active;
        }
        
        /*
         * This is the end
         * of the getters section.
         * Now onto the main code.
         */
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
                string province = rdr.GetString(2);
                string address = rdr.GetString(3);
                string address2 = rdr.GetString(4);
                string city = rdr.GetString(5);
                string country = rdr.GetString(6);
                string postalCode = rdr.GetString(7);
                string phone = rdr.GetString(8);
                string dayOfWeek = rdr.GetString(9);
                int distanceFromWH = rdr.GetInt32(10);
                string siteType = rdr.GetString(11);
                string notes = rdr.GetString(12);
                bool active = rdr.GetBoolean(13);
                sites.Add(new site(siteID, siteName,province,address,address2,city,country,postalCode,phone,dayOfWeek,distanceFromWH,siteType,notes,active));
            }
            return sites;
        }
        public string[] returnList()
        {
            string[] ret = new string[14];
            ret[0] = this.getID().ToString();
            ret[1] = this.getName()
            ret[2] = this.getProvince();
            ret[3] = this.getAddress();
            ret[4] = this.getAddress2();
            ret[5] = this.getCity();
            ret[6] = this.getCountry();
            ret[7] = this.getProvince();
            ret[8] = this.getPhone();
            ret[9] = this.getDayOfWeek();
            ret[10] = this.getDistanceFromWH().ToString();
            ret[11] = this.getSiteType();
            ret[12] = this.getNotes();
            ret[13] = this.getActive().ToString();
            return ret;
        }
    }
}
