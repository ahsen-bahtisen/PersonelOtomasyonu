using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace personelotomasyonu
{
    public partial class Yönetici_Giris2 : Form
    {
        public Yönetici_Giris2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Personel_Ekle_Sil pes = new Personel_Ekle_Sil();
            pes.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Personel_Giris_Cikis pgc = new Personel_Giris_Cikis();
            pgc.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            giris ac = new giris();
            ac.Show();
            this.Hide();
        }
    }
}
