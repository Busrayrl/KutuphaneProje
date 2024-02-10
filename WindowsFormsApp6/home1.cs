using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace WindowsFormsApp6
{

    public partial class home1 : Form
    {
        public home1()
        {
            InitializeComponent();
            
            
        }


        SqlConnection baglanti = new SqlConnection((@"Data Source = W11; Initial Catalog = girisdb; Integrated Security = True"));

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void home_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlDataAdapter sd = new SqlDataAdapter("select count(*) from kitap ", baglanti);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            kitap_lbl.Text = dt.Rows[0][0].ToString();

            SqlDataAdapter od = new SqlDataAdapter("select count(*) from ogrenci ", baglanti);
            DataTable dts = new DataTable();
            od.Fill(dts);
            ogrenci_lbl.Text = dts.Rows[0][0].ToString();
            baglanti.Close();

            SqlDataAdapter yd = new SqlDataAdapter("select count(*) from yayin_kitap ", baglanti);
            DataTable dty = new DataTable();
            yd.Fill(dty);
            yayin_lbl.Text = dty.Rows[0][0].ToString();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 obj = new Form1();
            obj.Show();
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

        private void button3_Click(object sender, EventArgs e)
        {


            home1 hh = new home1();
            this.Hide();
            hh.Show();
        }

        private void isim_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }


        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ogrenci ogr = new ogrenci();
            ogr.Show();
            this.Hide();
            /*this.hide();
             Form1 f=new Form1();
            f.Show();* ÇIKIŞ SEMBOLÜNE TIKLAYINCA ANA SAYFAYA GELMESİ*/
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

        private void button9_Click(object sender, EventArgs e)
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
