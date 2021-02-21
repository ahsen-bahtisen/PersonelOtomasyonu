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
    public partial class Personel_Giris : Form
    {
        public Personel_Giris()
        {
            InitializeComponent();
        }
        public string Ad { get; set; }
        public string saat { get; set; }
        SqlConnection baglan = new SqlConnection(@"Data Source=LAPTOP-QQ0GGKE3;Initial Catalog=PersonelTablo;Integrated Security=True");
        SqlDataAdapter da;
        SqlCommand komut;
        SqlDataReader read;
        SqlCommand kom;
        int kontrol = 0;
        SqlConnection bağlantı = new SqlConnection(@"Data Source=LAPTOP-QQ0GGKE3;Initial Catalog=PersonelTablo;Integrated Security=True");
        SqlDataReader oku;
        string personel_id1="-1";
        void Göster()
        {
            baglan.Open();
            da = new SqlDataAdapter("Select AdSoyad from g where KullanıcıAdı='"+textBox1.Text+"' ", baglan);
            DataTable tablo = new DataTable();
            label4.Text = da.ToString();
           
            baglan.Close();
        }
        public void veriAl(TextBox şifre)
        {
            bağlantı.Open();
            SqlCommand kom = new SqlCommand("select * from personelTablo where Şifre like '"+şifre.Text+"'",bağlantı);
            SqlDataReader read = kom.ExecuteReader();
            while (read.Read())
            {
                 Ad= read["AdSoyad"].ToString();
                 DateTime nesne = DateTime.Now;
                 MessageBox.Show(nesne.ToString());
                 
            }
            bağlantı.Close();
        }
        public void KullanıcıGiriş(TextBox kullanıcı, TextBox şifre)
        {
            bağlantı.Open();
            komut = new SqlCommand();
            komut.Connection = bağlantı;
            komut.CommandText = "select * from personelTablo where KullanıcıAdı='" + textBox1.Text + "'";
            oku = komut.ExecuteReader();
            if (oku.Read() == true)
            {
                if (şifre.Text == oku["Şifre"].ToString())
                {
                    MessageBox.Show("Giriş Başarılı");
                    personel_id1 = oku["PersonelNo"].ToString();
                    kontrol=1;
                }
                else
                {
                    MessageBox.Show("Hatalı Şifre!");
                    personel_id1 = "-1";
                    kontrol = 0;
                }
            }
            else
            {
                MessageBox.Show("Bilgilerinizi Kontrol Ediniz!");
                kontrol = 0;
                personel_id1 = "-1";
            }
            bağlantı.Close();
        }
        public DateTime nesne1;
        public string id;
        public static string adisoyadi;
        private void button1_Click(object sender, EventArgs e)
        {
            veriAl(textBox2);
           // MessageBox.Show(Ad);
            KullanıcıGiriş(textBox1,textBox2);
            if (kontrol==1)
            {
                adisoyadi = textBox1.Text;
                string a = "", b = "";

                baglan.Open();
                da = new SqlDataAdapter("Select AdSoyad from personelTaplo where KullanıcıAdı='" + textBox1.Text + "' ", baglan);
                DataTable tablo = new DataTable();
                label4.Text = da.ToString();
                nesne1 = DateTime.Now;
                SqlCommand komut = new SqlCommand("INSERT into g (personel_id,adsoyad,giris)VALUES('"+personel_id1.ToString()+"','" + Ad + "','" + nesne1 + "')", baglan);

                komut.ExecuteNonQuery();
                baglan.Close();
                baglan.Open();
                SqlCommand komut1 = new SqlCommand("select max(id) as id1 from g", baglan);
                SqlDataReader dr = komut1.ExecuteReader();
                while (dr.Read())
                {
                    id = dr["id1"].ToString();
                }
                baglan.Close();
                Personel_Giris_2 pg3 = new Personel_Giris_2();
                pg3.lbl_id.Text = id.ToString();
                pg3.Show();
                this.Hide();
            }
            else
            {

            }
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime zaman = DateTime.Now;
            label3.Text = zaman.ToString();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            giris g = new giris();
            g.Show();
            this.Hide();
        }
    }
}
