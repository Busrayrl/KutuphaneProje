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
    public partial class kitap : Form
    {
        public kitap()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection((@"Data Source = W11; Initial Catalog = girisdb; Integrated Security = True"));
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ogrenci obj = new ogrenci();
            obj.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            home1 hh = new home1();
            this.Hide();
            hh.Show();
        }

        private void kitap_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button5_Click(object sender, EventArgs e)
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
            SqlDataAdapter da = new SqlDataAdapter("select * from kitap", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            kitapDGV.DataSource = tablo;
            baglanti.Close();

        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (kitap_txt.Text == "" || yazar_txt.Text == "" || yayin.Text == "" || tür.Text == ""||saysayisi_txt.Text==""||ksayisi_txt.Text=="")
            {
                MessageBox.Show("Eksik bilgi girdiniz..");
            }
            else
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into kitap(kitap_adi,yazar,yayınevi,türü,sayfa_sayisi,adet) values(@kitap_adi,@yazar,@yayınevi,@türü,@sayfasayisi,@adet)", baglanti);
                komut.Parameters.AddWithValue("@kitap_adi", kitap_txt.Text);
                komut.Parameters.AddWithValue("@yazar", yazar_txt.Text);
                komut.Parameters.AddWithValue("@yayınevi", yayin.Text);
                komut.Parameters.AddWithValue("@türü", tür.Text);
                komut.Parameters.AddWithValue("@sayfasayisi", saysayisi_txt.Text);
                komut.Parameters.AddWithValue("@adet", ksayisi_txt.Text);
                komut.ExecuteNonQuery();

                MessageBox.Show("Kitap başarılı bir şekilde eklendi");
                baglanti.Close();
                populate();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
           
            
            
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            if (kitap_txt.Text == "")
            {
                MessageBox.Show("Kitap adını giriniz");
            }
            else
            {
                string query = "delete from kitap where kitap_adi='"+kitap_txt.Text+"';";
                SqlCommand komut = new SqlCommand(query, baglanti);
                komut.Parameters.AddWithValue("@ogr_adi", Convert.ToString(kitap_txt.Text));
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Kitap başarılı bir şekilde silindi");
                populate();
            }
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

        private void button13_Click(object sender, EventArgs e)
        {

           
        }
    }
}
