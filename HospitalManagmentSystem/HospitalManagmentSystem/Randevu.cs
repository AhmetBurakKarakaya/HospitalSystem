using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HospitalManagmentSystem
{
    public partial class Randevu : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=ASUS;Initial Catalog=HOSPITAL;User ID=sa;Password=burakkrky123");
        public Randevu()
        {
            InitializeComponent();
            baglanti.Open();
            string sorgu = "select randevu.hasta_tc, doktor.ad AS doktorAdi ,doktor.soyad AS doktorSoyadi , randevu.randevu_id as randevuID, randevu.tarih from randevu " +
            "inner join doktor on doktor.id=randevu.doktor_id";

            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void Randevu_Load(object sender, EventArgs e)
        {
            baglanti.Open();

            string sorgu = "select * from doktor";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dt.Columns.Add(
             "adsoyad",
             typeof(string),
             "ad + ' ' + soyad ");

            cbxDoktorAd.DisplayMember = "adsoyad";
            cbxDoktorAd.ValueMember = "id";
            cbxDoktorAd.DataSource = dt;

            baglanti.Close();
        }

        private void btnAddRandevu_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("insert into randevu (hasta_tc,doktor_id,tarih,randevu_id) values (@p1,@p2,@p3,@p4)", baglanti);
            komut1.Parameters.AddWithValue("@p1", Convert.ToInt64(tbxHastaTC.Text));
            komut1.Parameters.AddWithValue("@p2", int.Parse(cbxDoktorAd.SelectedValue.ToString()));
            komut1.Parameters.AddWithValue("@p3", DateTime.Parse(mtbx.Text));
            komut1.Parameters.AddWithValue("@p4", int.Parse(tbxRandevuId.Text));
            komut1.ExecuteNonQuery();

            string sorgu = "select randevu.hasta_tc, doktor.ad AS doktorAdi ,doktor.soyad AS doktorSoyadi , randevu.randevu_id as randevuID, randevu.tarih from randevu " +
             "inner join doktor on doktor.id=randevu.doktor_id";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void BtnDeleteRandevu_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("delete from randevu where randevu_id=@p1", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(tbxRandevuId.Text));
            komut1.ExecuteNonQuery();
            string sorgu = "select randevu.hasta_tc, doktor.ad AS doktorAdi ,doktor.soyad AS doktorSoyadi , randevu.randevu_id as randevuID, randevu.tarih from randevu " +
            "inner join doktor on doktor.id=randevu.doktor_id";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void btnUpdateRandevu_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("update randevu set hasta_tc=@p1,doktor_id=@p2,tarih=@p3 where randevu_id=@p4", baglanti);
            komut1.Parameters.AddWithValue("@p1", Convert.ToInt64(tbxHastaTC.Text));
            komut1.Parameters.AddWithValue("@p2", int.Parse(cbxDoktorAd.SelectedValue.ToString()));
            komut1.Parameters.AddWithValue("@p3", DateTime.Parse(mtbx.Text));
            komut1.Parameters.AddWithValue("@p4", int.Parse(tbxRandevuId.Text));
            komut1.ExecuteNonQuery();

            string sorgu = "select randevu.hasta_tc, doktor.ad AS doktorAdi ,doktor.soyad AS doktorSoyadi , randevu.randevu_id as randevuID, randevu.tarih from randevu " +
             "inner join doktor on doktor.id=randevu.doktor_id";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
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

        private void lblOdaDurumu_Click(object sender, EventArgs e)
        {
            Odalar form = new Odalar();
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
