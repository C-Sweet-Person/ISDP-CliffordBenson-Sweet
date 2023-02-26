using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISDP_FinalProject
{
    internal class Permission
    {
        private string permissionID;
        public Permission(string permissionID)
        {
            this.permissionID = permissionID;
        }
        public static List<Permission> getPermissionsByUser(string username)
        {
            List<Permission> permissions = new List<Permission>();
            DBConnector db = new DBConnector();
            MySqlConnection cnn = db.cnn;
            MySqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = string.Format("select permissionID from permission where usernameID = '{0}'", username);
            cnn.Open();
            using MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                string permission = rdr.GetString(0);
                permissions.Add(new Permission(permission));
            }
            return permissions;
        }
    }
   
}
