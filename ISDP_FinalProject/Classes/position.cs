using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISDP_FinalProject
{
    internal class position
    {
        public int positionID;
        public string permissionLevel;
        public position(int mypositionId, string mypermissionLevel)
        {
            this.positionID = mypositionId;
            this.permissionLevel = mypermissionLevel;
        }
        public int getID()
        { return this.positionID; }
        public string getPermissionLevel()
        { return this.permissionLevel; }
        public static string getPermissionLevelByID(int id)
        {
            string level = null;
            DBConnector connector = new DBConnector();
            connector.cnn.Open();
            MySqlCommand cmd = connector.cnn.CreateCommand();
            cmd.CommandText = string.Format("select permissionLevel from posn where positionID = {0}", id);
            using MySqlDataReader rdr = cmd.ExecuteReader();
            while(rdr.Read())
            {
                level = rdr.GetString(0);
            }
            return level;
        }
        public static List<position> GetPositions()
        {
            List<position> positions = new List<position>();
            DBConnector connector = new DBConnector();
            connector.cnn.Open();
            MySqlCommand cmd = connector.cnn.CreateCommand();
            cmd.CommandText = "select * from posn";
            using MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                int posID = rdr.GetInt32(0);
                string permissionLevel = rdr.GetString(1);
                positions.Add(new position(posID, permissionLevel));
            }
            return positions;
        }
    }
}
