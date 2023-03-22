using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Domesticus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

           
        }
      
    

        //  OleDbConnection conn = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\SYANDA M\Documents\Owners.accdb");
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\users\syanda m\documents\visual studio 2017\Projects\Domesticus\Domesticus\Owners.accdb");

      
        private void reg_Click(object sender, EventArgs e)
        {
           
            string ID = id.Text;
            string nam = name.Text;
            string sur = surname.Text;
            string cont = contact.Text;
            string pass = password.Text;
            string add = address.Text;





            try
            {
                
                conn.Open();

                OleDbCommand cmd = new OleDbCommand("select * from Table1 where IDNO= '" + ID + "'", conn);
                OleDbDataReader dr = cmd.ExecuteReader();

                if (dr.Read() == true)

                {
                    MessageBox.Show("USER ID ALREADY EXISTS");
                    conn.Close();
                    dr.Close();
                }
                else
                {


                         OleDbCommand cmd2 = new OleDbCommand();
                    cmd2.Connection = conn;

                    cmd2.CommandText = "INSERT INTO Table1 (NAM,SURNAME,CONTACT,IDNO,PASSWOR,ADDRESS) values('" + nam + "','" + sur + "','" + cont + "','" + ID + "','" + pass + "','" + add + "')";
                    cmd2.ExecuteNonQuery();

                    MessageBox.Show(" PET OWNER REGISTERED SUCCESSFULLY");
                    conn.Close();
                    Form2 f2 = new Form2();
                    f2.Show();
                }
              
            }
            catch(IOException )
            {
                MessageBox.Show("");
            }



        }

        private void CLR_Click(object sender, EventArgs e)
        {
            id.Clear();
            name.Clear();
            surname.Clear();
            address.Clear();
            contact.Clear();
            password.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetVisibleCore(false);
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void address_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void id_TextChanged(object sender, EventArgs e)
        {

        }

        private void contact_TextChanged(object sender, EventArgs e)
        {

        }

        private void surname_TextChanged(object sender, EventArgs e)
        {

        }

        private void name_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
