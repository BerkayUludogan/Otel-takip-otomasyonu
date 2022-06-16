using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
namespace Otel_Takip
{
    public partial class rez_bil_tb : Form
    {
        baglanSinifi baglanSinifi;
        public rez_bil_tb()
        {
            InitializeComponent();
            baglanSinifi = new baglanSinifi();
        }
        void data()
        {
            SqlDataAdapter verial = new SqlDataAdapter("Select * from rezer where oda_no='" + odalar_tb.odano + "'", baglanSinifi.baglan);

            verial.Fill(baglanSinifi.al, "OTEL");
            baglanSinifi.goster.Table = baglanSinifi.al.Tables[0];
            dataGridView1.DataSource = baglanSinifi.goster;
            dataGridView1.Columns[0].HeaderText = "Oda Numarası" + "";
            dataGridView1.Columns[1].HeaderText = "Giriş Tarihi" + "";
            dataGridView1.Columns[2].HeaderText = "Ayrılış Tarihi" + "";
            dataGridView1.Columns[3].HeaderText = "Kişi Sayısı" + "";
            dataGridView1.Columns[4].HeaderText = "Oda Fiyatı" + "";
            baglanSinifi.baglan.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            odalar_tb frm = new odalar_tb();
            this.Close();
            frm.Show();

        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            this.Size = new Size(790, 346);
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Visible = true;
           
        }

        private void rez_bil_tb_FormClosed(object sender, FormClosedEventArgs e)
        {

            odalar_tb frm = new odalar_tb();
            frm.Show();
        }

        private void rez_bil_tb_Load(object sender, EventArgs e)
        {
            data();
        }
    }
}
