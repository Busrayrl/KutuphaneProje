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
    public partial class iade_et : Form
    {
        public iade_et()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection((@"Data Source = W11; Initial Catalog = girisdb; Integrated Security = True"));
        private void OgrenciDoldurma()
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("Select  ogr_id from ogrenci ", baglanti);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("ogr_id", typeof(int));
            dt.Load(rdr);
            id_cb.ValueMember = "ogr_id";
            id_cb.DataSource = dt;

            baglanti.Close();
        }
        private void OgrenciGoster()
        {
            baglanti.Open();
            string query = "Select * from ogrenci where ogr_id =" + id_cb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, baglanti);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                og_txt.Text = dr["ogr_adi"].ToString();
                b2_txt.Text = dr["ogr_bolum"].ToString();
                t2_txt.Text = dr["telefon"].ToString();

            }
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
        public void populateReturn()
        {
           
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from iade_kitap", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            iadeDGV.DataSource = tablo;
            baglanti.Close();

        }
        private void KitapDoldurma()
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("Select  kitap_adi from kitap ", baglanti);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("kitap_adi", typeof(string));
            dt.Load(rdr);
            k2.ValueMember = "kitap_adi";
            k2.DataSource = dt;

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

        private void button5_Click(object sender, EventArgs e)
        {
            kitap k = new kitap();
            k.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            yayin y = new yayin();
            y.Show();
            this.Hide();
        }

        private void iadeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void iade_et_Load(object sender, EventArgs e)
        {
            populate();
            populateReturn();
            KitapDoldurma();
            OgrenciDoldurma();
            OgrenciGoster();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (id_cb.Text == "" || og_txt.Text == "" || b2_txt.Text == ""||t2_txt.Text=="" || k2.Text == "" || ytarih.Text == ""|| iadetarih.Text=="")
            {
                MessageBox.Show("Eksik bilgi girdiniz..");
            }
            else
            {
                
                baglanti.Open();

                SqlCommand komut = new SqlCommand("insert into iade_kitap(ogr_id,ogr_adi,ogr_bolum,telefon,geri_kitap,yayin_tarih,geri_tarih) values(@ogr_id,@ogr_adi,@ogr_bolum,@telefon,@geri_kitap,@yayin_tarih,@geri_tarih)", baglanti);
                komut.Parameters.AddWithValue("@ogr_id", id_cb.Text);
                komut.Parameters.AddWithValue("@ogr_adi", og_txt.Text);
                komut.Parameters.AddWithValue("@ogr_bolum", b2_txt.Text);
                komut.Parameters.AddWithValue("@telefon", t2_txt.Text);
                komut.Parameters.AddWithValue("@geri_kitap", k2.Text);
                komut.Parameters.AddWithValue("@yayin_tarih", ytarih.Text);
                komut.Parameters.AddWithValue("@geri_tarih", iadetarih.Text);
                komut.ExecuteNonQuery();

                MessageBox.Show("Kitap bilgisi eklendi");
                baglanti.Close();
                populate();
                populateReturn();


            }
        }

        private void id_cb_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void id_cb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OgrenciGoster();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            odunc_ver v = new odunc_ver();
            this.Hide();
            v.Show();
        }

        private void k2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            gunun_kitabi gg = new gunun_kitabi();
            gg.Show();
            this.Hide();
        }
    }
}
