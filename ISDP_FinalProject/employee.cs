using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISDP_FinalProject
{
    public class employee
    {
        private int id;
        private string username;
        private string password;
        private string firstName;
        private string lastName;
        private string email;
        private bool active;
        private bool locked;
        private int positionID;
        private int siteID;

        public employee(int id, string username, string password, string firstName, string lastName, string email, bool active, bool locked, int positionID, int siteID)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.active = active;
            this.locked = locked;
            this.positionID = positionID;
            this.siteID = siteID;

        }
        /*
         * This section contains all
         * of the getters for each of
         * the properties of the class
         * ***** START OF GETTER SECTION *****
         */
        public int getID()
        { return this.id; }
        public string getUsername()
        { return this.username; }
        public string getPassword()
        { return this.password; }
        public string getFirstName()
        { return this.firstName; }
        public string getLastName()
        { return this.lastName; }
        public string getEmail()
        { return this.email; }
        public bool getActive()
        { return this.active; }
        public bool getLocked()
        { return this.locked; }
        public int getSiteID()
        { return this.siteID; }
        public int getPositionID()
        { return this.positionID; }
        public string returnAll()
        { return string.Format("ID: {0}\nUsername: {1}\nPassword: {2}\nFirst Name: {3}\nLast Name: {4}\nEmail: {5}\nActive: {6}\nLocked: {7}\nSiteID: {8}\nPositionID: {9}", getID(), getUsername(), getPassword(), getFirstName(), getLastName(), getEmail(), getActive(), getLocked(), getSiteID(), getPositionID()); }
        public string[] returnList()
        {
            string[] ret = new string[10];
            ret[0] = Convert.ToString(this.getID());
            ret[1] = this.getUsername();
            ret[2] = this.getPassword();
            ret[3] = this.getFirstName();
            ret[4] = this.getLastName();
            ret[5] = this.getEmail();
            ret[6] = this.getActive() == true ? "1" : "0";
            ret[7] = this.getLocked() == true ? "1" : "0";
            ret[8] = Convert.ToString(getSiteID());
            ret[9] = Convert.ToString(getPositionID());
            return ret;
        }
        /*
         * ***** END OF GETTER SECTION ******
         * 
         */

        //This converts a boolean value to a int.
        public int boolConvert(bool boolean)
        {
            int booleanCon;
            if (boolean)
            {
                booleanCon = 1;
            }
            else
            {
                booleanCon = 0;
            }
            return booleanCon;
        }
        //
        //
        //Gets just the username for each employee.
        //
        //
        public static List<String> GetUsernames()
        {
            List<String> users = new List<String>();
            DBConnector db = new DBConnector();
            MySqlConnection cnn = db.cnn;
            cnn.Open();
            MySqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "select username from employee";
            using MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                string uName = rdr.GetString(0);
                users.Add(uName);
            }
            return users;
        }
        //
        //
        //Gets the IDS of all of the employees.
        //
        //
        public static List<int> GetIDs()
        {
            List<int> IDs = new List<int>();
            DBConnector db = new DBConnector();
            MySqlConnection cnn = db.cnn;
            cnn.Open();
            MySqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = "select employeeID from employee";
            using MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                IDs.Add(id);
            }
            return IDs;
        }
        //
        //
        //Gets the latest ID and adds one to it.
        //
        //
        public static int newID()
        {
            return employee.GetIDs()[GetIDs().Count - 2] + 1;
        }
        //
        //
        //Gets an employee via their username.
        //
        //
        public static employee GetEmployeeByUsername(string username)
        {
            employee obj = null;
            try
            {
                DBConnector db = new DBConnector();
                MySqlConnection cnn = db.cnn;
                cnn.Open();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "select * from employee where username = '" + username + "';";
                using MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int id = rdr.GetInt32(0);
                    string userName = rdr.GetString(1);
                    string password = rdr.GetString(2);
                    string firstName = rdr.GetString(3);
                    string lastName = rdr.GetString(4);
                    string email = rdr.GetString(5);
                    bool active = rdr.GetBoolean(6);
                    bool locked = rdr.GetBoolean(7);
                    int positionID = rdr.GetInt32(8);
                    int siteID = rdr.GetInt32(9);
                    obj = new employee(id, userName, password, firstName, lastName, email, active, locked, positionID, siteID);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return obj;
        }
        //
        //
        //Adds an employee based on the given worker sent to it.
        //
        //
        public static bool addEmployee(employee worker)
        {
            try
            {
                DBConnector db = new DBConnector();
                MySqlConnection cnn = db.cnn;
                MySqlCommand cmd = cnn.CreateCommand();
                cnn.Open();
                cmd.CommandText = String.Format("insert into employee(employeeID, username,password,firstName,lastName,email,active,locked,positionID,siteID) VALUES ({0},'{1}','{2}','{3}','{4}','{5}',{6},{7},{8},{9})",employee.newID(), worker.getUsername(), worker.getPassword(), worker.getFirstName(), worker.getLastName(), worker.getEmail(), worker.boolConvert(worker.getActive()), worker.boolConvert(worker.getLocked()), worker.getPositionID(), worker.getSiteID());
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return true;
        }
        //
        //
        // Edit an employee given an employee.
        //
        //
        public static bool EditEmployee(employee worker)
        {
            DBConnector db = new DBConnector();
            MySqlConnection cnn = db.cnn;
            MySqlCommand cmd = cnn.CreateCommand();
            cnn.Open();
            cmd.CommandText = String.Format("update employee set username = '{0}', password = '{1}', firstName = '{2}', lastName = '{3}', email = '{4}', active = {5}, locked = {6}, positionID = {7}, siteID = {8} where employeeID = {9}", worker.getUsername(), worker.getPassword(), worker.getFirstName(), worker.getLastName(), worker.getEmail(), worker.boolConvert(worker.getActive()), worker.boolConvert(worker.getLocked()), worker.getPositionID(), worker.getSiteID(), worker.getID());
            cmd.ExecuteNonQuery();
            return true;
        }
        public static bool deleteEmployee(string username)
        {
            try
            {
                DBConnector db = new DBConnector();
                MySqlConnection cnn = db.cnn;
                cnn.Open();
                employee worker = employee.GetEmployeeByUsername(username);
                string userName = worker.getUsername();
                MySqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = String.Format("delete from employee where username = '{0}';",userName);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
    }
}

