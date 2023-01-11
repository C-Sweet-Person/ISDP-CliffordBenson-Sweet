using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ISDP_FinalProject
{
    class DBConnect
    {
        SqlConnection cnn;
        public void ConnectDB()
        {
            string connetionString;
            SqlConnection cnn;
            string username = "root";
            string password = "mysql";
            string URL = "null";
            string DB = "DB";
            connetionString = @"Data Source="+URL+";Initial Catalog="+DB+";User ID="+username+";Password="+password+"";
            this.cnn = new SqlConnection(connetionString);
            this.cnn.Open();
            MessageBox.Show("Connection Open  !");
        }
        public void testDB()
        {
            if (this.cnn == null)
            {
                MessageBox.Show("No connection made.", "ERROR");
            }
            else
            {
                cnn.CreateCommand().CommandText = "Help";
                cnn.BeginTransaction();
            }
        }
    }
   
}
