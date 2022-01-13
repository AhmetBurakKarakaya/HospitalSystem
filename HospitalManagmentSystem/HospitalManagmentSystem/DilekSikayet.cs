using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HospitalManagmentSystem
{
    public partial class DilekSikayet : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=ASUS;Initial Catalog=HOSPITAL;User ID=sa;Password=burakkrky123");

        public DilekSikayet()
        {
            InitializeComponent();
            string sorgu = "select * from dilek_sikayet order by id asc";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }


        private void btnAddSikayet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("insert into dilek_sikayet (id,ad,soyad,baslik,aciklama) values (@p1,@p2,@p3,@p4,@p5)", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(tbxSikayetNo.Text));
            komut1.Parameters.AddWithValue("@p2", tbxAd.Text);
            komut1.Parameters.AddWithValue("@p3", tbxSoyad.Text);
            komut1.Parameters.AddWithValue("@p4", tbxBaslik.Text);
            komut1.Parameters.AddWithValue("@p5", tbxSikayet.Text);
            komut1.ExecuteNonQuery();
            string sorgu = "select * from dilek_sikayet order by id asc";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void btnDeleteSikayet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("delete from dilek_sikayet where id=@p1", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(tbxSikayetNo.Text));
            komut1.ExecuteNonQuery();
            string sorgu = "select * from dilek_sikayet order by id asc";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void btnUpdateSikayet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("update dilek_sikayet set ad=@p2,soyad=@p3,baslik=@p4,aciklama=@p5 where id=@p1", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(tbxSikayetNo.Text));
            komut1.Parameters.AddWithValue("@p2", tbxAd.Text);
            komut1.Parameters.AddWithValue("@p3", tbxSoyad.Text);
            komut1.Parameters.AddWithValue("@p4", tbxBaslik.Text);
            komut1.Parameters.AddWithValue("@p5", tbxSikayet.Text);
            komut1.ExecuteNonQuery();
            string sorgu = "select * from dilek_sikayet order by id asc";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void pcExit_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void lblLogOut_Click(object sender, EventArgs e)
        {
            Anasayfa form = new Anasayfa();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }
    }
}
