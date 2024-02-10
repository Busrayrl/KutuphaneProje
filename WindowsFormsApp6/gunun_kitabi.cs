using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;


namespace WindowsFormsApp6
    
{
    public partial class gunun_kitabi : Form
    {
        public gunun_kitabi()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        Image res;
        string[] resimler = Directory.GetFiles("img");
        int resimYeri = 0;
     
        Random rastgele = new Random();
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void ResimEkle()
        {
            for (int i = 0; i < resimler.Length; i++)
            {
                PictureBox pb = new PictureBox();
                pb.Size = new Size(110, 110);
                pb.ImageLocation = resimler[i];
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                flowLayoutPanel1.Controls.Add(pb);
                
            }
        }
        
        private void ResimGuncelle()
        {
            pictureBox2.ImageLocation = resimler[resimYeri];
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
            home1 hh = new home1();
            this.Hide();
            hh.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ogrenci obj = new ogrenci();
            obj.Show();
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
            odunc_ver v = new odunc_ver();
            this.Hide();
            v.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            kitap k = new kitap();
            k.Show();
            this.Hide();
        }
        
        
        private void gunun_kitabi_Load(object sender, EventArgs e)
        { 
            flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            ResimGuncelle();
            ResimEkle();
        }
        
        private void button11_Click(object sender, EventArgs e)
        {
            
        }

        

        private void button12_Click(object sender, EventArgs e)
        {
            do
            {
                int resimYeri2 = rastgele.Next(0, resimler.Length);
                if (resimYeri != resimYeri2)
                {
                   
                    resimYeri = resimYeri2;
                    break;
                }
            }

            while (true);
            {
                ResimGuncelle();
          
            }

            
        }
        
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        

        private void k2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            con=new SqlConnection((@"Data Source = W11; Initial Catalog = girisdb; Integrated Security = True"));
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT TOP 1 söz FROM gunun_sozu ORDER BY NEWID()";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text += dr["söz"]+Environment.NewLine;
             }
            con.Close();
        }
    }
}
