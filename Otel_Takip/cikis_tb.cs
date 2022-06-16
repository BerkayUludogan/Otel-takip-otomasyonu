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
    public partial class cikis_tb : Form
    {
        baglanSinifi baglanSinifi;
        public cikis_tb()
        {
            InitializeComponent();
            baglanSinifi = new baglanSinifi();
        }
        int fiyat, gun, ucret;
        void veriOku()
        {
            baglanSinifi.baglan.Open();
            baglanSinifi.sorgu.Connection = baglanSinifi.baglan;
            baglanSinifi.sorgu.CommandText = "select * from oda_musteri where o_no='" + odalar_tb.odano + "'";
            baglanSinifi.dr = baglanSinifi.sorgu.ExecuteReader();
            if (baglanSinifi.dr.Read())
            {
                label1.Text = "Seçilen Oda : " + baglanSinifi.dr[0].ToString();
                textBox1.Text = baglanSinifi.dr[1].ToString();
                dateTimePicker1.Text = baglanSinifi.dr[2].ToString();
            }
            baglanSinifi.baglan.Close();
        }

        void ucretler()
        {
            baglanSinifi.baglan2.Open();
            baglanSinifi.sorgu2.Connection = baglanSinifi.baglan2;
            baglanSinifi.sorgu2.CommandText = "select O_FIYATI from oda_list where O_NO=" + odalar_tb.odano + "";
            baglanSinifi.dr2 = baglanSinifi.sorgu2.ExecuteReader();
            if (baglanSinifi.dr2.Read())
            {

                fiyat = Convert.ToInt32(baglanSinifi.dr2[0]);
                TimeSpan zaman = DateTime.Parse(dateTimePicker2.Text) - DateTime.Parse(dateTimePicker1.Text);
                gun = Convert.ToInt32(zaman.TotalDays);
                ucret = gun * fiyat;
                textBox2.Text = ucret.ToString();


            }

            baglanSinifi.baglan2.Close();
        }

        private void cikis_tb_Load(object sender, EventArgs e)
        {
            veriOku();
            ucretler();
            if (ucret.ToString() == "0")
            {
                textBox2.Text = fiyat + "";
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            textBox1.MaxLength = 11;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanSinifi.baglan.Open();
            baglanSinifi.sorgu.Connection = baglanSinifi.baglan;
            baglanSinifi.sorgu.CommandText = "delete from oda_musteri where o_no='" + odalar_tb.odano + "'";
            baglanSinifi.sorgu.ExecuteNonQuery();
            baglanSinifi.baglan.Close();
            baglanSinifi.baglan.Open();
            baglanSinifi.sorgu.Connection = baglanSinifi.baglan;
            baglanSinifi.sorgu.CommandText = "delete from rezer where oda_no='" + odalar_tb.odano + "'";
            baglanSinifi.sorgu.ExecuteNonQuery();
            baglanSinifi.baglan.Close();
            baglanSinifi.baglan.Open();
            baglanSinifi.sorgu.Connection = baglanSinifi.baglan;
            baglanSinifi.sorgu.CommandText = "insert into temizlenecek_odalar(o_no) values(" + odalar_tb.odano + ")";
            baglanSinifi.sorgu.ExecuteNonQuery();
            baglanSinifi.baglan.Close();
            baglanSinifi.baglan.Open();
            baglanSinifi.sorgu.Connection = baglanSinifi.baglan;
            baglanSinifi.sorgu.CommandText = "insert into cikis(o_no,tc,g_t,c_t,c_s,ucret) values(" + odalar_tb.odano + ",'" + textBox1.Text + "','" + dateTimePicker1.Value.ToString("yyyyMMdd") + "','" + dateTimePicker2.Value.ToString("yyyyMMdd") + "','" + dateTimePicker4.Value.ToString("HH:mm:ss") + "','" + textBox2.Text + "')";
            baglanSinifi.sorgu.ExecuteNonQuery();
            baglanSinifi.baglan.Close();
            MessageBox.Show("Çıkış Başarıyla Gerçekleşmiştir...", "Bilgi Mesajı");
            
           
        }

        private void cikis_tb_FormClosed(object sender, FormClosedEventArgs e)
        {
            odalar_tb frm = new odalar_tb();
            frm.Show();
        }
    }
}
