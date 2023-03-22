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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        private OleDbDataReader dbReader;
        DateTime today = DateTime.Today;







        private DataTable getDetails()
        {
            string idd = textBox6.Text;
            string id = textBox1.Text;
            DataTable grid = new DataTable();
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\users\syanda m\documents\visual studio 2017\Projects\Domesticus\Domesticus\PETS.accdb");
            conn.Open();
            OleDbCommand dbCmd = new OleDbCommand();

            dbCmd.Connection = conn;
            string sql = "SELECT * FROM Table1 WHERE IDNO='"+idd+"' AND  PETID ='" + id + "'";
            dbCmd.CommandText = sql;

            dbReader = dbCmd.ExecuteReader();

            grid.Load(dbReader);

            conn.Close();

            return grid;

        }
        OleDbCommand dbCmd = new OleDbCommand();
        DataTable grid = new DataTable();
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\users\syanda m\documents\visual studio 2017\Projects\Domesticus\Domesticus\PETS.accdb");
        private DataTable getDetailsALL()
        {
            string idall = textBox2.Text;
            DataTable grid = new DataTable();
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\users\syanda m\documents\visual studio 2017\Projects\Domesticus\Domesticus\PETS.accdb");
            conn.Open();
            OleDbCommand dbCmd = new OleDbCommand();

            dbCmd.Connection = conn;
            string sql = "SELECT * FROM Table1 where  IDNO ='" + idall + "'";
            dbCmd.CommandText = sql;

            dbReader = dbCmd.ExecuteReader();

            grid.Load(dbReader);

            conn.Close();

            return grid;

        }
        private void button1_Click(object sender, EventArgs e)
        {

            //  OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\users\syanda m\documents\visual studio 2017\Projects\Domesticus\Domesticus\TEST.accdb");
            //string strSQL = "SELECT * FROM Table1 where PETID ='"+id+"'";

            //OleDbCommand command = new OleDbCommand(strSQL, conn);

            dataGridView1.DataSource = getDetails();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = getDetailsALL();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string pet = textBox1.Text;


            try
            {


                using (OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\users\syanda m\documents\visual studio 2017\Projects\Domesticus\Domesticus\PETS.accdb")) ;

                {



                    using (OleDbCommand deleteCommand = new OleDbCommand("DELETE FROM TABLE1 WHERE [PETID] = ?", conn))
                    {
                        conn.Open();

                        deleteCommand.Parameters.AddWithValue("@PETID", pet);

                        deleteCommand.ExecuteNonQuery();
                        MessageBox.Show("DELETEDSUCCESSFULLY");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string stat = textBox3.Text;
            string pid = textBox1.Text;


            try
            {


                using (OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\users\syanda m\documents\visual studio 2017\Projects\Domesticus\Domesticus\PETS.accdb")) ;

                {



                    using (OleDbCommand updateCommand = new OleDbCommand("UPDATE Table1 SET STATUS = '" + stat + "', DATEE='" + textBox4.Text + "'  WHERE PETID='" + pid + "'", conn))
                    {
                        conn.Open();



                        updateCommand.ExecuteNonQuery();
                        MessageBox.Show("STATUS UPDATED");
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            textBox4.Text = DateTime.Now.ToShortDateString();
            textBox6.Text = Form3.user11;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string newID = textBox5.Text;
            string stat = textBox3.Text;
            string pid = textBox1.Text;


            try
            {

                using (OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\users\syanda m\documents\visual studio 2017\Projects\Domesticus\Domesticus\PETS.accdb")) ;
                {



                    using (OleDbCommand updateCommand = new OleDbCommand("UPDATE Table1 SET IDNO = '" + newID + "', DATEE='" + textBox4.Text + "'  WHERE PETID='" + pid + "'", conn))
                    {
                        conn.Open();



                        updateCommand.ExecuteNonQuery();
                        MessageBox.Show("TRANSFERED TO NEW OWNER");
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            dataGridView1.DataSource = null;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form3 FQ = new Form3();
                FQ.Show();
        }
    }
}