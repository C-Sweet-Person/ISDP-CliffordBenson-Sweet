using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISDP_FinalProject
{
    public partial class ViewTransactions : Form
    {
        public ViewTransactions()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }
        private void refresh()
        {
            dataTransactionsView.Rows.Clear();
            dataTransactionsView.Columns.Clear();
            DBConnector db = new DBConnector();
            List<Transaction> transactions = Transaction.GetTransactions();
            List<string> list = employee.GetUsernamesNotActive();
  
            dataTransactionsView.Columns.Add("ID", "txnID");
            dataTransactionsView.Columns.Add("AuditID", "txnAuditID");
            dataTransactionsView.Columns.Add("txnType", "txnType");
            dataTransactionsView.Columns.Add("status", "status");
            dataTransactionsView.Columns.Add("txnDate", "txnDate");
            dataTransactionsView.Columns.Add("siteID", "siteID");
            dataTransactionsView.Columns.Add("deliveryID", "deliveryID");
            dataTransactionsView.Columns.Add("employeeID", "employeeID");
            dataTransactionsView.Columns.Add("notes", "notes");


            foreach (Transaction transaction in transactions)
            {

                dataTransactionsView.Rows.Add(transaction.returnList());
            }
        }
    }
}
