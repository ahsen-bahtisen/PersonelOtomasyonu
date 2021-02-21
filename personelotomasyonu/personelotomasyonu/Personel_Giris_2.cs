using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace personelotomasyonu
{
    public partial class Personel_Giris_2 : Form
    {
        
        
        public Personel_Giris_2()
        {
            InitializeComponent();
        }
        public string id11;
        Personel_Giris frm_prs = new Personel_Giris();
        private void Personel_Giris_2_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(lbl_id.ToString());
        }

        private void kişiLabel_Click(object sender, EventArgs e)
        {

        }
        SqlConnection bağlantı = new SqlConnection(@"Data Source=LAPTOP-QQ0GGKE3;Initial Catalog=PersonelTablo;Integrated Security=True");
        SqlDataReader dr;
        string aad = Personel_Giris_Cikis.aa;
        public DateTime nesne2;
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            DateTime zaman =  DateTime.Now;
           
           // string b = "";
           // Personel_Giris p = new Personel_Giris();
            bağlantı.Open();
            nesne2 = DateTime.Now;
            SqlCommand komut = new SqlCommand("UPDATE g SET cikis=@cikis WHERE id='" + lbl_id.Text.Trim().ToString() + "'", bağlantı);
            komut.Parameters.AddWithValue("@cikis", DateTime.Now.ToString());
            komut.ExecuteNonQuery();
            bağlantı.Close();
            this.Hide();
        }
    }
}
