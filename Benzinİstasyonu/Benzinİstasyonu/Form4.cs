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
    public partial class Form4 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=GÜNEY\\SQLEXPRESS;Initial Catalog=benzinistasyonu;Integrated Security=True");
        SqlCommand komut = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        Form3 frm3 = new Form3();

        void goruntule()
        {
            baglanti.Open();
            da = new SqlDataAdapter("Select * from depo", baglanti);
            da.Fill(ds, "depo");
            dataGridView1.DataSource = ds.Tables["depo"];
            baglanti.Close();
        }
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
       
            goruntule();
        }
        private void anasayfa_Click(object sender, EventArgs e)
        {
            frm3.Show();
            this.Hide();
        }
        private void cikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Txtlitre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
            
        }
        private void Txtdepo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex==-1)
            {
                return;
            }
            txtad.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtlitre.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtdepo.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
        private void ekle_Click(object sender, EventArgs e)
        {
            if (txtad.Text == "" || txtlitre.Text == "" || txtdepo.Text == "")
            {
                MessageBox.Show("Lütfen İstenilen Alanları Boş Bırakmayalım!!!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                komut = new SqlCommand();
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "INSERT into depo (akaryakit_adi,litre_fiyati,depo)  VALUES ('" + txtad.Text + "' , '" + txtlitre.Text + "' , '" + txtdepo.Text + "')";
                komut.ExecuteNonQuery();
                baglanti.Close();
                ds.Tables["depo"].Clear();
                goruntule();
                MessageBox.Show("Kayıt İşlemi Tamamlandı");
                txtad.Text = "";
                txtdepo.Text = "";
                txtlitre.Text = "";
            }
        }

        private void guncelle_Click(object sender, EventArgs e)
        {
            if (txtad.Text == "" || txtlitre.Text == "" || txtdepo.Text == "")
            {
                MessageBox.Show("Lütfen Güncellenecek Alanı Seçin!!!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                komut = new SqlCommand();
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "UPDATE depo set akaryakit_adi='" + txtad.Text + "' , litre_fiyati='" + txtlitre.Text + "' , depo='" + txtdepo.Text + "'  WHERE akaryakit_adi='" + txtad.Text + "'";
                komut.ExecuteNonQuery();
                baglanti.Close();
                ds.Tables["depo"].Clear();
                goruntule();
                MessageBox.Show("Güncelleme İşlemi Tamamlandı");
                txtad.Text = "";
                txtdepo.Text = "";
                txtlitre.Text = "";
            }
        }

        private void sil_Click(object sender, EventArgs e)
        {
            if (txtad.Text == "" || txtlitre.Text == "" || txtdepo.Text == "")
            {
                MessageBox.Show("Lütfen Silinecek Alanı Seçin!!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                DialogResult sil;
                sil = MessageBox.Show("İlgili kaydı silmek istediğinizden emin misiniz?", "Kayıt Silme"
                , MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (sil == DialogResult.Yes)
                {

                    komut = new SqlCommand();
                    baglanti.Open();
                    komut.Connection = baglanti;
                    komut.CommandText = "DELETE from depo where akaryakit_adi='" + txtad.Text + "'";
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    ds.Tables["depo"].Clear();
                    goruntule();
                    MessageBox.Show("Silme İşlemi Tamamlandı");
                    txtad.Text = "";
                    txtdepo.Text = "";
                    txtlitre.Text = "";
                }
            }
        }

       
    }
}
