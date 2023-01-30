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
        public bool createTransaction()
        {
            try
            {
                DBConnector db = new DBConnector();
                MySqlConnection cnn = db.cnn;
                MySqlCommand cmd = cnn.CreateCommand();
                cnn.Open();
                cmd.CommandText = String.Format("insert into txnAudit (");
                }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
    }
}
