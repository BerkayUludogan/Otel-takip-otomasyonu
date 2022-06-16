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
using System.Collections;
namespace Otel_Takip
{
    public partial class rez_tb : Form
    {
        baglanSinifi baglanSinifi;
        public rez_tb()
        {
            InitializeComponent();
            baglanSinifi = new baglanSinifi();
        }
        ArrayList tarih = new ArrayList();
        ArrayList odda = new ArrayList();
        ArrayList fiyat = new ArrayList();
        string datee;

        void grid1()
        {

            OleDbDataAdapter verial = new OleDbDataAdapter("select * from oda_list", baglanSinifi.baglan2);
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
        void veriOku() // Sql veritabanındaki Kat sayısı, Yatak sayısı, Geniş yatak sayısını çekmeye yarıyor
        {
            baglanSinifi.baglan.Open();
            baglanSinifi.sorgu.Connection = baglanSinifi.baglan;
            baglanSinifi.sorgu.CommandText = "SELECT o_yatak,o_genis_yatak FROM oda_kat ";
            baglanSinifi.dr = baglanSinifi.sorgu.ExecuteReader();

            while (baglanSinifi.dr.Read())
            {
                comboBox1.Items.Add(baglanSinifi.dr["o_yatak"]);
                comboBox2.Items.Add(baglanSinifi.dr["o_genis_yatak"]);

            }
            baglanSinifi.baglan.Close();
        }
        void tarihler()
        {
            baglanSinifi.baglan.Open();
            baglanSinifi.sorgu.Connection = baglanSinifi.baglan;
            baglanSinifi.sorgu.CommandText = "SELECT oda_no,g_tarih FROM rezer where oda_no='"+textBox4.Text+"' ";
            baglanSinifi.dr = baglanSinifi.sorgu.ExecuteReader();
            while (baglanSinifi.dr.Read())
            {
                tarih.Add(baglanSinifi.dr[1]);
                odda.Add(baglanSinifi.dr[0]);
                for (int i = 0; i < tarih.Count; i++)
                {
                    datee = tarih[i]+"";
                }
            }
            baglanSinifi.baglan.Close();
        }
        void kayit()
        {
            baglanSinifi.baglan.Open();
            baglanSinifi.sorgu.Connection = baglanSinifi.baglan;
            baglanSinifi.sorgu.CommandText = "insert into rezer(oda_no,tc,g_tarih,ayrilis_tarih,k_sayisi,oda_fiyat) values(" + Convert.ToInt32(textBox4.Text) + ",'"+textBox3.Text+"','" + dateTimePicker1.Value.ToString("yyyyMMdd") + "','" + dateTimePicker2.Value.ToString("yyyyMMdd") + "','" + Convert.ToInt32(textBox1.Text) + "'," + textBox2.Text + ")";
            baglanSinifi.sorgu.ExecuteNonQuery();
            baglanSinifi.baglan.Close();
            MessageBox.Show("Kayıt Başarılı");
            DialogResult result = MessageBox.Show("Ana Menüye Dönmek İçin Evet'e Basınız..", "", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                anasayfa_tb frm = new anasayfa_tb();
                this.Close();
                frm.Show();
            }
            else if (result == DialogResult.No)
            {
                //code for No
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tarihler();
            try
            {
                if (!datee.Contains(dateTimePicker1.Text) && !odda.Contains(textBox4.Text))
                {
                    kayit();
                }
                else
                {
                    MessageBox.Show("Bu Tarihler Arası Başka Rezervasyon Bulunmaktadır.");
                }
            }
            catch (NullReferenceException)
            {
                kayit();
            }
           
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter bul = new OleDbDataAdapter(@"Select * From oda_list where O_SUIT=@O_SUIT", baglanSinifi.baglan2);
            bul.SelectCommand.Parameters.AddWithValue("@O_SUIT", checkBox1.Checked);
            bul.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter bul2 = new OleDbDataAdapter(@"Select * From oda_list where O_KLIMA=@O_KLIMA", baglanSinifi.baglan2);
            bul2.SelectCommand.Parameters.AddWithValue("@O_KLIMA", checkBox2.Checked);
            bul2.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter bul3 = new OleDbDataAdapter(@"Select * From oda_list where O_TELEVIZYON=@O_TELEVIZYON", baglanSinifi.baglan2);
            bul3.SelectCommand.Parameters.AddWithValue("@O_TELEVIZYON", checkBox3.Checked);
            bul3.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter bul5 = new OleDbDataAdapter(@"Select * From oda_list where O_KAPALI=@O_KAPALI", baglanSinifi.baglan2);
            bul5.SelectCommand.Parameters.AddWithValue("@O_KAPALI", checkBox4.Checked);
            bul5.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter bul = new OleDbDataAdapter("Select * From oda_list where O_YATAK_SAYISI=@O_YATAK_SAYISI", baglanSinifi.baglan2);
            bul.SelectCommand.Parameters.AddWithValue("@O_YATAK_SAYISI", comboBox1.Text);
            bul.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter bul = new OleDbDataAdapter("Select * From oda_list where O_GENIS_YATAK=@O_GENIS_YATAK", baglanSinifi.baglan2);
            bul.SelectCommand.Parameters.AddWithValue("@O_GENIS_YATAK", comboBox2.Text);
            bul.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void rez_tb_FormClosed(object sender, FormClosedEventArgs e)
        {
            //anasayfa_tb ana = new anasayfa_tb();
            //ana.Show();
        }

        private void rez_tb_Load(object sender, EventArgs e)
        {
            tarihler();
            grid1();
            veriOku();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            tarihler();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString(); 
            }
            catch (Exception) { }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.MaxLength = 11;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}

