using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HospitalManagmentSystem
{
    public partial class Hasta : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=ASUS;Initial Catalog=HOSPITAL;User ID=sa;Password=burakkrky123");

        public Hasta()
        {
            InitializeComponent();
            baglanti.Open();
            string sorgu = "select * from hasta";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            string sorgu2 = "select dbo.hasta_sayisi()";
            SqlCommand komut2 = new SqlCommand(sorgu2, baglanti);
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                lblHastaSayisi.Text = dr.GetValue(0).ToString();
            }
            baglanti.Close();
        }

        private void Hasta_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "select * from ilce";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbxİlce.DisplayMember = "ilce_adi";
            cbxİlce.ValueMember = "ilce_id";
            cbxİlce.DataSource = dt;

            baglanti.Close();
        }

        private void btnAddHasta_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("insert into hasta (ad,soyad,tc_no,ilce_id,telefon) values (UPPER(@p1),UPPER(@p2),@p3,@p4,@p5)", baglanti);
            komut1.Parameters.AddWithValue("@p1", tbxAd.Text);
            komut1.Parameters.AddWithValue("@p2", tbxSoyad.Text);
            komut1.Parameters.AddWithValue("@p3", Convert.ToInt64(tbxTC.Text));
            komut1.Parameters.AddWithValue("@p4", int.Parse(cbxİlce.SelectedValue.ToString()));
            komut1.Parameters.AddWithValue("@p5", tbxTelefon.Text);
            komut1.ExecuteNonQuery();
            string sorgu = "select * from hasta";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            string sorgu2 = "select dbo.hasta_sayisi()";
            SqlCommand komut2 = new SqlCommand(sorgu2, baglanti);
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                lblHastaSayisi.Text = dr.GetValue(0).ToString();
            }

            baglanti.Close();
        }

        private void btnDeleteHasta_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("delete from hasta where tc_no=@p1", baglanti);

            komut1.Parameters.AddWithValue("@p1", Convert.ToInt64(tbxTC.Text));
            komut1.ExecuteNonQuery();

            string sorgu = "select * from hasta";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            string sorgu2 = "select dbo.hasta_sayisi()";
            SqlCommand komut2 = new SqlCommand(sorgu2, baglanti);
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                lblHastaSayisi.Text = dr.GetValue(0).ToString();
            }

            baglanti.Close();
        }

        private void btnUpdateHasta_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("update hasta set ad=@p1,soyad=@p2,ilce_id=@p4,telefon=@p5 where tc_no=@p3", baglanti);
            komut1.Parameters.AddWithValue("@p1", tbxAd.Text);
            komut1.Parameters.AddWithValue("@p2", tbxSoyad.Text);
            komut1.Parameters.AddWithValue("@p3", Convert.ToInt64(tbxTC.Text));
            komut1.Parameters.AddWithValue("@p4", int.Parse(cbxİlce.SelectedValue.ToString()));
            komut1.Parameters.AddWithValue("@p5", tbxTelefon.Text);
            komut1.ExecuteNonQuery();
            string sorgu = "select * from hasta";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            string sorgu2 = "select dbo.hasta_sayisi()";
            SqlCommand komut2 = new SqlCommand(sorgu2, baglanti);
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                lblHastaSayisi.Text = dr.GetValue(0).ToString();
            }

            baglanti.Close();
        }

        private void btnFindHasta_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from hasta where tc_no = @p1", baglanti);
            da.SelectCommand.Parameters.AddWithValue("@p1", Convert.ToInt64(tbxTC.Text));
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            baglanti.Close();
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

        private void lblOdaDurumu_Click(object sender, EventArgs e)
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
