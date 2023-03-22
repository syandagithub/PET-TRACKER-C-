using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Domesticus
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        public static string user1 = "";
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\users\syanda m\documents\visual studio 2017\Projects\Domesticus\Domesticus\Owners.accdb");
        OleDbDataAdapter da;
        DataTable dt = new DataTable();
        private void LOG_Click(object sender, EventArgs e)
        {
            user1 = textBox1.Text;
            string user = textBox1.Text;
            string pass = textBox2.Text;

            conn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from Table1 where IDNO='" + user + "' and PASSWOR='" + pass + "'", conn);

            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read() == true)
            {
                MessageBox.Show("Login Successful");
                Form2 f2 = new Form2();
                f2.Dispose();

                Form3 f3 = new Form3();
               
                f3.Show();
            }
            else
            {
                MessageBox.Show("Invalid Credentials, Please Re-Enter");
            }
            conn.Close();

        }

        private void CLR_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}
