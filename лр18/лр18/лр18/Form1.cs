using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlTypes;
using System.Data.Odbc;
namespace лр18
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            OleDbConnection = new OleDbConnection(connectstring);
            OleDbConnection.Open();
        }
         
        public static string connectstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=test1.mdb";
        OleDbConnection OleDbConnection;
        OleDbCommand dbCommand;
 
        private void button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT  ФИО  FROM  Tabel  WHERE id=1";
            dbCommand = new OleDbCommand(query, OleDbConnection);

            dbCommand.ExecuteScalar().ToString();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "test1DataSet.table". При необходимости она может быть перемещена или удалена.
            this.tableTableAdapter.Fill(this.test1DataSet.table);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "testDataSet2.Таблица2". При необходимости она может быть перемещена или удалена.

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            OleDbConnection.Close();
        }

       
    }
}
