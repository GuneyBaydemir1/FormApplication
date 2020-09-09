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
    public partial class Form5 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=GÜNEY\\SQLEXPRESS;Initial Catalog=benzinistasyonu;Integrated Security=True");
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        SqlDataReader dr;
        SqlCommand komut = new SqlCommand();
        SqlCommand komut2 = new SqlCommand();
        SqlCommand cmd = new SqlCommand();
        public Form5()
        {
            InitializeComponent();
        }

        void goruntule()
        {
            baglanti.Open();
            da = new SqlDataAdapter("Select * from satis", baglanti);
            da.Fill(ds, "satis");
            dataGridView2.DataSource = ds.Tables["satis"];
            baglanti.Close();
            txtdepo.Enabled = false;
            litrefiyati.Visible = true;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            komut = new SqlCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM depo";
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                akaryakit.Items.Add(dr["akaryakit_adi"]);
            }
            baglanti.Close();
            goruntule();
            
        }
        private void akaryakit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection baglanti = new SqlConnection("Data Source=FUNDA\\SQLEXPRESS;Initial Catalog=benzinistasyonu;Integrated Security=True");
                komut = new SqlCommand("Select * from depo where akaryakit_adi='" + akaryakit.Text + "'", baglanti);
                baglanti.Open();
                dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    litrefiyati.Text = dr.GetValue(1).ToString();
                    txtdepo.Text = dr.GetValue(2).ToString();
                    try
                    {
                        if (txtabone.Text == "Aktif")
                        {
                            double satilanlitre, fiyatlitre, sonuc = 0;
                            satilanlitre = Convert.ToDouble(txtsatılanlitre.Text);
                            fiyatlitre = Convert.ToDouble(litrefiyati.Text);
                            sonuc = (fiyatlitre * satilanlitre) - (fiyatlitre * satilanlitre) / 10;
                            lbltoplamtutar.Text = Convert.ToString(sonuc);
                        }
                        else
                        {
                            double satilanlitre, fiyatlitre, sonuc = 0;
                            satilanlitre = Convert.ToDouble(txtsatılanlitre.Text);
                            fiyatlitre = Convert.ToDouble(litrefiyati.Text);
                            sonuc = fiyatlitre * satilanlitre;
                            lbltoplamtutar.Text = Convert.ToString(sonuc);
                        }
                    }
                    catch
                    {
                    }
                }
                if (txtdepo.Text == "1000")
                {
                    MessageBox.Show("Deponuz azaldı.Lütfen deponuzu güncelleyin");
                }
            }
            catch
            {
            }
        }
        private void satisekle_Click(object sender, EventArgs e)
        {
            if (txtadi.Text == "" || txtsoyadi.Text == ""   || txtplaka.Text == "" || txtabone.Text == "" || txtindirim.Text == "" || akaryakit.Text == ""   || txtsatılanlitre.Text == "" || txttarih.MaskCompleted == false)
            {
                MessageBox.Show("Lütfen İstenilen Alanları Boş Bırakmayalım!!!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int depodakalan, satilan, sonkalan = 0;
                depodakalan = int.Parse(txtdepo.Text);
                satilan = int.Parse(txtsatılanlitre.Text);
                if (depodakalan > satilan)
                {
                    baglanti.Open();
                    komut2 = new SqlCommand("INSERT into satis (ad,soyad,plaka,abonelik_durumu,indirim_orani,akaryakit,satilan_litre,toplam_tutar,tarih)   VALUES ('" + txtadi.Text + "' , '" + txtsoyadi.Text + "' , '" + txtplaka.Text + "'  , '" + txtabone.Text + "'   , '" + txtindirim.Text + "'   ,   '" + akaryakit.Text + "' , '" + txtsatılanlitre.Text + "' , '" + lbltoplamtutar.Text +  "', '" + txttarih.Text + "')", baglanti);
                    komut2.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Satış Ekleme Başarılı");
                    sonkalan = depodakalan - satilan;
                    baglanti.Open();
                    komut = new SqlCommand("UPDATE depo SET depo='" + sonkalan.ToString() + "' WHERE akaryakit_adi='" +
                    akaryakit.Text + "'", baglanti);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    ds.Tables["satis"].Clear();
                    goruntule();
                    txtadi.Text = "";
                    txtsoyadi.Text = "";
                    txtplaka.Text = "";
                    txtabone.Text = "";
                    txtindirim.Text = "";
                    akaryakit.Text = "";
                    txtsatılanlitre.Text = "";
                    lbltoplamtutar.Text = "";
                    txttarih.Text = "";
                }
            }
        }
        private void txtsatılanlitre_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtabone.Text == "Aktif")
                {
                    double satilanlitre, fiyatlitre, sonuc = 0;
                    satilanlitre = Convert.ToDouble(txtsatılanlitre.Text);
                    fiyatlitre = Convert.ToDouble(litrefiyati.Text);
                    sonuc = (fiyatlitre * satilanlitre) - (fiyatlitre * satilanlitre) / 10;
                    lbltoplamtutar.Text = Convert.ToString(sonuc);
                }
                else
                {
                    double satilanlitre, fiyatlitre, sonuc = 0;
                    satilanlitre = Convert.ToDouble(txtsatılanlitre.Text);
                    fiyatlitre = Convert.ToDouble(litrefiyati.Text);
                    sonuc = fiyatlitre * satilanlitre;
                    lbltoplamtutar.Text = Convert.ToString(sonuc);
                }
            }
            catch
            {
            } 
        }
        private void cikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void anasayfa_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
            this.Hide();
        }
        private void txtplaka_TextChanged(object sender, EventArgs e)
        {
            var plaka = txtplaka.Text;
            if (!String.IsNullOrEmpty(plaka))
            {
                cmd = new SqlCommand("Select * from musteri where plaka='" + txtplaka.Text + "' AND uyelik_durumu='aktif'", baglanti);
                baglanti.Open();
                SqlDataReader oku = cmd.ExecuteReader();
                if (oku.Read())
                {
                    txtadi.Text = oku.GetValue(0).ToString();
                    txtsoyadi.Text = oku.GetValue(1).ToString();
                    txtabone.Text = oku.GetValue(5).ToString();
                    txtindirim.Text = "%10";
                }
                else
                {
                    txtabone.Text = "Pasif";
                    txtindirim.Text = "0";

                }

                baglanti.Close();                                                                                                                       
            }
            else
            {
                txtabone.Text = "Pasif";
                txtindirim.Text = "0";
                txtadi.Text = "";
                txtsoyadi.Text = "";
                txtsatılanlitre.Text = "";
                txttarih.Text = "";
                lbltoplamtutar.Text = "";
                akaryakit.Text = "";
                litrefiyati.Text = "";
                txtdepo.Text = "";
                txtadi.Enabled = true;
                txtsoyadi.Enabled = true;
                akaryakit.Enabled = true;
                txtsatılanlitre.Enabled = true;
                txttarih.Enabled = true;
            }          
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)            
                return;

            txtadi.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtsoyadi.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtplaka.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtabone.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtindirim.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
            akaryakit.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtsatılanlitre.Text = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
            lbltoplamtutar.Text = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
            txttarih.Text = dataGridView2.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtadi.Enabled = true;
            txtsoyadi.Enabled = true;
            akaryakit.Enabled = true;
            txtsatılanlitre.Enabled = true;
            txttarih.Enabled = true;
        }

        private void guncelle_Click(object sender, EventArgs e)
        {
            if (txtadi.Text == "" || txtsoyadi.Text == ""     || txtplaka.Text == "" || txtabone.Text == "" || txtindirim.Text == "" || akaryakit.Text == ""   || txtsatılanlitre.Text == "" || txttarih.MaskCompleted == false)
            {
                MessageBox.Show("Lütfen Güncellenecek Alanı Seçin!!!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                komut2 = new SqlCommand();
                baglanti.Open();
                komut2.Connection = baglanti;
                komut2.CommandText = "UPDATE satis set ad='" + txtadi.Text + "' " +    ", soyad='" + txtsoyadi.Text + "'  , plaka='" + txtplaka.Text + "' , abonelik_durumu='" + txtabone.Text + "'   , indirim_orani='" + txtindirim.Text + "'  , akaryakit='" + akaryakit.Text + "' , satilan_litre='" + txtsatılanlitre.Text + "'  , toplam_tutar='" + lbltoplamtutar.Text + "'  , tarih='" + txttarih.Text + "'  WHERE plaka='" + txtplaka.Text + "'";
                komut2.ExecuteNonQuery();
                baglanti.Close();
                ds.Tables["satis"].Clear();
                goruntule();
                MessageBox.Show("Güncelleme İşlemi Tamamlandı");
                txtadi.Text = "";
                txtsoyadi.Text = "";
                txtplaka.Text = "";
                txtabone.Text = "";
                txtindirim.Text = "";
                akaryakit.Text = "";
                txtsatılanlitre.Text = "";
                lbltoplamtutar.Text = "";
                txttarih.Text = "";
            }
        }
        private void txtsatılanlitre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

      
    }

}
