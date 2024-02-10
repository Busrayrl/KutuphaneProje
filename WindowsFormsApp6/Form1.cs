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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Kulanıcı adı=Beyza şifre=1234
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

      

        private void label2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            kayitol obj = new kayitol();
            obj.Show();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source = W11; Initial Catalog = girisdb; Integrated Security = True");
        private void button2_Click(object sender, EventArgs e)
        {
            if (kullanici_txt.Text == "" || sifre_txt.Text == "")
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız...");
            }
            else
            {


                baglanti.Open();
                string user;
                string password;
                user = kullanici_txt.Text.ToString();
                password = sifre_txt.Text.ToString();
                SqlCommand komut = new SqlCommand("select * from users where kullanici_adi='" + user + "' and sifre='" + password + "'", baglanti);

                SqlDataReader oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    MessageBox.Show("Hoşgeldin" + " " + user + " ");
                    home1 hh=new home1();
                    this.Hide();
                    hh.Show();
                    
                }
                else
                {
                    MessageBox.Show("Hatalı Kullanıcı veya Şifre...");
                }
                baglanti.Close();
            }



        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sifre_txt.PasswordChar = '*';
            

        }
    }
}
