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
        public site(int siteID, string siteName)
        {
            this.siteID = siteID;
            this.siteName = siteName;
        }
        public int getID()
        {
            return siteID;
        }
        public string getName()
        {
            return siteName;
        }
        public static List<site> GetSites()
        {
            List<site> sites = new List<site>();
            DBConnector connector = new DBConnector();
            connector.cnn.Open();
            MySqlCommand cmd = connector.cnn.CreateCommand();
            cmd.CommandText = "select siteID, name from site";
            using MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                int siteID = rdr.GetInt32(0);
                string siteName = rdr.GetString(1);
                sites.Add(new site(siteID, siteName));
            }
            return sites;
        }
    }
}
