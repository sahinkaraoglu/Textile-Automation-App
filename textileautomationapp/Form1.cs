using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;


namespace textileautomationapp
{
    public partial class Form1 : Form
    {

        SqlConnection con;
        SqlDataReader dr;
        SqlCommand com;

        public Form1()
        {
            InitializeComponent();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
           

            string user = textBox1.Text;
            string password = textBox2.Text;

            con = new SqlConnection("Data Source=SAHIN\\SQLEXPRESS;Initial Catalog=textileDB;Integrated Security=True");
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from giris where ad='" + textBox1.Text + "' and sifre='" + textBox2.Text + "'";
            dr = com.ExecuteReader();

          if (dr.Read())

            {
                Form2 form2 = new Form2();
                form2.Show();  
                this.Hide();
            }
            else
            {
                MessageBox.Show("Giriş Hatalı");
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
