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

namespace personelotomasyonu
{
    public partial class yönetici_Giris : Form
    {
        SqlConnection bağlantı = new SqlConnection("Data Source=LAPTOP-QQ0GGKE3;Initial Catalog=PersonelTablo;Integrated Security=True");
        SqlCommand komut;
        SqlDataReader oku;

        public void KullanıcıGiriş(TextBox kullanıcı, TextBox şifre)
        {
            bağlantı.Open();
            komut = new SqlCommand();
            komut.Connection = bağlantı;
            komut.CommandText = "select * from Yönetici where kullanıcıAd='" + kullanıcı.Text + "'";
            oku = komut.ExecuteReader();
            if (oku.Read() == true)
            {
                if (şifre.Text == oku["şifre"].ToString())
                {
                    MessageBox.Show("Giriş Başarılı");
                    Yönetici_Giris2 yöneticiGirişiki = new Yönetici_Giris2();
                    yöneticiGirişiki.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Hatalı Şifre!");
                }
            }
            else
            {
                MessageBox.Show("Bilgilerinizi Kontrol Ediniz!");
            }
            bağlantı.Close();
        }
        public yönetici_Giris()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            KullanıcıGiriş(KullanıcıText, şifreText);
        }

        private void yönetici_Giris_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            giris gg = new giris();
            gg.Show();
            this.Hide();
        }
    }
}
