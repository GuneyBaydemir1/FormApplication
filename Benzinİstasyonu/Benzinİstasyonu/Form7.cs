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
    public partial class Form7 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=GÜNEY\\SQLEXPRESS;Initial Catalog=benzinistasyonu;Integrated Security=True");
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        SqlDataReader dr;
        SqlCommand komut = new SqlCommand();
        void goruntule()
        {
            baglanti.Open();
            da = new SqlDataAdapter("Select * from personelbilgileri", baglanti);
            da.Fill(ds, "personelbilgileri");
            dataGridView1.DataSource = ds.Tables["personelbilgileri"];
            baglanti.Close();
        }
        bool durum;
        void aynikayitengelleme()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from personelbilgileri where tcno=@tcno", baglanti);
            komut.Parameters.AddWithValue("@tcno", tcno.Text);
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
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
           
            goruntule();

        }
      
        private void personelekle_Click(object sender, EventArgs e)
        {
            aynikayitengelleme();
            if (tcno.Text == "" || txtad.Text == "" || txtsoyad.Text == ""   || dogumtarihi.MaskCompleted == false || telefon.MaskCompleted == false || txtemail.Text == ""    || pozisyon.Text == "" || txtmaas.Text == "" || tarih.Text == "" || resim.Text == "")
            {
                MessageBox.Show("Lütfen İstenilen Alanları Boş Bırakmayalım!!!", "HATA"  , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (durum == true)
                {
                    komut = new SqlCommand();
                    baglanti.Open();
                    komut.Connection = baglanti;
                    komut.CommandText = "INSERT into personelbilgileri  (tcno,ad,soyad,dogumtarihi,cep_tel,eposta,pozisyon,maas,tarih,resim)  VALUES ('" + tcno.Text + "' , '" + txtad.Text + "' , '" + txtsoyad.Text + "'  , '" + dogumtarihi.Text + "' , '" + telefon.Text + "' , '" + txtemail.Text + "'    , '" + pozisyon.Text + "' , '" + txtmaas.Text + "' , '" + tarih.Text + "' , '" + resim.Text + "')";
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    ds.Tables["personelbilgileri"].Clear();
                    goruntule();
                    MessageBox.Show("Kayıt İşlemi Tamamlandı");
                    tcno.Text = "";
                    txtad.Text = "";
                    txtsoyad.Text = "";
                    dogumtarihi.Text = "";
                    telefon.Text = "";
                    txtemail.Text = "";
                    pozisyon.Text = "";
                    txtmaas.Text = "";
                    tarih.Text = "";
                    resim.Text = "";
                    pictureBox2.Image = null;
                }
                else
                {
                    MessageBox.Show("Bu TC Numara ile daha önce kayıt yapılmış!!!");
                }
            }
        }

        private void guncelle_Click(object sender, EventArgs e)
        {
            if (tcno.Text == "" || txtad.Text == "" || txtsoyad.Text == "" || dogumtarihi.MaskCompleted == false || telefon.MaskCompleted == false || txtemail.Text == "" || pozisyon.Text == "" || txtmaas.Text == "" || tarih.Text == "" || resim.Text == "")
            {
                MessageBox.Show("Lütfen Güncellenecek Alanı Seçin!!!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                komut = new SqlCommand();
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "UPDATE personelbilgileri set ad='" + txtad.Text + "' , soyad='" + txtsoyad.Text + "' , dogumtarihi='" + dogumtarihi.Text + "' , cep_tel='" + telefon.Text + "' , eposta='" + txtemail.Text + "' ,  pozisyon='" + pozisyon.Text + "' , maas='" + txtmaas.Text + "' , tarih='" + tarih.Text + "' , resim='" + resim.Text + "' WHERE tcno='" + tcno.Text + "'";
                komut.ExecuteNonQuery();
                baglanti.Close();
                ds.Tables["personelbilgileri"].Clear();
                goruntule();
                MessageBox.Show("Güncelleme İşlemi Tamamlandı");
                tcno.Text = "";
                txtad.Text = "";
                txtsoyad.Text = "";
                dogumtarihi.Text = "";
                telefon.Text = "";
                txtemail.Text = "";
                pozisyon.Text = "";
                txtmaas.Text = "";
                tarih.Text = "";
                resim.Text = "";
                pictureBox2.Image = null;

            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex==-1)
            {
                return;
            }
            tcno.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            dogumtarihi.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            telefon.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtemail.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            pozisyon.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtmaas.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            tarih.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            resim.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            pictureBox2.ImageLocation= dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
        }
       
        private void sil_Click(object sender, EventArgs e)
        {
            if (tcno.Text == "" || txtad.Text == "" || txtsoyad.Text == ""   || dogumtarihi.MaskCompleted == false || telefon.MaskCompleted == false || txtemail.Text == ""  || pozisyon.Text == "" || txtmaas.Text == "" || tarih.Text == "" || resim.Text == "")
            {
                MessageBox.Show("Lütfen Silinecek Alanı Seçin!!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult sil;
                sil = MessageBox.Show("İlgili kaydı silmek istediğinizden emin misiniz?", "Kayıt Silme", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (sil == DialogResult.Yes)
                {

                    komut = new SqlCommand();
                    baglanti.Open();
                    komut.Connection = baglanti;
                    komut.CommandText = "Delete From personelbilgileri where tcno='" + tcno.Text + "'";
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    ds.Tables["personelbilgileri"].Clear();
                    goruntule();
                    MessageBox.Show("Silme İşlemi Tamamlandı");
                    tcno.Text = "";
                    txtad.Text = "";
                    txtsoyad.Text = "";
                    dogumtarihi.Text = "";
                    telefon.Text = "";
                    txtemail.Text = "";
                    pozisyon.Text = "";
                    txtmaas.Text = "";
                    tarih.Text = "";
                    resim.Text = "";
                }
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

        private void tcno_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtmaas_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnresim_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox2.ImageLocation = openFileDialog1.FileName;
            resim.Text = openFileDialog1.FileName;
        }
    }

    }
        
   
