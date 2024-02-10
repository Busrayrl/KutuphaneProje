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
namespace WindowsFormsApp6
{
    public partial class ogrenci : Form
    {
        public ogrenci(string val)
        {
            InitializeComponent();
           
        }
        SqlConnection baglanti = new SqlConnection((@"Data Source = W11; Initial Catalog = girisdb; Integrated Security = True"));
        public ogrenci()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {

            DialogResult result1 = MessageBox.Show("Uygulamayı kapatmaya eminmisin?",
            "Uygulama Çıkış", MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            kitap k = new kitap();
            k.Show();
            this.Hide();

        }

        private void isim_Click(object sender, EventArgs e)
        {


        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void sifre1_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            yayin y = new yayin();
            y.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            iade_et et = new iade_et();
            et.Show();
            this.Hide();
        }
        public void populate()
        {
            baglanti = new SqlConnection((@"Data Source = W11; Initial Catalog = girisdb; Integrated Security = True"));
            baglanti.Open();
            SqlDataAdapter  da = new SqlDataAdapter("select * from ogrenci",baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            ogrenciDGV.DataSource = tablo;
            baglanti.Close();
            
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (kullanici_txt.Text == "" || bolum_txt.Text == "" || mail_txt.Text == "" || tel_txt.Text == "")
            {
                MessageBox.Show("Eksik bilgi girdiniz..");
            }
            else
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into ogrenci(ogr_adi,ogr_bolum,email,telefon) values(@ogr_adi,@ogr_bolum,@email,@telefon)",baglanti);
                komut.Parameters.AddWithValue("@ogr_adi", kullanici_txt.Text);
                komut.Parameters.AddWithValue("@ogr_bolum", bolum_txt.Text);
                komut.Parameters.AddWithValue("@email", mail_txt.Text);
                komut.Parameters.AddWithValue("@telefon", tel_txt.Text);
                komut.ExecuteNonQuery();
                 
                MessageBox.Show("Öğrenci başarılı bir şekilde eklendi");
                 baglanti.Close();
                populate();
            }
        }

        private void ogrenci_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
        }

        private void ogrenciDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void ogrenciDGV_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ogrenciDGV_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            if (kullanici_txt.Text == "")
            {
                MessageBox.Show("İsminizi giriniz..");
            }
            else
            {   
                  
                string query = "delete from ogrenci where ogr_adi='"+kullanici_txt.Text+"';" ;
                SqlCommand komut = new SqlCommand(query,baglanti);
                komut.Parameters.AddWithValue("@ogr_adi", Convert.ToString(kullanici_txt));
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                
                MessageBox.Show("Öğrenci başarılı bir şekilde silindi");
                populate();


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            home1 hh = new home1();
            this.Hide();
            hh.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            odunc_ver v = new odunc_ver();
            this.Hide();
            v.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            gunun_kitabi gg = new gunun_kitabi();
            gg.Show();
            this.Hide();
        }
    }
}

