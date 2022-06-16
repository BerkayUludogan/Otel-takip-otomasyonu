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
    public partial class oda_ayar_tb : Form
    {
        baglanSinifi baglanSinifi;
        public oda_ayar_tb()
        {
            InitializeComponent();
            baglanSinifi = new baglanSinifi();

        }
        void temiz()
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
            comboBox3.SelectedItem = null;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox5.Checked = false;
        }
        void veriOku() // Sql veritabanındaki Kat sayısı, Yatak sayısı, Geniş yatak sayısını çekmeye yarıyor
        {
            baglanSinifi.baglan.Open();
            baglanSinifi.sorgu.Connection = baglanSinifi.baglan;
            baglanSinifi.sorgu.CommandText = "SELECT * FROM oda_kat ";
            baglanSinifi.dr = baglanSinifi.sorgu.ExecuteReader();

            while (baglanSinifi.dr.Read())
            {
                comboBox1.Items.Add(baglanSinifi.dr["o_katlar"]);
                comboBox2.Items.Add(baglanSinifi.dr["o_yatak"]);
                comboBox3.Items.Add(baglanSinifi.dr["o_genis_yatak"]);

            }
            baglanSinifi.baglan.Close();
        }
        void data()
        {

            OleDbDataAdapter verial = new OleDbDataAdapter("select O_NO,O_KAT_NO,O_YATAK_SAYISI,O_GENIS_YATAK,O_SUIT,O_KLIMA,O_TELEVIZYON,O_KAPALI,O_FIYATI from oda_list", baglanSinifi.baglan2);
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
        private void oda_ayar_tb_Load(object sender, EventArgs e)
        {
            veriOku();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanSinifi.baglan2.Open();
                baglanSinifi.sorgu2.Connection = baglanSinifi.baglan2;
                baglanSinifi.sorgu2.CommandText = "insert into oda_list(O_NO,O_KAT_NO,O_YATAK_SAYISI,O_GENIS_YATAK,O_SUIT,O_KLIMA,O_TELEVIZYON,O_KAPALI,O_FIYATI) values(" + Convert.ToInt32(textBox1.Text) + ",'" + comboBox1.Text + "'," + Convert.ToInt32(comboBox2.Text) + "," + Convert.ToInt32(comboBox3.Text) + "," + checkBox1.Checked + "," + checkBox2.Checked + "," + checkBox3.Checked + "," + checkBox5.Checked + "," + Convert.ToInt32(textBox2.Text) + ")";
                baglanSinifi.sorgu2.ExecuteNonQuery();
                temiz();
                MessageBox.Show("Giriş Başarılı.");
            }
            catch (FormatException)
            {
                MessageBox.Show("Aynı oda ismi adı mevcut veya bu oda şuan eklenememektedir.\nLütfen daha sonra tekrar deneyiniz.", "Bir hatayla karşılaşıldı.");
            }
            baglanSinifi.baglan2.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                baglanSinifi.baglan2.Open();
                baglanSinifi.sorgu2.Connection = baglanSinifi.baglan2;
                baglanSinifi.sorgu2.CommandText = "UPDATE oda_list SET O_NO=" + textBox1.Text + ",O_KAT_NO='" + comboBox1.Text + "',O_YATAK_SAYISI=" + comboBox2.Text + ",O_GENIS_YATAK=" + comboBox3.Text + ",O_SUIT=" + checkBox1.Checked + ",O_KLIMA=" + checkBox2.Checked + ",O_TELEVIZYON=" + checkBox3.Checked + ",O_KAPALI=" + checkBox5.Checked + ",O_FIYATI=" + textBox2.Text + " Where O_NO=" + textBox1.Text + "";
                baglanSinifi.sorgu2.ExecuteNonQuery();
                MessageBox.Show("Güncelleme Başarılı.");

            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen daha sonra tekrar deneyiniz.", "Bir hatayla karşılaşıldı.");
            }
            baglanSinifi.baglan.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            data();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                comboBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                comboBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                checkBox1.Checked = Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[4].Value);
                checkBox2.Checked = Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[5].Value);
                checkBox3.Checked = Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[6].Value);
                checkBox5.Checked = Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[8].Value);
                textBox2.Text = dataGridView1.Rows[0].Cells[9].Value.ToString();
            }
            catch (Exception) { }

        }

        private void oda_ayar_tb_FormClosed(object sender, FormClosedEventArgs e)
        {
            anasayfa_tb ana = new anasayfa_tb();
            ana.Show();

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
    }
}
