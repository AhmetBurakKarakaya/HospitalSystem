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

namespace HospitalManagmentSystem
{
    public partial class Resepsiyon : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source = ASUS; Initial Catalog = HOSPITAL;user ID=sa; password=burakkrky123; Integrated Security = True");


        public Resepsiyon()
        {
            InitializeComponent();
            baglanti.Open();
            string sorgu = "select * from vw_resepsiyon order by id asc";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void Resepsiyon_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "select * from cinsiyet";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbxCinsiyet.DisplayMember = "name";
            cbxCinsiyet.ValueMember = "id";
            cbxCinsiyet.DataSource = dt;

            baglanti.Close();
        }

        private void btnAddRes_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand(@"resepsiyon_ekle", baglanti);
            komut1.CommandType = CommandType.StoredProcedure;
            komut1.Parameters.AddWithValue("@id", int.Parse(tbxId.Text));
            komut1.Parameters.AddWithValue("@ad", tbxAd.Text);
            komut1.Parameters.AddWithValue("@soyad", tbxSoyad.Text);
            komut1.Parameters.AddWithValue("@adres", tbxAdres.Text);
            komut1.Parameters.AddWithValue("@cinsiyet", int.Parse(cbxCinsiyet.SelectedValue.ToString()));
            komut1.Parameters.AddWithValue("@telefon", tbxTelefon.Text);
            komut1.Parameters.AddWithValue("@maas", float.Parse(tbxMaas.Text));
            komut1.Parameters.AddWithValue("@pasaport", tbxPasaport.Text);
            komut1.Parameters.AddWithValue("@ehliyet", tbxEhliyet.Text);
            komut1.ExecuteNonQuery();
            string sorgu = "select * from vw_resepsiyon order by id asc";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void btnDeleteRes_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand(@"resepsiyon_sil", baglanti);
            komut1.CommandType = CommandType.StoredProcedure;
            komut1.Parameters.AddWithValue("@id", int.Parse(tbxId.Text));
            komut1.ExecuteNonQuery();
            string sorgu = "select * from vw_resepsiyon order by id asc";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void BtnUpdateRes_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(@"personel_güncelle", baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@id", int.Parse(tbxId.Text));
            komut.Parameters.AddWithValue("@ad", tbxAd.Text);
            komut.Parameters.AddWithValue("@soyad", tbxSoyad.Text);
            komut.Parameters.AddWithValue("@adres", tbxAdres.Text);
            komut.Parameters.AddWithValue("@cinsiyet", int.Parse(cbxCinsiyet.SelectedValue.ToString()));
            komut.Parameters.AddWithValue("@telefon", tbxTelefon.Text);
            komut.Parameters.AddWithValue("@maas", float.Parse(tbxMaas.Text));
            komut.Parameters.AddWithValue("@pasaport", tbxPasaport.Text);
            komut.Parameters.AddWithValue("@ehliyet", tbxEhliyet.Text);
            komut.ExecuteNonQuery();
            SqlCommand komut1 = new SqlCommand(@"resepsiyon_güncelle", baglanti);
            komut1.CommandType = CommandType.StoredProcedure;
            komut1.Parameters.AddWithValue("@id", int.Parse(tbxId.Text));
            komut1.Parameters.AddWithValue("@ad", tbxAd.Text);
            komut1.Parameters.AddWithValue("@soyad", tbxSoyad.Text);
            komut1.Parameters.AddWithValue("@adres", tbxAdres.Text);
            komut1.Parameters.AddWithValue("@cinsiyet", int.Parse(cbxCinsiyet.SelectedValue.ToString()));
            komut1.Parameters.AddWithValue("@telefon", tbxTelefon.Text);
            komut1.Parameters.AddWithValue("@maas", float.Parse(tbxMaas.Text));
            komut1.Parameters.AddWithValue("@pasaport", tbxPasaport.Text);
            komut1.Parameters.AddWithValue("@ehliyet", tbxEhliyet.Text);
            komut1.ExecuteNonQuery();
            string sorgu = "select * from vw_resepsiyon order by id asc";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void btnFindRes_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from personel where id = @p1", baglanti);
            da.SelectCommand.Parameters.AddWithValue("@p1", int.Parse(tbxId.Text));
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void lblHasta_Click(object sender, EventArgs e)
        {
            Hasta form = new Hasta();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void lblHemsire_Click(object sender, EventArgs e)
        {
            Hemsire form = new Hemsire();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }
        private void lblDoktor_Click(object sender, EventArgs e)
        {
            Doktor form = new Doktor();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }


        private void lblMuayene_Click(object sender, EventArgs e)
        {
            Muayene form = new Muayene();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void lblRandevu_Click(object sender, EventArgs e)
        {
            Randevu form = new Randevu();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void lblYatis_Click(object sender, EventArgs e)
        {
            Yatis form = new Yatis();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void lblOda_Click(object sender, EventArgs e)
        {
            Odalar form = new Odalar();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void lblRecete_Click(object sender, EventArgs e)
        {
            Recete form = new Recete();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void lblBrans_Click(object sender, EventArgs e)
        {
            Brans form = new Brans();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void lblLogOut_Click(object sender, EventArgs e)
        {
            Anasayfa form = new Anasayfa();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void pcExit_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
