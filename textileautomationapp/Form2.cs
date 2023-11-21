using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Security.Cryptography;
using Microsoft.Office.Interop.Excel;
using excel = Microsoft.Office.Interop.Excel;


using DataTable = System.Data.DataTable;



namespace textileautomationapp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=SAHIN\\SQLEXPRESS;Initial Catalog=textileDB;Integrated Security=True");

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'textileDBDataSet.ilceler' table. You can move, or remove it, as needed.
            this.ilcelerTableAdapter.Fill(this.textileDBDataSet.ilceler);
            // TODO: This line of code loads data into the 'textileDBDataSet.iller' table. You can move, or remove it, as needed.
            this.illerTableAdapter.Fill(this.textileDBDataSet.iller);



            textBox9.Visible= false;
            textBox2.MaxLength = 50;
            textBox3.MaxLength = 15;
            textBox4.MaxLength = 15;
            comboBox1.MaxLength = 20;
            comboBox2.MaxLength = 20;
            textBox5.MaxLength = 100;
            textBox6.MaxLength = 40;
            textBox7.MaxLength = 30;
            textBox8.MaxLength = 30;


            comboBox5.Items.Add("Şirket");
            comboBox5.Items.Add("Gsm");
            comboBox5.Items.Add("Telefon");
            comboBox5.Items.Add("İl");
            comboBox5.Items.Add("İlçe");
            comboBox5.Items.Add("Adres");
            comboBox5.Items.Add("Mail");
            comboBox5.Items.Add("Website");
            comboBox5.Items.Add("Yetkili Kişi");
            comboBox5.Items.Add("Ürünler");
            comboBox5.Items.Add("Ürün Türleri");

            comboBox1.Text = "İl seçimi yapınız.";
            comboBox2.Text = "İlçe seçimi yapınız.";
            comboBox5.Text = "Arama Türünü Giriniz.";



            ClearCode();
            kayitGetir();
            DataList();
            datagridHeaderText();

           


        }



        void datagridHeaderText()
        {
            dataGridView1.Columns[0].HeaderText = "Şirket";
            dataGridView1.Columns[1].HeaderText = "Gsm";
            dataGridView1.Columns[2].HeaderText = "Telefon";
            dataGridView1.Columns[3].HeaderText = "İl";
            dataGridView1.Columns[4].HeaderText = "İlçe";
            dataGridView1.Columns[5].HeaderText = "Adres";
            dataGridView1.Columns[6].HeaderText = "Mail";
            dataGridView1.Columns[7].HeaderText = "Web Site";
            dataGridView1.Columns[8].HeaderText = "Yetkili Kişi";
            dataGridView1.Columns[9].HeaderText = "Ürünler";
            dataGridView1.Columns[10].HeaderText = "Ürün Türleri";

            dataGridView1.Columns[5].Width =150;
            dataGridView1.Columns[10].Width = 150;

            dataGridView1.Columns[11].Visible = false;



        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBox1.Text == "")
                {
                    MessageBox.Show("Şirket bilgisi boş geçilemez.");
                }
                else
                {


                    string urunler = "";
            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                if (i != 0)
                    urunler += ",";
                urunler += checkedListBox1.CheckedItems[i].ToString();
            }


            string uruntur = "";
            for (int i = 0; i < checkedListBox2.CheckedItems.Count; i++)
            {
                if (i != 0)
                    uruntur += ",";
                uruntur += checkedListBox2.CheckedItems[i].ToString();
            }
            


            con.Open();

            SqlCommand DataAdd = new SqlCommand("insert into textileDB.dbo.bilgi(sirket,gsm, telefon, il, ilce, adres, mail, website, yetkilikisi, urunler, uruntur)" +
                " values(@sirket, @gsm, @telefon, @il, @ilce, @adres, @mail, @website,@yetkilikisi, @urunler, @uruntur)", con);
            DataAdd.Parameters.AddWithValue("@sirket", textBox1.Text);
            DataAdd.Parameters.AddWithValue("@gsm", textBox2.Text);
            DataAdd.Parameters.AddWithValue("@telefon", textBox3.Text);
            DataAdd.Parameters.AddWithValue("@il", comboBox1.Text);
            DataAdd.Parameters.AddWithValue("@ilce", comboBox2.Text);
            DataAdd.Parameters.AddWithValue("@adres", textBox4.Text);
            DataAdd.Parameters.AddWithValue("@mail", textBox5.Text);
            DataAdd.Parameters.AddWithValue("@website", textBox6.Text);
            DataAdd.Parameters.AddWithValue("@yetkilikisi", textBox7.Text);
            DataAdd.Parameters.AddWithValue("@urunler",urunler);
            DataAdd.Parameters.AddWithValue("@uruntur", uruntur);

            DataAdd.ExecuteNonQuery();
            con.Close();

           
            DataList();
                }

            }
            catch
            {
                MessageBox.Show("Bir hata oluştu! Tekrar deneyiniz.");
            }
            finally
            {
                ClearCode();
            }

        }
        private void kayitGetir()
        {

            con.Open();
            string kayit = "SELECT * from bilgi";
            SqlCommand komut = new SqlCommand(kayit, con);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();


        }

        public void ClearCode()
        {

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();

            checkedListBox1.SetItemChecked(0, false);
            checkedListBox1.SetItemChecked(1, false);

            checkedListBox2.SetItemChecked(0, false);
            checkedListBox2.SetItemChecked(1, false);
            checkedListBox2.SetItemChecked(2, false);
            checkedListBox2.SetItemChecked(3, false);
            checkedListBox2.SetItemChecked(4, false);
            checkedListBox2.SetItemChecked(5, false);
            checkedListBox2.SetItemChecked(6, false);
            checkedListBox2.SetItemChecked(7, false);
            checkedListBox2.SetItemChecked(8, false);
            checkedListBox2.SetItemChecked(9, false);
            checkedListBox2.SetItemChecked(10, false);
            checkedListBox2.SetItemChecked(11, false);
            checkedListBox2.SetItemChecked(12, false);
            checkedListBox2.SetItemChecked(13, false);
            checkedListBox2.SetItemChecked(14, false);
            checkedListBox2.SetItemChecked(15, false);
            checkedListBox2.SetItemChecked(16, false);
            checkedListBox2.SetItemChecked(17, false);
            checkedListBox2.SetItemChecked(18, false);
            checkedListBox2.SetItemChecked(19, false);
            checkedListBox2.SetItemChecked(20, false);
            checkedListBox2.SetItemChecked(21, false);
            checkedListBox2.SetItemChecked(22, false);
            checkedListBox2.SetItemChecked(23, false);
            checkedListBox2.SetItemChecked(24, false);
            checkedListBox2.SetItemChecked(25, false);
            checkedListBox2.SetItemChecked(26, false);
            checkedListBox2.SetItemChecked(27, false);
            checkedListBox2.SetItemChecked(28, false);
            checkedListBox2.SetItemChecked(29, false);
            checkedListBox2.SetItemChecked(30, false);
            checkedListBox2.SetItemChecked(31, false);
            checkedListBox2.SetItemChecked(32, false);
            checkedListBox2.SetItemChecked(33, false);
            checkedListBox2.SetItemChecked(34, false);
            checkedListBox2.SetItemChecked(35, false);
            checkedListBox2.SetItemChecked(36, false);
            checkedListBox2.SetItemChecked(37, false);
            checkedListBox2.SetItemChecked(38, false);
            checkedListBox2.SetItemChecked(39, false);
            checkedListBox2.SetItemChecked(40, false);
            checkedListBox2.SetItemChecked(41, false);
            checkedListBox2.SetItemChecked(42, false);
            checkedListBox2.SetItemChecked(43, false);
            checkedListBox2.SetItemChecked(44, false);
            checkedListBox2.SetItemChecked(45, false);
            checkedListBox2.SetItemChecked(46, false);
            checkedListBox2.SetItemChecked(47, false);
            checkedListBox2.SetItemChecked(48, false);
            checkedListBox2.SetItemChecked(49, false);
            checkedListBox2.SetItemChecked(50, false);
            checkedListBox2.SetItemChecked(51, false);




            comboBox5.Text = "Arama Türünü Giriniz.";

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            try
            {



                if (textBox1.Text == "")
                {


                    MessageBox.Show("Güncellenecek veri seçilmemiştir.");

                }
                else
                {

                    string urunler = "";
                    for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                    {
                        if (i != 0)
                            urunler += ",";
                        urunler += checkedListBox1.CheckedItems[i].ToString();
                    }


                    string uruntur = "";
                    for (int i = 0; i < checkedListBox2.CheckedItems.Count; i++)
                    {
                        if (i != 0)
                            uruntur += ",";
                        uruntur += checkedListBox2.CheckedItems[i].ToString();
                    }


                    con.Open();
                    SqlCommand dataUpdate = new SqlCommand("update  bilgi set sirket=@sirket,gsm=@gsm,telefon=@telefon,il=@il,ilce=@ilce,adres=@adres" +
                        ",mail=@mail,website=@website,yetkilikisi=@yetkilikisi,urunler=@urunler, uruntur=@uruntur where id=@id", con);
                    dataUpdate.Parameters.AddWithValue("@sirket", textBox1.Text);
                    dataUpdate.Parameters.AddWithValue("@gsm", textBox2.Text);
                    dataUpdate.Parameters.AddWithValue("@telefon", textBox3.Text);
                    dataUpdate.Parameters.AddWithValue("@il", comboBox1.Text);
                    dataUpdate.Parameters.AddWithValue("@ilce", comboBox2.Text);
                    dataUpdate.Parameters.AddWithValue("@adres", textBox4.Text);
                    dataUpdate.Parameters.AddWithValue("@mail", textBox5.Text);
                    dataUpdate.Parameters.AddWithValue("@website", textBox6.Text);
                    dataUpdate.Parameters.AddWithValue("@yetkilikisi", textBox7.Text);
                    dataUpdate.Parameters.AddWithValue("@urunler", urunler);
                    dataUpdate.Parameters.AddWithValue("@uruntur", uruntur);
                    dataUpdate.Parameters.AddWithValue("@id", textBox9.Text);
                    dataUpdate.ExecuteNonQuery();
                    con.Close();
                    DataList();

                }
            }
            catch
            {
                MessageBox.Show("Bir hata oluştu. Tekrar deneyiniz.");
            }
            finally
            {

            }

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearCode();
            DataList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult sil = new DialogResult();

            DialogResult secenek = MessageBox.Show("İşlem yapılsın mı?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (secenek == DialogResult.Yes)
            {
                con.Open();
                SqlCommand dataDelete = new SqlCommand("Delete from bilgi where id=@id", con);
                dataDelete.Parameters.AddWithValue("@id", textBox9.Text);
                dataDelete.ExecuteNonQuery();
                con.Close();
                DataList();
            }
            else if (secenek == DialogResult.No)
            {
            }


            if (textBox1.Text == "")
            {
                MessageBox.Show("Silinecek kaydı seçiniz.");

            }
            else
            {

                con.Open();
                SqlCommand dataDelete = new SqlCommand("Delete from bilgi where id=@id", con);
                dataDelete.Parameters.AddWithValue("@id", textBox9.Text);
                dataDelete.ExecuteNonQuery();
                con.Close();
                DataList();
            }

            if (sil == DialogResult.No)
            {
                MessageBox.Show("Silme işlemi onaylanmadı..");
            }



   

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();

            checkedListBox1.SetItemChecked(0, false);
            checkedListBox1.SetItemChecked(1, false);




            checkedListBox2.SetItemChecked(0, false);
            checkedListBox2.SetItemChecked(1, false);
            checkedListBox2.SetItemChecked(2, false);
            checkedListBox2.SetItemChecked(3, false);
            checkedListBox2.SetItemChecked(4, false);
            checkedListBox2.SetItemChecked(5, false);
            checkedListBox2.SetItemChecked(6, false);
            checkedListBox2.SetItemChecked(7, false);
            checkedListBox2.SetItemChecked(8, false);
            checkedListBox2.SetItemChecked(9, false);
            checkedListBox2.SetItemChecked(10, false);
            checkedListBox2.SetItemChecked(11, false);
            checkedListBox2.SetItemChecked(12, false);
            checkedListBox2.SetItemChecked(13, false);
            checkedListBox2.SetItemChecked(14, false);
            checkedListBox2.SetItemChecked(15, false);
            checkedListBox2.SetItemChecked(16, false);
            checkedListBox2.SetItemChecked(17, false);
            checkedListBox2.SetItemChecked(18, false);
            checkedListBox2.SetItemChecked(19, false);
            checkedListBox2.SetItemChecked(20, false);
            checkedListBox2.SetItemChecked(21, false);
            checkedListBox2.SetItemChecked(22, false);
            checkedListBox2.SetItemChecked(23, false);
            checkedListBox2.SetItemChecked(24, false);
            checkedListBox2.SetItemChecked(25, false);
            checkedListBox2.SetItemChecked(26, false);
            checkedListBox2.SetItemChecked(27, false);
            checkedListBox2.SetItemChecked(28, false);
            checkedListBox2.SetItemChecked(29, false);
            checkedListBox2.SetItemChecked(30, false);
            checkedListBox2.SetItemChecked(31, false);
            checkedListBox2.SetItemChecked(32, false);
            checkedListBox2.SetItemChecked(33, false);
            checkedListBox2.SetItemChecked(34, false);
            checkedListBox2.SetItemChecked(35, false);
            checkedListBox2.SetItemChecked(36, false);
            checkedListBox2.SetItemChecked(37, false);
            checkedListBox2.SetItemChecked(38, false);
            checkedListBox2.SetItemChecked(39, false);
            checkedListBox2.SetItemChecked(40, false);
            checkedListBox2.SetItemChecked(41, false);
            checkedListBox2.SetItemChecked(42, false);
            checkedListBox2.SetItemChecked(43, false);
            checkedListBox2.SetItemChecked(44, false);
            checkedListBox2.SetItemChecked(45, false);
            checkedListBox2.SetItemChecked(46, false);
            checkedListBox2.SetItemChecked(47, false);
            checkedListBox2.SetItemChecked(48, false);
            checkedListBox2.SetItemChecked(49, false);
            checkedListBox2.SetItemChecked(50, false);
            checkedListBox2.SetItemChecked(51, false);





            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                string[] urunler = dataGridView1.CurrentRow.Cells[9].Value.ToString().Split(',');
                for (int j = 0; j < urunler.Length; j++)
                {
                    if (checkedListBox1.Items[i].ToString() == urunler[j])
                    {
                        checkedListBox1.SetItemChecked(i, true);
                    }
                }
            }


            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                string[] uruntur = dataGridView1.CurrentRow.Cells[10].Value.ToString().Split(',');
                for (int j = 0; j < uruntur.Length; j++)
                {
                    if (checkedListBox2.Items[i].ToString() == uruntur[j])
                    {
                        checkedListBox2.SetItemChecked(i, true);
                    }
                }
            }
        }
        void DataList()
        {
            con.Open();
            SqlDataAdapter veri = new SqlDataAdapter("select * from bilgi order by id desc", con);
            DataTable table = new DataTable();
            veri.Fill(table);
            dataGridView1.DataSource = table;
            con.Close();
        }
        private void kısayollarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Delete: Kayıt Sil        F5 : Yeni Kayıt   \n Not: Seçili kayıtlar aktarılırken 'Ctrl' ile tek, 'Shift' tuşu ile sürekli seçim yapar.");
        }
        void dataOrder()
        {
            dataGridView1.Sort(dataGridView1.Columns[11], ListSortDirection.Descending);
        }
        

        public static string dataSend;
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.SelectedIndex == 0)
            {
                dataSend = "sirket";
            }
            else if (comboBox5.SelectedIndex == 1)
            {
                dataSend = "gsm";
            }
            else if (comboBox5.SelectedIndex == 2)
            {
                dataSend = "telefon";
            }
            else if (comboBox5.SelectedIndex == 3)
            {
                dataSend = "il";
            }
            else if (comboBox5.SelectedIndex == 4)
            {
                dataSend = "ilce";
            }
            else if (comboBox5.SelectedIndex == 5)
            {
                dataSend = "adres";
            }
            else if (comboBox5.SelectedIndex == 6)
            {
                dataSend = "mail";
            }
            else if (comboBox5.SelectedIndex == 7)
            {
                dataSend = "website";
            }
            else if (comboBox5.SelectedIndex == 8)
            {
                dataSend = "yetkilikisi";
            }
            else if (comboBox5.SelectedIndex == 9)
            {
                dataSend = "urunler";
            }
            else if (comboBox5.SelectedIndex == 10)
            {
                dataSend = "uruntur";
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

                con.Open();
                DataTable tbl = new DataTable();
                SqlDataAdapter searchGet = new SqlDataAdapter("select * from [bilgi] where " + dataSend + " like '%" + textBox8.Text + "%'", con);
                searchGet.Fill(tbl);
                con.Close();
                dataGridView1.DataSource = tbl;
                dataOrder();


        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Delete)
            {
                btnDelete.PerformClick();
            }


            if (e.KeyCode == Keys.F5)
            {
                btnNew.PerformClick();
            }

        }

        private void tümKayıtlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            excel.Application app = new excel.Application();
            app.Visible = true;
            Workbook kitap = app.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sayfa = (Worksheet)kitap.Sheets[1];

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                Range alan = (Range)sayfa.Cells[1, 1];
                alan.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;

            }
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    Range alan2 = (Range)sayfa.Cells[j + 1, i + 1];
                    alan2.Cells[2, 1] = dataGridView1[i, j].Value;
                }

            }
        }

        private void seçiliKayıtlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            excel.Application app = new excel.Application();
            app.Visible = true;
            Workbook kitap = app.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sayfa = (Worksheet)kitap.Sheets[1];
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                Range alan = (Range)sayfa.Cells[1, 1];
                alan.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;

            }
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.SelectedRows[i].Cells.Count; j++)
                {
                    Range alan2 = (Range)sayfa.Cells[i + 1, j + 1];
                    alan2.Cells[2, 1] = dataGridView1.SelectedRows[i].Cells[j].Value;
                }

            }
        }
    }
}
