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
    public partial class odunc_ver : Form
    {
        public odunc_ver()
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
                

            }
            baglanti.Close();
        }
        public void populate()
        {
            baglanti = new SqlConnection((@"Data Source = W11; Initial Catalog = girisdb; Integrated Security = True"));
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from odunc_ver", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            oduncDGV.DataSource = tablo;
            baglanti.Close();

        }

        private void KitapDoldurma()
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("Select  kitap_adi,türü from kitap ", baglanti);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("kitap_adi", typeof(string));
            dt.Columns.Add("türü", typeof(string));
            dt.Load(rdr);
            k2.ValueMember = "kitap_adi";
            tür.ValueMember = "türü";
            k2.DataSource = dt;
            tür.DataSource = dt;
            baglanti.Close();
        }
        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void button7_Click(object sender, EventArgs e)
        {
            iade_et et = new iade_et();
            et.Show();
            this.Hide();
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

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void odunc_ver_Load(object sender, EventArgs e)
        {
            OgrenciDoldurma();
            populate();
            OgrenciGoster();
            KitapDoldurma();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox2.ImageLocation = openFileDialog1.FileName;
         
            resim_txt.Text = openFileDialog1.FileName;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            baglanti.Open();
       SqlCommand komut = new SqlCommand("insert into odunc_ver(ogr_id,ogr_adi,ogr_bolum,kitap_adi,türü," +
    "kitap_resim,aciklama,puan)values(@ogr_id,@ogr_adi,@ogr_bolum,@kitap_adi,@türü,@kitap_resim,@aciklama,@puan)",baglanti);
            komut.Parameters.AddWithValue("@ogr_id", id_cb.Text);
            komut.Parameters.AddWithValue("@ogr_adi", og_txt.Text);
            komut.Parameters.AddWithValue("@ogr_bolum", b2_txt.Text);
            komut.Parameters.AddWithValue("@kitap_adi", k2.Text);
            komut.Parameters.AddWithValue("@türü", tür.Text);
            komut.Parameters.AddWithValue("@kitap_resim", resim_txt.Text);
            komut.Parameters.AddWithValue("@aciklama", yorum_txt.Text);
            komut.Parameters.AddWithValue("@puan",float.Parse( puan_txt.Text));
            komut.ExecuteNonQuery();
            MessageBox.Show("Kayıt Başarılı Bir Şekilde  Eklendi"); 
            baglanti.Close();
            populate();
            KitapDoldurma();
        }

        private void id_cb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OgrenciGoster();
        }

        private void oduncDGV_Click(object sender, EventArgs e)
        {

        }

        private void oduncDGV_CellClick(object sender, DataGridViewCellEventArgs e)
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
