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
    public partial class Personel_Ekle_Sil : Form
    {
        SqlConnection bağlantı = new SqlConnection("Data Source=LAPTOP-QQ0GGKE3;Initial Catalog=PersonelTablo;Integrated Security=True");
        SqlCommand komut;
        SqlDataAdapter da;
        public Personel_Ekle_Sil()
        {
            InitializeComponent();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (yapildi.Checked == true) { yapilmadi.Checked = false; }
            else { yapilmadi.Checked = true; }
        }

        private void Personel_Ekle_Sil_Load(object sender, EventArgs e)
        {
            groupBox3.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "INSERT INTO personelTablo(AdSoyad,TcKimlik,KullanıcıAdı,Şifre,Gorev,Cinsiyet,AskerlikD,EğitimDurumu,MedeniD,MailAdresi) VALUES(@AdSoyad,@TcKimlik,@KullanıcıAdı,@Şifre,@Gorev,@Cinsiyet,@AskerlikD,@EğitimDurumu,@MedeniD,@MailAdresi)";
            komut = new SqlCommand(sorgu,bağlantı);
            komut.Parameters.AddWithValue("@AdSoyad", isims.Text);
            komut.Parameters.AddWithValue("@TcKimlik", tc.Text);
            komut.Parameters.AddWithValue("@KullanıcıAdı", kadı.Text);
            komut.Parameters.AddWithValue("@Şifre", sifre.Text);
            komut.Parameters.AddWithValue("@Gorev", gorev.Text);
            if (kadin.Checked == true) { komut.Parameters.AddWithValue("@Cinsiyet", "Kadın"); }
            else { komut.Parameters.AddWithValue("@Cinsiyet", "Erkek"); }
            if (yapildi.Checked == true) { komut.Parameters.AddWithValue("@AskerlikD", "Yapıldı"); }
            else { komut.Parameters.AddWithValue("@AskerlikD", "Yapılmadı"); }
            komut.Parameters.AddWithValue("@EğitimDurumu", egitim.Text);
            komut.Parameters.AddWithValue("@MedeniD", MedeniDurumCombo.Text);
            komut.Parameters.AddWithValue("@MailAdresi", mail.Text);
            bağlantı.Open();
            komut.ExecuteNonQuery();
            bağlantı.Close();
            MessageBox.Show(isims.Text+" Adlı Personel Eklendi...");
            isims.Text = "";
            tc.Text = "";
            kadı.Text = "";
            sifre.Text = "";
            gorev.Text = "";
            egitim.Text = "";
            MedeniDurumCombo.Text = "";
            mail.Text = "";

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (erkek.Checked == true)
            {
                kadin.Checked = false;
                groupBox3.Enabled = true;
            }
            else
            {
                groupBox3.Enabled = false;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM personelTablo WHERE TcKimlik='"+tcsil.Text+"'";
            komut = new SqlCommand(sorgu,bağlantı);
            //komut.Parameters.AddWithValue("@TcKimlik",tcsil.Text);
            bağlantı.Open();
            komut.ExecuteNonQuery();
            bağlantı.Close();  
            MessageBox.Show(tcsil.Text+" Tc'li Personel Kaydı Silindi...");
            tcsil.Text = "";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (kadin.Checked == true) { erkek.Checked = false; }
            else { erkek.Checked = true; }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (yapilmadi.Checked == true) { yapildi.Checked = false; }
            else { yapildi.Checked = true; }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Yönetici_Giris2 gd = new Yönetici_Giris2();
            gd.Show();
            this.Hide();
        }
    }
}
