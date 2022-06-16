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
    public partial class m_ekle_tb : Form
    {
        baglanSinifi baglanSinifi;
        public m_ekle_tb()
        {
            InitializeComponent();
            baglanSinifi = new baglanSinifi();
        }
        void data()
        {

            SqlDataAdapter verial = new SqlDataAdapter("select tc,ad_soyad,tel,adres,k_t from musteri_kayit", baglanSinifi.baglan);
            DataSet al = new DataSet();
            verial.Fill(al, "OTEL");
            baglanSinifi.goster.Table = al.Tables[0];
            dataGridView1.DataSource = baglanSinifi.goster;
        }
        void data3()
        {

            SqlDataAdapter verial = new SqlDataAdapter("select tc,ad_soyad,tel,adres,k_t from musteri_kayit where ad_soyad LIKE '%" + textBox5.Text.Trim() + "%'", baglanSinifi.baglan);
            DataSet al = new DataSet();
            verial.Fill(al, "OTEL");
            baglanSinifi.goster.Table = al.Tables[0];
            dataGridView1.DataSource = baglanSinifi.goster;
        }
        void data2()
        {
            try
            {
                SqlDataAdapter verial = new SqlDataAdapter("select tc,ad_soyad,tel,adres,k_t from musteri_kayit where k_t>='" + Convert.ToDateTime(dateTimePicker1.Text).ToString("yyyyMMdd") + "' and k_t<='" + Convert.ToDateTime(dateTimePicker2.Text).ToString("yyyyMMdd") + "' ", baglanSinifi.baglan);
                DataSet al = new DataSet();
                verial.Fill(al, "OTEL");
                baglanSinifi.goster.Table = al.Tables[0];
                dataGridView1.DataSource = baglanSinifi.goster;

            }
            catch (SqlException)
            {
                MessageBox.Show("Aradığınız tarih içerisinde kayıt olan müşteri bulunamamıştır.");
            }

        }
        void dataisim() //Sql sorgudaki isimleri değiştirip ekrana yansıtır
        {
            dataGridView1.Columns[0].HeaderText = "T.C";
            dataGridView1.Columns[1].HeaderText = "Ad Soyad";
            dataGridView1.Columns[2].HeaderText = "Cep Telefonu";
            dataGridView1.Columns[3].HeaderText = "Adres";
            dataGridView1.Columns[4].HeaderText = "Katılım Tarihi";


        }
        void yenile()
        {
            textBox1.Clear();
            textBox2.Clear();
            maskedTextBox1.Clear();
            textBox4.Clear();
            textBox5.Clear();
            dataGridView1.Refresh();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanSinifi.baglan.Open();
                baglanSinifi.sorgu.Connection = baglanSinifi.baglan;
                baglanSinifi.sorgu.CommandText = "insert into musteri_kayit(tc,ad_soyad,tel,adres,k_t) values('" + textBox1.Text + "','" + textBox2.Text + "','" + maskedTextBox1.Text + "','" + textBox4.Text + "','" + katılım.Value.ToString("yyyyMMdd") + "')";
                baglanSinifi.sorgu.ExecuteNonQuery();
                yenile();
                MessageBox.Show("Kayıt Başarılı...");
            }
            catch (FormatException)
            {
                MessageBox.Show("Hatalı giriş yaptınız.", "UYARI !!!");
            }
            catch (SqlException)
            {
                MessageBox.Show("T.C Kimlik zaten kayıtlı.", "UYARI !!!");
            }

            baglanSinifi.baglan.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                baglanSinifi.baglan.Open();
                baglanSinifi.sorgu.Connection = baglanSinifi.baglan;
                baglanSinifi.sorgu.CommandText = "UPDATE musteri_kayit SET tc='" + textBox1.Text + "',ad_soyad='" + textBox2.Text + "',tel='" + maskedTextBox1.Text + "',adres='" + textBox4.Text + "' Where k_t='" + katılım.Value.ToString("yyyyMMdd") + "'";
                baglanSinifi.sorgu.ExecuteNonQuery();
                yenile();
                MessageBox.Show("Güncelleme Başarılı.");
            }
            catch (Exception)
            {
                MessageBox.Show("Aynı oda ismi adı mevcut veya bu oda şuan eklenememektedir.\nLütfen daha sonra tekrar deneyiniz.", "Bir hatayla karşılaşıldı.");
            }
            baglanSinifi.baglan.Close();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                groupBox1.Visible = true;
                groupBox2.Location = new Point(12, 376);
            }
            else
            {
                groupBox1.Visible = false;
                groupBox2.Location = new Point(15, 233);
            }
        }

        private void m_ekle_tb_FormClosed(object sender, FormClosedEventArgs e)
        {
            anasayfa_tb ana = new anasayfa_tb();
            ana.Show();
        }

        private void m_ekle_tb_Load(object sender, EventArgs e)
        {
            data();
            dataisim();
            groupBox2.Location = new Point(15, 233);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                maskedTextBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                katılım.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            }
            catch (Exception) { }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            data3();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            textBox1.MaxLength = 11;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            data2();
        }
    }
}

