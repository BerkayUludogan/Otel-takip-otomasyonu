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
namespace Otel_Takip
{
    public partial class odalar_tb : Form
    {
        baglanSinifi baglanSinifi;
        public odalar_tb()
        {
            InitializeComponent();
            baglanSinifi = new baglanSinifi();
        }

        ArrayList oda_no = new ArrayList();
        ArrayList rez_oda = new ArrayList();
        ArrayList rez_oda_say = new ArrayList();
        ArrayList temiz_oda = new ArrayList();
        DateTime dt;
        static public Button btn = new Button();
        static public int adet = 0;
        static public string odano, oda;
        int dolu_oda;
        void doluluk()
        {
            baglanSinifi.baglan.Open();
            baglanSinifi.sorgu.Connection = baglanSinifi.baglan;
            baglanSinifi.sorgu.CommandType = CommandType.Text;
            baglanSinifi.sorgu.CommandText = "SELECT COUNT(o_no) FROM oda_musteri";
            dolu_oda = (int)baglanSinifi.sorgu.ExecuteScalar();
            baglanSinifi.baglan.Close();
            label2.Text ="Dolu Odalar : "+dolu_oda;
        }
        void reze()
        {
            baglanSinifi.baglan.Open();
            baglanSinifi.sorgu.Connection = baglanSinifi.baglan;
            baglanSinifi.sorgu.CommandText = "SELECT tc FROM musteri_kayit";
            baglanSinifi.dr = baglanSinifi.sorgu.ExecuteReader();
            while (baglanSinifi.dr.Read())
            {
                rez_oda.Add(baglanSinifi.dr["tc"]);
            }
            baglanSinifi.dr.Close();
            baglanSinifi.baglan.Close();
        }
        void rezerr()
        {
            baglanSinifi.baglan.Open();
            baglanSinifi.sorgu.Connection = baglanSinifi.baglan;
            baglanSinifi.sorgu.CommandText = "SELECT oda_no FROM rezer where oda_no='"+odano+"'";
            baglanSinifi.dr = baglanSinifi.sorgu.ExecuteReader();
            while (baglanSinifi.dr.Read())
            {
                rez_oda_say.Add(baglanSinifi.dr[0]);
               
            }
            baglanSinifi.dr.Close();
            baglanSinifi.baglan.Close();
            if (rez_oda_say.Count == 0)
            {
                MessageBox.Show("Bu Odaya Ait Rezervasyon Bulunamamıştır...", "Bilgi Mesajı");
            }
            else if (rez_oda_say.Count != 0)
            {
                DialogResult result = MessageBox.Show("Bu Odaya " + rez_oda_say.Count + " Adet Rezervasyon Yapılmıştır...\nGörmek İçin Evet'e Basın", "Bilgi Mesajı!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    rez_bil_tb frm = new rez_bil_tb();
                    this.Hide();
                    frm.Show();
                }
            }

            rez_oda_say.Clear();


        }
        private void button1_Click(object sender, EventArgs e)
        {
            musteri_ekle frm = new musteri_ekle();
            this.Hide();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            oda_ozell_tb frm = new oda_ozell_tb();
            this.Hide();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanSinifi.baglan.Open();
            baglanSinifi.sorgu.Connection = baglanSinifi.baglan;
            baglanSinifi.sorgu.CommandText = "delete from temizlenecek_odalar where o_no=" + odano + "";
            baglanSinifi.sorgu.ExecuteNonQuery();
            baglanSinifi.baglan.Close();
            MessageBox.Show("Oda En Kısa Sürede Temizlenecek!!!");
            baglanSinifi.baglan.Close();
            this.Refresh();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            cikis_tb frm = new cikis_tb();
            this.Hide();
            frm.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            rezerr();
        }
        ToolTip Aciklama = new ToolTip();
        private void odalar_tb_Load(object sender, EventArgs e)
        {
            Aciklama.IsBalloon = true;
            Aciklama.SetToolTip(button1, "Müşteri Ekle");
            Aciklama.SetToolTip(button2, "Oda Özellikleri");
            Aciklama.SetToolTip(button3, "Temizle");
            Aciklama.SetToolTip(button4, "Müşteri Çıkışı Yap");
            Aciklama.SetToolTip(button5, "Oda Rezervasyon Durumu");
            reze();
            dt = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            baglanSinifi.baglan2.Open();
            baglanSinifi.sorgu2.Connection = baglanSinifi.baglan2;
            baglanSinifi.sorgu2.CommandText = "SELECT O_NO FROM oda_list";
            baglanSinifi.dr2 = baglanSinifi.sorgu2.ExecuteReader();
            while (baglanSinifi.dr2.Read())
            {
                oda_no.Add(baglanSinifi.dr2["O_NO"]);
            }
            baglanSinifi.dr2.Close();
            baglanSinifi.baglan2.Close();
            for (int i = 0; i < oda_no.Count; i++)
            {
                btn = new Button();
                btn.Name = oda_no[i].ToString();
                flowLayoutPanel1.Controls.Add(btn);
                btn.Click += Btn_Click;
                btn.Text = oda_no[i].ToString();
                btn.Size = new Size(130, 48);

                baglanSinifi.baglan.Open();
                baglanSinifi.sorgu.Connection = baglanSinifi.baglan;
                baglanSinifi.sorgu.CommandText = "SELECT * FROM oda_musteri";
                baglanSinifi.dr = baglanSinifi.sorgu.ExecuteReader();
                while (baglanSinifi.dr.Read())
                {
                    if (Convert.ToInt32(baglanSinifi.dr[0]) == Convert.ToInt32(btn.Name))
                    {
                        for (int j = 0; j < Convert.ToInt32(btn.Name); j++)
                        {
                            btn.Text = "Dolu - " + btn.Name;
                            btn.BackColor = System.Drawing.Color.Red;
                        }
                    }

                }
                baglanSinifi.baglan.Close();

                baglanSinifi.baglan.Open();
                baglanSinifi.sorgu.Connection = baglanSinifi.baglan;
                baglanSinifi.sorgu.CommandText = "SELECT * FROM rezer";
                baglanSinifi.dr = baglanSinifi.sorgu.ExecuteReader();
                while (baglanSinifi.dr.Read())
                {
                    if ((dt == Convert.ToDateTime(baglanSinifi.dr[2])) && (Convert.ToInt32(baglanSinifi.dr[0]) == Convert.ToInt32(btn.Name)))
                    {
                        for (int j = 0; j < Convert.ToInt32(btn.Name); j++)
                        {
                            btn.Text = "Dolu - " + btn.Name;
                            btn.BackColor = System.Drawing.Color.Red;
                        }
                    }
                }
                baglanSinifi.baglan.Close();

                baglanSinifi.baglan.Open();
                baglanSinifi.sorgu.Connection = baglanSinifi.baglan;
                baglanSinifi.sorgu.CommandText = "SELECT o_no FROM temizlenecek_odalar";
                baglanSinifi.dr = baglanSinifi.sorgu.ExecuteReader();
                while (baglanSinifi.dr.Read())
                {
                    temiz_oda.Add(baglanSinifi.dr["o_no"]);
                    for (int ii = 0; ii < temiz_oda.Count; ii++)
                    {
                        if (Convert.ToInt32(baglanSinifi.dr[0]) == Convert.ToInt32(btn.Name))
                        {
                            btn.Text = "Kirli - " + btn.Name;
                            btn.BackColor = System.Drawing.Color.DarkRed;
                        }
                    }
                }
                baglanSinifi.dr.Close();
                baglanSinifi.baglan.Close();
                doluluk();
                for (int ii = 0; ii <= oda_no.Count - dolu_oda; ii++)
                {
                    label1.Text = "Boş Odalar : " + ii;
                }
            }
        }

        private void odalar_tb_FormClosed(object sender, FormClosedEventArgs e)
        {
            anasayfa_tb frm = new anasayfa_tb();
            frm.Show();
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            
                Button btn = (Button)sender;
                label3.Text = "Seçilen Oda: " + btn.Name;
                odano = btn.Name;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button5.Enabled = true;
                if (btn.BackColor == Color.Red)
                {
                    button1.Enabled = false;
                    button4.Enabled = true;
                    button3.Enabled = false;
                }
                else if (btn.BackColor == Color.DarkRed)
                {
                    button1.Enabled = false;
                    button4.Enabled = false;
                }
                else
                {

                    button3.Enabled = false;
                    button4.Enabled = false;
                }
              
        }
    }
}
