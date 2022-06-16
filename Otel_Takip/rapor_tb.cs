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
    public partial class rapor_tb : Form
    {
        baglanSinifi baglanSinifi;
        public rapor_tb()
        {
            InitializeComponent();
            baglanSinifi = new baglanSinifi();
        }
        DateTime OneMnt = DateTime.Today.AddMonths(-1);
        DateTime Ucay = DateTime.Today.AddMonths(-3);
        DateTime yill = DateTime.Today.AddYears(-1);
        DateTime today = DateTime.Today;
        ArrayList bir = new ArrayList();
        ArrayList uc = new ArrayList();
        ArrayList bir_yil = new ArrayList();
        void no()
        {
            baglanSinifi.baglan2.Open();
            baglanSinifi.sorgu2.Connection = baglanSinifi.baglan2;
            baglanSinifi.sorgu2.CommandText = "SELECT O_NO from oda_list";
            baglanSinifi.dr2 = baglanSinifi.sorgu2.ExecuteReader();
            while (baglanSinifi.dr2.Read())
            {
                comboBox1.Items.Add(baglanSinifi.dr2[0]);
            }
            baglanSinifi.baglan2.Close();
        }
        void bir_ay()
        {
            int toplam = 0;
            baglanSinifi.baglan.Open();
            baglanSinifi.sorgu.Connection = baglanSinifi.baglan;
            baglanSinifi.sorgu.CommandText = "SELECT o_no,ucret,g_t FROM cikis where g_t>='" + Convert.ToDateTime(OneMnt).ToString("yyyyMMdd") + "' and g_t<='" + Convert.ToDateTime(today).ToString("yyyyMMdd") + "'";
            baglanSinifi.dr = baglanSinifi.sorgu.ExecuteReader();
            while (baglanSinifi.dr.Read())
            {
                if (Convert.ToInt32(comboBox1.SelectedItem) == Convert.ToInt32(baglanSinifi.dr[0]))
                {
                    bir.Add(baglanSinifi.dr[1]);
                    for (int i = 0; i < bir.Count; i++)
                    {
                        toplam += Convert.ToInt32(bir[i]);
                    }
                    textBox1.Text = toplam + " TL";
                    bir.Clear();
                }
            }
            baglanSinifi.baglan.Close();
        }
        void uc_ay()
        {
            int toplam = 0;
            baglanSinifi.baglan.Open();
            baglanSinifi.sorgu.Connection = baglanSinifi.baglan;
            baglanSinifi.sorgu.CommandText = "SELECT o_no,ucret,g_t FROM cikis where g_t>='" + Convert.ToDateTime(Ucay).ToString("yyyyMMdd") + "' and g_t<='" + Convert.ToDateTime(today).ToString("yyyyMMdd") + "'";
            baglanSinifi.dr = baglanSinifi.sorgu.ExecuteReader();
            while (baglanSinifi.dr.Read())
            {
                if (Convert.ToInt32(comboBox1.SelectedItem) == Convert.ToInt32(baglanSinifi.dr[0]))
                {
                    uc.Add(baglanSinifi.dr[1]);
                    for (int i = 0; i < uc.Count; i++)
                    {
                        toplam += Convert.ToInt32(uc[i]);
                    }
                    textBox2.Text = toplam + " TL";
                    uc.Clear();
                }
            }
            baglanSinifi.baglan.Close();

        }
        void yil()
        {
            int toplam = 0;
            baglanSinifi.baglan.Open();
            baglanSinifi.sorgu.Connection = baglanSinifi.baglan;
            baglanSinifi.sorgu.CommandText = "SELECT o_no,ucret,g_t FROM cikis where g_t>='" + Convert.ToDateTime(yill).ToString("yyyyMMdd") + "' and g_t<='" + Convert.ToDateTime(today).ToString("yyyyMMdd") + "'";
            baglanSinifi.dr = baglanSinifi.sorgu.ExecuteReader();
            while (baglanSinifi.dr.Read())
            {
                if (Convert.ToInt32(comboBox1.SelectedItem) == Convert.ToInt32(baglanSinifi.dr[0]))
                {
                    bir_yil.Add(baglanSinifi.dr[1]);
                    for (int i = 0; i < bir_yil.Count; i++)
                    {
                        toplam += Convert.ToInt32(bir_yil[i]);
                    }
                    textBox3.Text = toplam + " TL";
                    bir_yil.Clear();
                }
            }
            baglanSinifi.baglan.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            musteri_konuk_tb frm = new musteri_konuk_tb();
            frm.label1.Visible = false;
            frm.label2.Visible = false;
            frm.label3.Visible = false;
            frm.dateTimePicker1.Visible = false;
            frm.dateTimePicker2.Visible = false;
            frm.button1.Visible = false;
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            musteri_konuk_tb frm = new musteri_konuk_tb();
            frm.groupBox1.Visible = false;
            frm.Size = new Size(781, 628);
            frm.groupBox2.Location = new Point(12, 12);
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            textBox1.Visible = true;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            groupBox1.Visible = true;
            groupBox1.Location = new Point(12, 12);
            this.Size = new Size(415, 310);
            no();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(comboBox1.SelectedItem + " Numaralı Odanın Gelir Bilgileri Yükleniyor", "Bilgi Mesajı");
            bir_ay();
            uc_ay();
            yil();

        }

        private void rapor_tb_FormClosed(object sender, FormClosedEventArgs e)
        {
            anasayfa_tb ana = new anasayfa_tb();
            ana.Show();
        }

        private void rapor_tb_Load(object sender, EventArgs e)
        {
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dataGridView1.Size = new Size(642,371);
            dataGridView1.Location = new Point(12,12);
            this.Size = new Size(675, 429);
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            DataView dt = new DataView();
            SqlDataAdapter verial = new SqlDataAdapter("select * from rezer", baglanSinifi.baglan);
            DataSet al = new DataSet();
            verial.Fill(al, "OTEL");
            dt.Table = al.Tables[0];
            dataGridView1.DataSource = dt;

            dataGridView1.Columns[0].HeaderText = "Oda Numarası".ToString();
            dataGridView1.Columns[1].HeaderText = "TC".ToString();
            dataGridView1.Columns[2].HeaderText = "Giriş Tarihi".ToString();
            dataGridView1.Columns[3].HeaderText = "Çıkış Tarihi".ToString();
            dataGridView1.Columns[4].HeaderText = "Kişi Sayısı".ToString();
            dataGridView1.Columns[5].HeaderText = "Oda Fiyatı".ToString();


        }
    }
}
