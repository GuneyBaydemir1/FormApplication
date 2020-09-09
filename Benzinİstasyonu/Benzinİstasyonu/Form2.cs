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
    public partial class Form2 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=GÜNEY\\SQLEXPRESS;Initial Catalog=benzinistasyonu;Integrated Security=True");
        SqlCommand komut = new SqlCommand();
        public Form2()
        {
            InitializeComponent();
        }
        private void txtsifredegistir_Click(object sender, EventArgs e)
        {
            if (txtkadi.Text=="" || txtsifredegistir.Text=="")
            {
                MessageBox.Show("Lütfen ilgili alanları dolduralım");
            }
            else
            {
                komut = new SqlCommand();
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "UPDATE girisbilgileri set kullaniciadi='" + txtkadi.Text + "',  sifre='" + txtysifre.Text + "' WHERE kullaniciadi='" + txtkadi.Text.ToString() + "'";
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Şifreniz Değiştirilmiştir Program Yeniden Başlatılıyor");
                Application.Restart();
            }  
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
