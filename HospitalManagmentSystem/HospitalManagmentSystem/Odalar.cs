using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HospitalManagmentSystem
{
    public partial class Odalar : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=ASUS;Initial Catalog=HOSPITAL;User ID=sa;Password=burakkrky123");

        public Odalar()
        {
            InitializeComponent();
            baglanti.Open();
            string sorgu = "select * from bosOdalariListele()";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            string sorgu2 = "select * from doluOdalariListele()";
            SqlDataAdapter da2 = new SqlDataAdapter(sorgu2, baglanti);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            dataGridView2.DataSource = ds2.Tables[0];
            baglanti.Close();
        }

        private void Odalar_Load(object sender, EventArgs e)
        {
            cbxMD.Items.Add("Boş");
            cbxMD.Items.Add("Dolu");
        }

        private void btnAddOda_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("insert into oda (oda_no,oda_durumu) values (@p1,@p2)", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(tbxOdaNo.Text));
            komut1.Parameters.AddWithValue("@p2", cbxMD.SelectedItem.ToString());
            komut1.ExecuteNonQuery();
            string sorgu = "select * from bosOdalariListele()";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            string sorgu2 = "select * from doluOdalariListele()";
            SqlDataAdapter da2 = new SqlDataAdapter(sorgu2, baglanti);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            dataGridView2.DataSource = ds2.Tables[0];
            baglanti.Close();
        }

        private void btnDeleteOda_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("delete from oda where oda_no=@p1", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(tbxOdaNo.Text));
            komut1.ExecuteNonQuery();

            string sorgu = "select * from bosOdalariListele()";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            string sorgu2 = "select * from doluOdalariListele()";
            SqlDataAdapter da2 = new SqlDataAdapter(sorgu2, baglanti);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            dataGridView2.DataSource = ds2.Tables[0];
            baglanti.Close();
        }

        private void btnUpdateOda_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("update oda set oda_durumu=@p2 where oda_no=@p1", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(tbxOdaNo.Text));
            komut1.Parameters.AddWithValue("@p2", cbxMD.SelectedItem.ToString());
            komut1.ExecuteNonQuery();
            string sorgu = "select * from bosOdalariListele()";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            string sorgu2 = "select * from doluOdalariListele()";
            SqlDataAdapter da2 = new SqlDataAdapter(sorgu2, baglanti);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            dataGridView2.DataSource = ds2.Tables[0];
            baglanti.Close();
        }

        private void lblHasta_Click(object sender, EventArgs e)
        {
            Hasta form = new Hasta();
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

        private void lblHemsire_Click(object sender, EventArgs e)
        {
            Hemsire form = new Hemsire();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void lblResepsiyonist_Click(object sender, EventArgs e)
        {
            Resepsiyon form = new Resepsiyon();
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

        private void lblMuayene_Click(object sender, EventArgs e)
        {
            Muayene form = new Muayene();
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
