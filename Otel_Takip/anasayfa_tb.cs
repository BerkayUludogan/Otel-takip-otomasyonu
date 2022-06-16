using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otel_Takip
{
    public partial class anasayfa_tb : Form
    {
        baglanSinifi baglanSinifi;
        public anasayfa_tb()
        {
            InitializeComponent();
            baglanSinifi = new baglanSinifi();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            odalar_tb odalar = new odalar_tb();
            this.Hide();
            odalar.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            m_ekle_tb musteri = new m_ekle_tb();
            this.Hide();
            musteri.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            rez_tb rez = new rez_tb();
            this.Hide();
            rez.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            oda_ayar_tb ayar = new oda_ayar_tb();
            this.Hide();
            ayar.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            kull_tb kull = new kull_tb();
            this.Hide();
            kull.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            rapor_tb frm = new rapor_tb();
            this.Hide();
            frm.Show();
        }

        private void anasayfa_tb_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void anasayfa_tb_Load(object sender, EventArgs e)
        {
        }
    }
}
