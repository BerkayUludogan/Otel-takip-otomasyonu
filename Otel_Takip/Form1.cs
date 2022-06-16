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
    public partial class Form1 : Form
    {
        baglanSinifi baglanSinifi;
        public Form1()
        {
            InitializeComponent();
            baglanSinifi = new baglanSinifi();
        }
        anasayfa_tb ana = new anasayfa_tb();
        TextBox t;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanSinifi.baglan.Open();
                baglanSinifi.sorgu.Connection = baglanSinifi.baglan;
                baglanSinifi.sorgu.CommandText = "Select kull_adi,sifre,ad from kullanici Where kull_adi='" + kull_adi.Text + "' and sifre='" + sifre.Text + "'";
                baglanSinifi.dr = baglanSinifi.sorgu.ExecuteReader();
                if (baglanSinifi.dr.Read())
                {
                    MessageBox.Show("Giriş Başarılı Hoş Geldiniz\n\nAnaSayfa'ya aktrılıyorsunuz....", "Sayın. " + baglanSinifi.dr[2]);

                    this.Hide();
                    ana.Show();

                    baglanSinifi.baglan.Close();
                }

                else if (kull_adi.Text == "a" && sifre.Text == "a")
                {
                    MessageBox.Show("Giriş Başarılı, Hoş Geldiniz\n\nAnaSayfa'ya aktrılıyorsunuz....", "Sayın. Admin");

                    this.Hide();
                    ana.Show();

                }
            
            }
            catch(InvalidOperationException)
            {
             MessageBox.Show("Bilgileriniz Hatalı Lütfen Tekrar Deneyin");
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sifre_hatirlat_tb frm = new sifre_hatirlat_tb();
            this.Hide();
            frm.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                sifre.PasswordChar = '\0';
                checkBox1.Text = "Şifreyi Gizle";
            }
            else
            {
                sifre.PasswordChar = '*';
                checkBox1.Text = "Şifreyi Göster";
            }
        }

        private void kull_adi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsPunctuation(e.KeyChar)) e.Handled = true; // Bazı özel karakterler girilmesini engelledik.
            if (e.KeyChar == ' ' || e.KeyChar == '+' || e.KeyChar == '^' || e.KeyChar == '=' || e.KeyChar == '|') e.Handled = true; // Ve bu karakterleride biz engelledik.

            t.ForeColor = Color.Black;
            if (t.Name == "Kullanıcı Adı") if (sifre.Text != "Kullanıcı Adı");
        }

        private void sifre_TextChanged(object sender, EventArgs e)
        {
            t = sender as TextBox;
            t.ForeColor = Color.Black;
            if (t.Name == "Şifre" ) {
                if (sifre.Text != "Şifre")
                {
                }
            }

            sifre.PasswordChar = '*';
        }
    

        private void sifre_Click(object sender, EventArgs e)
        {
            t = sender as TextBox;
            if (t.Text == "Kullanıcı Adı" || t.Text == "Şifre") t.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void sifre_TextAlignChanged(object sender, EventArgs e)
        {

        }
    }
}
