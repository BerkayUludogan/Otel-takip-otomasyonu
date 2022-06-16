using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace Otel_Takip
{
    public partial class oda_ozell_tb : Form
    {
        baglanSinifi baglanSinifi;
        public oda_ozell_tb()
        {
            InitializeComponent();
            baglanSinifi = new baglanSinifi();
        }
        odalar_tb frm = new odalar_tb();
        void verigetir()
        {
            try
            {
                OleDbDataAdapter verial = new OleDbDataAdapter("Select * from oda_list where O_NO=" + odalar_tb.odano + "", baglanSinifi.baglan2);
                DataSet al = new DataSet();
                verial.Fill(al, "odalar");
                baglanSinifi.goster.Table = al.Tables[0];
                dataGridView1.DataSource = baglanSinifi.goster;
                dataGridView1.Columns[0].HeaderText = "Oda Numarası";
                dataGridView1.Columns[1].HeaderText = "Kat Numarası";
                dataGridView1.Columns[2].HeaderText = "Yatak Sayısı";
                dataGridView1.Columns[3].HeaderText = "Geniş Yatak Sayısı";
                dataGridView1.Columns[4].HeaderText = "Suit";
                dataGridView1.Columns[5].HeaderText = "Klima";
                dataGridView1.Columns[6].HeaderText = "Televizyon";
                dataGridView1.Columns[7].HeaderText = "Kapalı";
                dataGridView1.Columns[8].HeaderText = "Oda Fiyatı";
            }
            catch (OleDbException)
            {
                MessageBox.Show("Öncelikle Oda Seçiniz");
                this.Hide();
            }

        }
        private void oda_ozell_tb_Load(object sender, EventArgs e)
        {
            verigetir();
        }

        private void oda_ozell_tb_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm.Show();
        }
    }
}
