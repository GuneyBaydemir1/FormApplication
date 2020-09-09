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
    public partial class Form6 : Form
    {

        SqlConnection baglanti = new SqlConnection("Data Source=GÜNEY\\SQLEXPRESS;Initial Catalog=benzinistasyonu;Integrated Security=True");
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        SqlDataReader dr;
        SqlCommand komut = new SqlCommand();
        SqlCommand cmd = new SqlCommand();

        void goruntule()
        {
            baglanti.Open();
            da = new SqlDataAdapter("Select * from musteri", baglanti);
            da.Fill(ds, "musteri");
            dataGridView1.DataSource = ds.Tables["musteri"];
            baglanti.Close();
        }

        public Form6()
        {
            InitializeComponent();
        }

        bool durum;
        void aynikayitengelleme()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from musteri where plaka=@plaka", baglanti);
            komut.Parameters.AddWithValue("@plaka", txtplaka.Text);
            dr = komut.ExecuteReader();
            if (dr.Read())
            {
                durum = false;
            }
            else
            {
                durum = true;
            }
            baglanti.Close();
        }
        private void Form6_Load(object sender, EventArgs e)
        {
          
            goruntule();      
            cmd.CommandText = "Select * from abonelik";
            cmd.Connection = baglanti;
            baglanti.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                uyelik.Items.Add(dr["abonelik_durumu"]);

            }
            baglanti.Close();
        }

        private void musteriekle_Click(object sender, EventArgs e)
        {
            aynikayitengelleme();
            if (txtad.Text == "" || txtsoyad.Text == "" || dogumtarihi.MaskCompleted == false   || telefon.MaskCompleted == false || txtemail.Text == "" || uyelik.Text == ""  || txtplaka.Text == "" || tarih.MaskCompleted == false)
            {
                MessageBox.Show("Lütfen İstenilen Alanları Boş Bırakmayalım!!!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (durum == true)
                {
                    komut = new SqlCommand();
                    baglanti.Open();
                    komut.Connection = baglanti;
                    komut.CommandText = "INSERT into musteri (ad,soyad,dogum_tarihi,cep_tel,email,uyelik_durumu,plaka,tarih)    VALUES ('" + txtad.Text + "' , '" + txtsoyad.Text + "' , '" + dogumtarihi.Text + "' , '" + telefon.Text + "'   , '" + txtemail.Text + "' ,  '" + uyelik.Text + "' , '" + txtplaka.Text + "' ,   '" + tarih.Text + "')";
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    ds.Tables["musteri"].Clear();
                    goruntule();
                    MessageBox.Show("Kayıt İşlemi Tamamlandı");
                    txtad.Text = "";
                    txtsoyad.Text = "";
                    dogumtarihi.Text = "";
                    telefon.Text = "";
                    txtemail.Text = "";
                    uyelik.Text = "";
                    txtplaka.Text = "";
                    tarih.Text = "";
                }
                else
                {
                    MessageBox.Show("Bu Plaka ile kayıt mevcut!!!");
                }  
            }
        }
        private void Guncelle_Click(object sender, EventArgs e)
        {
            if (txtad.Text == "" || txtsoyad.Text == "" || dogumtarihi.MaskCompleted == false   || telefon.MaskCompleted == false || txtemail.Text == "" || uyelik.Text == "" || txtplaka.Text == ""    || tarih.MaskCompleted == false)
            {
                MessageBox.Show("Lütfen Güncellenecek Alanı Seçin!!!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                komut = new SqlCommand();
                baglanti.Open();
                komut.Connection = baglanti;    
                komut.CommandText = "UPDATE musteri set ad='" + txtad.Text + "' " +   ", soyad='" + txtsoyad.Text + "' , dogum_tarihi='" + dogumtarihi.Text + "'" +   " , cep_tel='" + telefon.Text + "'  , email='" + txtemail.Text + "'  , uyelik_durumu='" + uyelik.Text + "' ,   plaka='" + txtplaka.Text + "'  , tarih='" + tarih.Text + "'  WHERE  plaka='" + txtplaka.Text + "'";
                komut.ExecuteNonQuery();
                baglanti.Close();
                ds.Tables["musteri"].Clear();
                goruntule();
                MessageBox.Show("Güncelleme İşlemi Tamamlandı");
                txtad.Text = "";
                txtsoyad.Text = "";
                dogumtarihi.Text = "";
                telefon.Text = "";
                txtemail.Text = "";
                uyelik.Text = "";
                txtplaka.Text = "";
                tarih.Text = "";
            }
        }
        private void anasayfa_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
            this.Hide();
        }
        private void cikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void sil_Click(object sender, EventArgs e)
        {
            
            if (txtad.Text=="" || txtsoyad.Text== "" || dogumtarihi.Text==""   || telefon.Text=="" || txtemail.Text=="" || uyelik.Text=="" || txtplaka.Text=="" || tarih.Text=="")
            {
                MessageBox.Show("Lütfen Silinecek Alanı Seçin!!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult sil;
                sil = MessageBox.Show("İlgili kaydı silmek istediğinizden emin misiniz?", "Kayıt Silme"  , MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (sil==DialogResult.Yes)
                {

                    komut = new SqlCommand();
                    baglanti.Open();
                    komut.Connection = baglanti;
                    komut.CommandText = "Delete From musteri where plaka='" + txtplaka.Text + "'";
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    ds.Tables["musteri"].Clear();
                    goruntule();
                    MessageBox.Show("Silme İşlemi Tamamlandı");
                    txtad.Text = "";
                    txtsoyad.Text = "";
                    dogumtarihi.Text = "";
                    telefon.Text = "";
                    txtemail.Text = "";
                    uyelik.Text = "";
                    txtplaka.Text = "";
                    tarih.Text = "";
                }                             
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            txtad.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            dogumtarihi.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            telefon.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtemail.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            uyelik.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtplaka.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            tarih.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
        }      
    }
}
