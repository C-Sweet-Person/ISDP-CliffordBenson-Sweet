using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace ISDP_FinalProject
{
    internal class DBConnector
    {
        public string connectionString;
        public MySqlConnection cnn;
        public DBConnector()
        {
            connectionString = "Server=localhost;Database=bullseyedb2023;Uid=root;password=mysql";
            cnn = new MySqlConnection(connectionString);
        }
        public List<string> GetResults()
        {
            List<string> results = new List<string>();
            try
            {
                cnn.Open();
                MessageBox.Show("Connection Open !");
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "select * from vehicle";
                using MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string s = rdr.GetString(0) + " " + rdr.GetDecimal(1) + " " + rdr.GetDecimal(2) + " " + rdr.GetDecimal(3) + " " + rdr.GetString(4);
                    results.Add(s);
                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Help", "Error");
            }
            return results;
        }
         
      
    }
}
