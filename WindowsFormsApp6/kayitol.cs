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
    public partial class kayitol : Form
    {
        public kayitol()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
           Form1 obj = new Form1();
            obj.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            if (kullanici_txt.Text == "" || sifre_txt.Text == ""||mail_txt.Text==""||telefon_txt.Text=="")
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız...");
            }
            else 
            { 
             SqlConnection baglanti = new SqlConnection((@"Data Source = W11; Initial Catalog = girisdb; Integrated Security = True"));
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into users(kullanici_adi,sifre,e_mail,telefon) values(@kullanici_adi,@sifre,@e_mail,@telefon)", baglanti);
            
            komut.Parameters.AddWithValue("@kullanici_adi", kullanici_txt.Text);
                komut.Parameters.AddWithValue("@sifre", sifre_txt.Text);
                komut.Parameters.AddWithValue("@e_mail", mail_txt.Text);
                komut.Parameters.AddWithValue("@telefon", telefon_txt.Text);
                komut.ExecuteNonQuery();
           
                baglanti.Close();
                MessageBox.Show("Kayıt Oldunuz...");
            
            }


          

           
               
             
               
            
            
            
        }
    }
}
