using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISDP_FinalProject
{
    internal class Transaction
    {
        private int txnAuditID;
        private int txnID;
        private string txnType;
        private string status;
        private string txnDate;
        private int SiteID;
        private int deliveryID;
        private int employeeID;
        private string notes;
        public Transaction(int txnAuditID, int txnID, string txnType, string status, string txnDate, int SiteID, int deliveryID, int employeeID, string notes)
        {
            this.txnAuditID = txnAuditID;
            this.txnID = txnID;
            this.txnType = txnType;
            this.status = status;
            this.txnDate = txnDate;
            this.SiteID = SiteID;
            this.deliveryID = deliveryID;
            this.employeeID = employeeID;
            this.notes = notes;
        }
        public int getAuditID()
        {
            return txnAuditID;
        }
        public int getTxnID()
        {
            return txnID;
        }
        public string getTxnType()
        {
            return txnType;
        }
        public string getStatus()
        {
            return status;
        }
        public string getTxnDate()
        {
            return txnDate;
        }
        public int getSiteID()
        {
            return SiteID;
        }
        public int getDeliveryID()
        {
            return deliveryID;
        }
        public int getEmployeeID()
        {
            return employeeID;
        }
        public string getNotes()
        {
            return notes;
        }
        public static List<Transaction> GetTransactions()
        {
            DBConnector db = new DBConnector();
            MySqlConnection cnn = db.cnn;
            MySqlCommand cmd = cnn.CreateCommand();
            List<Transaction> transactions = new List<Transaction>();
            cnn.Open();
            cmd.CommandText = "select * from txnAudit";
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                int txnAuditID = rdr.GetInt32(0);
                int txnID = rdr.GetInt32(1);
                string txnType = rdr.GetString(2);
                string status = rdr.GetString(3);
                string txnDate = rdr.GetString(4);
                int SiteID = rdr.GetInt32(5);
                int deliveryID = rdr.GetInt32(6);
                int employeeID = rdr.GetInt32(7);
                string notes = rdr.GetString(8);
                transactions.Add(new Transaction(txnAuditID,txnID,txnType,status,txnDate,SiteID,deliveryID,employeeID,notes));
            }
            return transactions;
        }
        //
        //
        //Get stringlist of all elements.
        //
        //
        public string[] returnList()
        {
            string[] ret = new string[9];
            ret[0] = this.getAuditID().ToString();
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
        public bool createTransaction()
        {
            try
            {
                DBConnector db = new DBConnector();
                MySqlConnection cnn = db.cnn;
                MySqlCommand cmd = cnn.CreateCommand();
                cnn.Open();
                cmd.CommandText = string.Format("insert into txnAudit (txnID, txnType, status, txnDate, SiteID, deliveryID, employeeID, notes) values ({0},'{1}','{2}','{3}','{4}',{5},{6},'{7}')", getTxnID(), getTxnType(), getStatus(), getTxnDate(), getSiteID(), getDeliveryID(), getEmployeeID(), getNotes());
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return false;
            }
            return true;
        }
    }
}
