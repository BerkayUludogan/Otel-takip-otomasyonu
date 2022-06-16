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
    public partial class musteri_ekle : Form
    {
        baglanSinifi baglanSinifi;
        public musteri_ekle()
        {
            InitializeComponent();
            baglanSinifi = new baglanSinifi();
        }
        Button btn = new Button();
        static public int dolu, bos;
        string oda = odalar_tb.odano;
        ArrayList rez = new ArrayList();
        ArrayList rez_cks = new ArrayList();
        ArrayList kisi_list = new ArrayList();
        odalar_tb frm = new odalar_tb();
        string bir, iki;
        void reze()
        {
            try
            {
                baglanSinifi.baglan.Open();
                baglanSinifi.sorgu.Connection = baglanSinifi.baglan;
                baglanSinifi.sorgu.CommandText = "SELECT g_tarih,ayrilis_tarih FROM rezer";
                baglanSinifi.dr = baglanSinifi.sorgu.ExecuteReader();
                while (baglanSinifi.dr.Read())
                {
                    rez.Add(baglanSinifi.dr[0]);
                    rez_cks.Add(baglanSinifi.dr[1]);
                }
                for (int i = 0; i < rez.Count; i++)
                {
                    bir = rez[i].ToString();
                }
                for (int k = 0; k < rez_cks.Count; k++)
                {
                    iki = rez_cks[k].ToString();
                }
                baglanSinifi.baglan.Close();
            }
            catch (InvalidOperationException)
            {
                
            }
            
        }
        void kisi()
        {
            try
            {
                baglanSinifi.baglan.Open();
                baglanSinifi.sorgu.Connection = baglanSinifi.baglan;
                baglanSinifi.sorgu.CommandText = "Select tc from musteri_kayit";
                baglanSinifi.dr = baglanSinifi.sorgu.ExecuteReader();
                while (baglanSinifi.dr.Read())
                {
                    kisi_list.Add(baglanSinifi.dr[0]);
                }
                baglanSinifi.baglan.Close();
                for (int i = 0; i < kisi_list.Count; i++)
                {
                    kisi_list[i].ToString();
                }
            }
            catch (InvalidOperationException)
            {
            }
            
        }
        void temiz()
        {
            textBox1.Clear();
            textBox2.Clear();
            maskedTextBox1.Clear();
            textBox4.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reze();
            kisi();
            if (checkBox1.Checked == false && textBox1.Text == "" && textBox2.Text == "" && textBox4.Text == "")
            {
                MessageBox.Show("Bütün Alanları Doldurun", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (checkBox1.Checked == false)
            {
                try
                {
                    if (textBox1.Text != kisi_list.ToString() && textBox1.Text != "" && textBox2.Text != "" && textBox4.Text != "" )
                    {
                        baglanSinifi.baglan.Open();
                        baglanSinifi.sorgu.Connection = baglanSinifi.baglan;
                        baglanSinifi.sorgu.CommandText = "insert into musteri_kayit(tc,ad_soyad,tel,adres,k_t) values('" + textBox1.Text + "','" + textBox2.Text + "','" + maskedTextBox1.Text + "','" + textBox4.Text + "','" + dateTimePicker2.Value.ToString("yyyyMMdd") + "')";
                        baglanSinifi.sorgu.ExecuteNonQuery();
                        MessageBox.Show("Kayıt Başarılı...");
                        baglanSinifi.baglan.Close();
                    }
                    if (!bir.Contains(dateTimePicker2.Text) && !iki.Contains(dateTimePicker6.Text))
                    {
                        baglanSinifi.baglan.Open();
                        baglanSinifi.sorgu.Connection = baglanSinifi.baglan;
                        baglanSinifi.sorgu.CommandText = "insert into oda_musteri(o_no,tc,g_t,c_t) values(" + oda + ",'" + textBox1.Text + "','" + dateTimePicker2.Value.ToString("yyyyMMdd") + "','" + dateTimePicker6.Value.ToString("yyyyMMdd") + "')";

                        baglanSinifi.sorgu.ExecuteNonQuery();
                        MessageBox.Show("Giriş İşlemi Gerçekleşti...");
                        baglanSinifi.baglan.Close();

                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Hatalı giriş yaptınız.");
                }
                catch(SqlException)
                {
                    MessageBox.Show("Girmekte olduğunu TC kimlik numarası zaten başka odaya girişi yapılmış.!!", "Uyarı!!");
                    textBox5.Clear();
                }
                catch(InvalidOperationException)
                {
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox4.Clear();
                    maskedTextBox1.Clear();
                }


            }
            else
            {
                try
                {
                    if (!bir.Contains(dateTimePicker1.Text) && !iki.Contains(dateTimePicker5.Text))
                    {
                        baglanSinifi.baglan.Open();
                        baglanSinifi.sorgu.Connection = baglanSinifi.baglan;
                        baglanSinifi.sorgu.CommandText = "insert into oda_musteri(o_no,tc,g_t,c_t) values(" + oda + ",'" + textBox5.Text + "','" + dateTimePicker2.Value.ToString("yyyyMMdd") + "','" + dateTimePicker5.Value.ToString("yyyyMMdd") + "')";
                        baglanSinifi.sorgu.ExecuteNonQuery();
                        MessageBox.Show("Giriş Başarıyla Gerçekleşmiştir.\nÇıkmak İçin Evet'e Basınız..", "Bilgi Mesajı");
                        baglanSinifi.baglan.Close();
                    }
                    else
                    {
                       
                       
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Girmekte olduğunu TC kimlik numarası zaten başka odaya girişi yapılmış.!!\nVeya Kayıtlı Değil!!", "Uyarı!!");
                    textBox5.Clear();
                }
                catch (InvalidOperationException)
                {
                    textBox5.Clear();
                }
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox1.MaxLength = 11;
            textBox5.MaxLength = 11;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                groupBox1.Visible = false;
                groupBox2.Enabled = true;
                groupBox2.Location = new Point(12, 42);
            }
            else
            {
                groupBox1.Visible = true;
                groupBox2.Enabled = false;
                groupBox2.Location = new Point(12, 265);
            }
        }

        private void musteri_ekle_FormClosed(object sender, FormClosedEventArgs e)
        {
            odalar_tb frm = new odalar_tb();
            frm.Show();
        }

        private void musteri_ekle_Load(object sender, EventArgs e)
        {
            label1.Text = "Oda Numarası : "+odalar_tb.odano;
            dateTimePicker1.Value.Date.ToString();
            dateTimePicker2.Value.Date.ToString();
            dateTimePicker5.Value.Date.ToString();
            dateTimePicker6.Value.Date.ToString();
        }
    }
}
