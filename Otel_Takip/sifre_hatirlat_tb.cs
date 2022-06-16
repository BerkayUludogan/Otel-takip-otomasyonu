using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace Otel_Takip
{
    public partial class sifre_hatirlat_tb : Form
    {
        baglanSinifi baglanSinifi;
        public sifre_hatirlat_tb()
        {
            InitializeComponent();
            baglanSinifi = new baglanSinifi();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string gonderadi, gonderisoy, gondersifre, gondermail;
            baglanSinifi.baglan.Open();
            baglanSinifi.sorgu.Connection = baglanSinifi.baglan;
            baglanSinifi.sorgu.CommandText = "Select * from kullanici where email='" + textBox1.Text + "'";
            baglanSinifi.dr = baglanSinifi.sorgu.ExecuteReader();
            if (baglanSinifi.dr.Read())
            {
                gonderadi = baglanSinifi.dr["ad"].ToString();
                gonderisoy = baglanSinifi.dr["soyad"].ToString();
                gondersifre = baglanSinifi.dr["sifre"].ToString();
                gondermail = baglanSinifi.dr["email"].ToString();
                baglanSinifi.baglan.Close();
                MailMessage ePosta = new MailMessage();
                ePosta.From = new MailAddress("buludogan0@gmail.com");
                ePosta.To.Add(gondermail);
                ePosta.Subject = "Şifre Hatırlatma";
                ePosta.Body = "Sayın, " + gonderadi + " " + gonderisoy + "\nŞifreniz: " + gondersifre;
                SmtpClient smtp = new SmtpClient();
                smtp.Credentials = new System.Net.NetworkCredential("buludogan0@gmail.com", "cd21600b");
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                object userState = ePosta;
                try
                {
                    smtp.SendAsync(ePosta, (object)ePosta);
                }
                catch (SmtpException ex)
                {
                    MessageBox.Show(ex.Message, "Mail Gönderme Hatasi");
                }
                finally
                {
                    baglanSinifi.baglan.Close();
                    MessageBox.Show("Mail Başarıyla Gönderildi", "Bilgi");
                    this.Hide();
                    Form1 frm = new Form1();
                    frm.Show();
                }
            }
            else
            {
                MessageBox.Show("Böyle Bir E-Posta Yok..", "Uyarı");
            }

        }

        private void sifre_hatirlat_tb_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
        }

        private void sifre_hatirlat_tb_Load(object sender, EventArgs e)
        {
        }
    }
}
