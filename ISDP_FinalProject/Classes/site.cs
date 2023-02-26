using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISDP_FinalProject
{
    public class site
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
        public string getProvince()
        {
            return provinceID;
        }
        public string getAddress()
        {
            return address;
        }
        public string getAddress2()
        {
            return address2;
        }
        public string getCity()
        {
            return city;
        }
        public string getCountry()
        {
            return country;
        }
        public string getPostalCode()
        {
            return postalCode;
        }
        public string getPhone()
        {
            return phone;
        }
        public string getDayOfWeek()
        {
            return dayOfWeek;
        }
        public int getDistanceFromWH()
        {
            return distanceFromWH;
        }
        public string getSiteType()
        {
            return siteType;
        }
        public string getNotes()
        {
            return notes;
        }
         public bool getActive()
        {
            return active;
        }
        
        /*
         * This is the end
         * of the getters section.
         * Now onto the main code.
         */
        public static site getSiteByID(int id)
        {
            site location = null;
            DBConnector connector = new DBConnector();
            connector.cnn.Open();
            MySqlCommand cmd = connector.cnn.CreateCommand();
            cmd.CommandText = string.Format("select * from site where siteID = {0}",id);
            using MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                int siteID = rdr.GetInt32(0);
                string siteName = rdr.GetString(1);
                string province = rdr.GetString(2);
                string address = rdr.GetString(3);
                string address2 = rdr.IsDBNull(4) ? null : rdr.GetString(4);
                string city = rdr.GetString(5);
                string country = rdr.GetString(6);
                string postalCode = rdr.GetString(7);
                string phone = rdr.GetString(8);
                string dayOfWeek = rdr.GetString(9);
                int distanceFromWH = rdr.GetInt32(10);
                string siteType = rdr.GetString(11);
                string notes = rdr.IsDBNull(12) ? null : rdr.GetString(12);
                bool active = rdr.GetBoolean(13);
                location = new site(siteID, siteName, province, address, address2, city, country, postalCode, phone, dayOfWeek, distanceFromWH, siteType, notes, active);
            }
            return location;
        }
        public static List<site> GetSites()
        {
            List<site> sites = new List<site>();
            DBConnector connector = new DBConnector();
            connector.cnn.Open();
            MySqlCommand cmd = connector.cnn.CreateCommand();
            cmd.CommandText = "select * from site";
            using MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                int siteID = rdr.GetInt32(0);
                string siteName = rdr.GetString(1);
                string province = rdr.GetString(2);
                string address = rdr.GetString(3);
                string address2 = rdr.IsDBNull(4) ? null : rdr.GetString(4);
                string city = rdr.GetString(5);
                string country = rdr.GetString(6);
                string postalCode = rdr.GetString(7);
                string phone = rdr.GetString(8);
                string dayOfWeek = rdr.GetString(9);
                int distanceFromWH = rdr.GetInt32(10);
                string siteType = rdr.GetString(11);
                string notes = rdr.IsDBNull(12) ? null : rdr.GetString(12);
                bool active = rdr.GetBoolean(13);
                sites.Add(new site(siteID, siteName,province,address,address2,city,country,postalCode,phone,dayOfWeek,distanceFromWH,siteType,notes,active));
            }
            return sites;
        }
        public string[] returnList()
        {
            string[] ret = new string[14];
            ret[0] = this.getID().ToString();
            ret[1] = this.getName();
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


        //
        //
        //Adds an location based on the given site sent to it.
        //
        //
        public static bool addLocation(site location)
        {
            try
            {
                DBConnector db = new DBConnector();
                MySqlConnection cnn = db.cnn;
                MySqlCommand cmd = cnn.CreateCommand();
                cnn.Open();
                cmd.CommandText = String.Format("insert into site(name,provinceID,address,address2,city,country,postalCode,phone,dayOfWeek,distanceFromWH,siteType,notes,active) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')", location.getName(), location.getProvince(), location.getAddress(), location.getAddress2(), location.getCity(),location.getCountry(),location.getPostalCode(),location.getPhone(),location.dayOfWeek,location.getDistanceFromWH(),location.getSiteType(),location.getNotes(),true);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        //
        //
        // Edit an location given an location.
        //
        //
        public static bool EditLocation(site location)
        {
            DBConnector db = new DBConnector();
            MySqlConnection cnn = db.cnn;
            MySqlCommand cmd = cnn.CreateCommand();
            cnn.Open();
            cmd.CommandText = String.Format("update site set name = '{0}', provinceID = '{1}', address = '{2}', address2 = '{3}', city = '{4}', country = '{5}', postalCode = '{6}', phone = '{7}', dayOfWeek = '{8}', distanceFromWH = {9}, siteType = '{10}' where siteID = {11}", location.getName(), location.getProvince(), location.getAddress(), location.getAddress(), location.getAddress2(), location.getCity(), location.getCountry(), location.getPostalCode(), location.getPhone(), location.getDayOfWeek(), location.getDistanceFromWH(), location.getSiteType(), location.getNotes(), location.getID());
            cmd.ExecuteNonQuery();
            return true;
        }
        public static bool deleteLocation(int locationID)
        {
            bool worked = false;
            try
            {
                DBConnector db = new DBConnector();
                MySqlConnection cnn = db.cnn;
                cnn.Open();
                site locale = site.getSiteByID(locationID);
                string userName = locale.getName();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = String.Format("update site set active = 0 where name = '{0}';", userName);
                cmd.ExecuteNonQuery();
                worked = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return worked;
        } 
        /*
         * This is the end
         * of the main tools
         * section.
         */
    }
}
