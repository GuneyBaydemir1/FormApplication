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


namespace Benzinİstasyonu
{
    public partial class Form1 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=GÜNEY\\SQLEXPRESS;Initial Catalog=benzinistasyonu;Integrated Security=True");
        SqlCommand komut = new SqlCommand();
        SqlDataReader dr;

        Form2 frm2 = new Form2();
        Form3 frm3 = new Form3();

        public Form1()            
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm2.Show();
            this.Hide();
        }

        private void giris_Click(object sender, EventArgs e)
        {
            string kullaniciadi, sifre;
            kullaniciadi = txtkadi.Text;
            sifre = txtsifre.Text;
            komut = new SqlCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "Select * from girisbilgileri where kullaniciadi = '" + txtkadi.Text + "' and sifre = '" + txtsifre.Text + "'";
            dr = komut.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Giriş Başarılı", "Giriş", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                frm3.Show();
            }
            else
            {
                MessageBox.Show("Giriş Başarısız", "Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (txtkadi.Text == "")
            {
                errorProvider1.SetError(txtkadi, "Bu alan boş geçilemez");
            }
            else
            {
                errorProvider1.Clear();
            }
            if (txtsifre.Text == "")
            {
                errorProvider2.SetError(txtsifre, "Bu alan boş geçilemez");
            }
            else
            {
                errorProvider2.Clear();
            }
            baglanti.Close();
        }
        private void cikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
