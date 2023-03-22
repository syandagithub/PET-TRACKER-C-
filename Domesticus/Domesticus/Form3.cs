using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Domesticus
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            textBox1.Text = Form2.user1;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
        public static string user11 = "";
        private void button1_Click(object sender, EventArgs e)
        {
           
            string bree = breed.Text;
            string Type = type.Text;
            string colo = colour.Text;
            string oID = textBox1.Text;
            string birth = dob.Text;
            string Pid = pid.Text;
            string Gender = gender.Text;

            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\users\syanda m\documents\visual studio 2017\Projects\Domesticus\Domesticus\PETS.accdb");
            try
            {

                conn.Open();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;

                cmd.CommandText = "INSERT INTO Table1 (IDNO,BREED,PETTYPE,COLOUR,GENDER,PETID,DATEOFBIRTH) values('" + oID + "','" + bree + "','" + Type + "','" + colo + "','" + Gender + "','" + Pid + "','" + birth + "')";
                cmd.ExecuteNonQuery();

                MessageBox.Show(" PET REGISTERED SUCCESSFULLY");
                conn.Close();


            }
            catch (IOException E )
            {
                System.Runtime.InteropServices.Marshal.GetHRForException(E);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            user11 = textBox1.Text;
            SetVisibleCore(false);

            Form4 f4 = new Form4();
          
            
            f4.Show();

        }
    }
}
