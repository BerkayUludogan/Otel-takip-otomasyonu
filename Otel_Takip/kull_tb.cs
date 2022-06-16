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
using System.Text.RegularExpressions;
namespace Otel_Takip
{
    public partial class kull_tb : Form
    {
        baglanSinifi baglanSinifi;
        public kull_tb()
        {
            InitializeComponent();
            baglanSinifi = new baglanSinifi();
        }
        private const string MatchEmailPattern =
                  @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
           + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]? 
                                                [0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
           + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]? 
                                                [0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
           + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";
        void data()
        {

            SqlDataAdapter verial = new SqlDataAdapter("Select tc,kull_adi,sifre,ad,soyad,dgm_t,tel,email,adres from kullanici ", baglanSinifi.baglan);
            verial.Fill(baglanSinifi.al, "OTEL");
            baglanSinifi.goster.Table = baglanSinifi.al.Tables[0];
            dataGridView1.DataSource = baglanSinifi.goster;

            dataGridView1.Columns[0].HeaderText = "T.C";
            dataGridView1.Columns[1].HeaderText = "Kullanıcı Adı";
            dataGridView1.Columns[2].HeaderText = "Şifre";
            dataGridView1.Columns[3].HeaderText = "Ad";
            dataGridView1.Columns[4].HeaderText = "Soyad";
            dataGridView1.Columns[5].HeaderText = "Doğum Tarihi";
            dataGridView1.Columns[6].HeaderText = "Cep Telefonu";
            dataGridView1.Columns[7].HeaderText = "E-mail";
            dataGridView1.Columns[8].HeaderText = "Adres";
        }
        void temiz()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            maskedTextBox1.Clear();
            textBox8.Clear();
            textBox9.Clear();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            bool retVal = false;
            retVal = Regex.IsMatch(textBox8.Text, MatchEmailPattern);
            if (retVal)
            {
               
            }
            else
            {
                MessageBox.Show("Lütfen Geçerli Bir E-Posta Adresi Girin..");
            }
            if (textBox3.Text == textBox4.Text )
            {
                if (textBox1.Text == " " && textBox2.Text == " " && textBox3.Text == " " && textBox5.Text == " " && textBox6.Text == " " && textBox9.Text == " " && textBox9.Text == " ")
                {
                  
                        baglanSinifi.baglan.Open();
                        baglanSinifi.sorgu.Connection = baglanSinifi.baglan;
                        baglanSinifi.sorgu.CommandText = "insert into kullanici(tc,kull_adi,sifre,ad,soyad,dgm_t,tel,email,adres) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + dateTimePicker1.Value.ToString("dd.MM.yyyy") + "','" + maskedTextBox1.Text + "','" + textBox8.Text + "','" + textBox9.Text + "')";
                        baglanSinifi.sorgu.ExecuteNonQuery();
                        MessageBox.Show("Kayıt Başarılı.");
                        baglanSinifi.baglan.Close();
                }
                else
                {
                    MessageBox.Show("Boş Alan Bırakmayınız....");
                }
               
            }
            else
            {
                MessageBox.Show("Şifreler Eşleşmiyor....");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                baglanSinifi.baglan.Open();
                baglanSinifi.sorgu.Connection = baglanSinifi.baglan;
                baglanSinifi.sorgu.CommandText = "UPDATE kullanici SET tc='" + textBox1.Text + "',kull_adi='" + textBox2.Text + "',sifre='" + textBox3.Text + "',ad='" + textBox5.Text + "',soyad='" + textBox6.Text + "',dgm_t='" + dateTimePicker1.Value.ToString("dd.MM.yyyy") + "',tel='" + maskedTextBox1.Text + "',email='" + textBox8.Text + "',adres='" + textBox9.Text + "' Where tc='" + textBox1.Text + "'";
                baglanSinifi.sorgu.ExecuteNonQuery();
                temiz();
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
            dataGridView1.Refresh();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox6.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                maskedTextBox1.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                textBox8.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                textBox9.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            }
            catch (Exception) { }
        }

        private void kull_tb_Load(object sender, EventArgs e)
        {
            baglanSinifi.al.Clear();
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void kull_tb_FormClosed(object sender, FormClosedEventArgs e)
        {
            anasayfa_tb ana = new anasayfa_tb();
            ana.Show();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            textBox1.MaxLength = 11;
        }
    }
}
