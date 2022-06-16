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
namespace Otel_Takip
{
    public partial class musteri_konuk_tb : Form
    {
        baglanSinifi baglanSinifi;
        public musteri_konuk_tb()
        {
            InitializeComponent();
            baglanSinifi = new baglanSinifi();
        }
        void data()
        {
            DataView dt = new DataView();
            SqlDataAdapter verial = new SqlDataAdapter("select o_no,tc,g_t from oda_musteri", baglanSinifi.baglan);
            DataSet al = new DataSet();
            verial.Fill(al, "OTEL");
            dt.Table = al.Tables[0];
            dataGridView1.DataSource = dt;

            dataGridView1.Columns[0].HeaderText = "Oda Numarası".ToString();
            dataGridView1.Columns[1].HeaderText = "T.C".ToString();
            dataGridView1.Columns[2].HeaderText = "Giriş Tarihi".ToString();
        }
        void data2()
        {
            DataView dt = new DataView();
            SqlDataAdapter verial = new SqlDataAdapter("select * from cikis where g_t>='" + Convert.ToDateTime(dateTimePicker1.Text).ToString("yyyyMMdd") + "' and g_t<='" + Convert.ToDateTime(dateTimePicker2.Text).ToString("yyyyMMdd") + "'", baglanSinifi.baglan);
            DataSet al = new DataSet();
            verial.Fill(al, "OTEL");
            dt.Table = al.Tables[0];
            dataGridView2.DataSource = dt;

            dataGridView2.Columns[0].HeaderText = "Oda Numarası".ToString();
            dataGridView2.Columns[1].HeaderText = "TC".ToString();
            dataGridView2.Columns[2].HeaderText = "Giriş Tarihi".ToString();
            dataGridView2.Columns[3].HeaderText = "Çıkış Tarihi".ToString();
            dataGridView2.Columns[4].HeaderText = "Çıkış Saati".ToString();
            dataGridView2.Columns[5].HeaderText = "Ödenen Tutar".ToString();
        }
        void data3()
        {
            DataView dt = new DataView();
            SqlDataAdapter verial = new SqlDataAdapter("select * from cikis", baglanSinifi.baglan);
            DataSet al = new DataSet();
            verial.Fill(al, "OTEL");
            dt.Table = al.Tables[0];
            dataGridView2.DataSource = dt;

            dataGridView2.Columns[0].HeaderText = "Oda Numarası".ToString();
            dataGridView2.Columns[1].HeaderText = "TC".ToString();
            dataGridView2.Columns[2].HeaderText = "Giriş Tarihi".ToString();
            dataGridView2.Columns[3].HeaderText = "Çıkış Tarihi".ToString();
            dataGridView2.Columns[4].HeaderText = "Çıkış Saati".ToString();
            dataGridView2.Columns[5].HeaderText = "Ödenen Tutar".ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            data2();
            int toplam = 0;
            for (int i = 0; i < dataGridView2.Rows.Count; ++i)
            {
                toplam += Convert.ToInt32(dataGridView2.Rows[i].Cells[5].Value);
            }
            label3.Text = toplam.ToString()+" TL";
        }

        private void musteri_konuk_tb_Load(object sender, EventArgs e)
        {
            data();
            data3(); int toplam = 0;
            for (int i = 0; i < dataGridView2.Rows.Count; ++i)
            {
                toplam += Convert.ToInt32(dataGridView2.Rows[i].Cells[5].Value);
            }
            label3.Text = "Toplam Gelir : "+toplam.ToString() + " TL";
        }
    }
}
