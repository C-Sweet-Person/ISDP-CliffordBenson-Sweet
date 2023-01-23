using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace ISDP_FinalProject
{
    internal class DBConnector
    {
        public string connectionString;
        public MySqlConnection cnn;
        public DBConnector()
        {
            connectionString = "Server=127.0.0.1;Database=bullseyedb2023;Uid=root;port=3306;password=mysql";
            cnn = new MySqlConnection(connectionString);
        }
        /*
         * This code gets results from the vehicles class.
         * This is going to eventually get more complicated.
         * But it does do it's job.
         */
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
        /*
         * This part will be the login.
         * It will get the username and password and see if they match.
         * If they do, return a true boolean.
         * Else, return false.
         */
        public bool login(string username, string password)
        {
            string passwordTest;
            try
            {
                cnn.Open();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = String.Format("select username, password,firstName,lastName from employee where username = '{0}'", username);
                using MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (rdr.GetString(0) == password)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Help", "Error");
            }
            return false;
        }

    }
}
