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
    public partial class yayin : Form
    {
        public yayin()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection((@"Data Source = W11; Initial Catalog = girisdb; Integrated Security = True"));
       private void OgrenciDoldurma()
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("Select  ogr_id from ogrenci ",baglanti);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("ogr_id",typeof(int));
            dt.Load(rdr);
            ogrenci_cb.ValueMember = "ogr_id";
            ogrenci_cb.DataSource = dt;

            baglanti.Close();
        }

        private void KitapDoldurma()
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("Select  kitap_adi from kitap ", baglanti);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("kitap_adi",typeof(string));
            dt.Load(rdr);
            kitap_cb.ValueMember = "kitap_adi";
            kitap_cb.DataSource = dt;

            baglanti.Close();
        }
        public void populate()
        {
            baglanti = new SqlConnection((@"Data Source = W11; Initial Catalog = girisdb; Integrated Security = True"));
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from yayin_kitap", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            yayinDGV.DataSource = tablo;
            baglanti.Close();

        }
        private void OgrenciGoster()
        {
            baglanti.Open();
            string query = "Select * from ogrenci where ogr_id =" + ogrenci_cb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, baglanti);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows) 
            {
                adi_txt.Text = dr["ogr_adi"].ToString();
                bol_txt.Text = dr["ogr_bolum"].ToString();
                tele_txt.Text = dr["telefon"].ToString();

            }
            baglanti.Close();
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ogrenci obj = new ogrenci();
            obj.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            kitap k = new kitap();
            k.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            iade_et et = new iade_et();
            et.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            home1 hh = new home1();
            this.Hide();
            hh.Show();

        }

        private void yayin_Load(object sender, EventArgs e)
        {
            OgrenciDoldurma();
            KitapDoldurma();
            populate();


        }
        

        private void button9_Click(object sender, EventArgs e)
        {

            if (ogrenci_cb.Text==""||adi_txt.Text == "" || bol_txt.Text == "" || kitap_cb.Text == "" || tarih.Text == "")
            {
                MessageBox.Show("Eksik bilgi girdiniz..");
            }
            else
            {
                string tarih2 = tarih.Value.Year.ToString() + "/" + tarih.Value.Month.ToString() + "/" + tarih.Value.Day.ToString();
                baglanti.Open();
                
                SqlCommand komut = new SqlCommand("insert into yayin_kitap(ogr_id,ogr_adi,ogr_bolum,telefon,y_kitap,yayin_tarih) values(@ogr_id,@ogr_adi,@ogr_bolum,@telefon,@y_kitap,@yayin_tarih)", baglanti);
                komut.Parameters.AddWithValue("@ogr_id", ogrenci_cb.Text);
                komut.Parameters.AddWithValue("@ogr_adi", adi_txt.Text);
                komut.Parameters.AddWithValue("@ogr_bolum", bol_txt.Text);
                komut.Parameters.AddWithValue("@telefon", tele_txt.Text);
                komut.Parameters.AddWithValue("@y_kitap", kitap_cb.Text);
                komut.Parameters.AddWithValue("@yayin_tarih", tarih.Text);
                komut.ExecuteNonQuery();

                MessageBox.Show("Kitap bilgisi eklendi");
                baglanti.Close();
                populate();


            }
        }

        private void ogrenci_cb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OgrenciGoster();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            odunc_ver v = new odunc_ver();
            this.Hide();
            v.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            gunun_kitabi gg = new gunun_kitabi();
            gg.Show();
            this.Hide();
        }
    }
    }

