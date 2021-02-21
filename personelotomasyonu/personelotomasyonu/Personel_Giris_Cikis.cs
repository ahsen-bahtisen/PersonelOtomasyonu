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
    public partial class Personel_Giris_Cikis : Form
    {
        public Personel_Giris_Cikis()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(@"Data Source=LAPTOP-QQ0GGKE3;Initial Catalog=PersonelTablo;Integrated Security=True");
        SqlDataAdapter da;
        public static string aa;
        void Göster()
        {
            baglan.Open();
            da = new SqlDataAdapter("Select * from g",baglan);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglan.Close();
        }
        void Göster2()
        {
            baglan.Open();
            da = new SqlDataAdapter("Select * from personelTablo", baglan);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView2.DataSource = tablo;
            baglan.Close();
        }

        private void Personel_Giris_Cikis_Load(object sender, EventArgs e)
        {
            Göster();
            Göster2();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        SqlDataAdapter da2;
        DataTable tablo2 = new DataTable();

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tablo2.Clear();
            da2 = new SqlDataAdapter("select * from g where personel_id='"+dataGridView2.CurrentRow.Cells[0].Value.ToString()+"'",baglan);
            da2.Fill(tablo2);
            dataGridView1.DataSource = tablo2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Göster();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Yönetici_Giris2 geri = new Yönetici_Giris2();
            geri.Show();
            this.Hide();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
