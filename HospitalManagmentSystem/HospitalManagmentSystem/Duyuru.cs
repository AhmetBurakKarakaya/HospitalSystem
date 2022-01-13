using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HospitalManagmentSystem
{
    public partial class Duyuru : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=ASUS;Initial Catalog=HOSPITAL;User ID=sa;Password=burakkrky123");

        public Duyuru()
        {
            InitializeComponent();
            string sorgu = "select * from duyurular ORDER BY id ASC";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void btnAddDuyuru_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kmt = new SqlCommand(@"duyuru_ekle", baglanti);
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("id", int.Parse(tbxDuyuruNo.Text));
            kmt.Parameters.AddWithValue("baslik", tbxBaslik.Text);
            kmt.Parameters.AddWithValue("aciklama", tbxAciklama.Text);
            kmt.ExecuteNonQuery();
            string sorgu = "select * from duyurular ORDER BY id ASC";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void btnDeleteDuyuru_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("delete from duyurular where id=@p1", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(tbxDuyuruNo.Text));
            komut1.ExecuteNonQuery();
            string sorgu = "select * from duyurular ORDER BY id ASC";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void btnUpdateDuyuru_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kmt3 = new SqlCommand("update duyurular set baslik=@p2,aciklama=@p3 where id=@p1", baglanti);
            kmt3.Parameters.AddWithValue("@p1", int.Parse(tbxDuyuruNo.Text));
            kmt3.Parameters.AddWithValue("@p2", tbxBaslik.Text);
            kmt3.Parameters.AddWithValue("@p3", tbxAciklama.Text);
            kmt3.ExecuteNonQuery();
            string sorgu = "select * from duyurular ORDER BY id ASC";
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
