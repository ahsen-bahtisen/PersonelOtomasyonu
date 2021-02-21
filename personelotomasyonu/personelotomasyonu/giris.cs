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
    public partial class giris : Form
    {
        
        
        public giris()
        {
            InitializeComponent();
        }
       
   

        private void button1_Click(object sender, EventArgs e)
        {
            yönetici_Giris frm2 = new yönetici_Giris();
            frm2.Show();
            this.Hide();
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Personel_Giris pg = new Personel_Giris();
            pg.Show();
            this.Hide();
        }

        private void giris_Load(object sender, EventArgs e)
        {
      
        }
    }
}
