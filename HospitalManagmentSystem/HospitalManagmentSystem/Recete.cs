using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HospitalManagmentSystem
{
    public partial class Recete : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=ASUS;Initial Catalog=HOSPITAL;User ID=sa;Password=burakkrky123");

        public Recete()
        {
            InitializeComponent();


            baglanti.Open();
            string sorgu = "select recete.hasta_tc, doktor.ad AS doktorAdi ,doktor.soyad AS doktorSoyadi , recete.id as receteID, recete_ilac.ilac_adi, ilac.kullanim_bilgi from recete " +
            "inner join recete_ilac ON recete.id=recete_ilac.recete_id " +
            "inner join ilac ON ilac.ilac_adi=recete_ilac.ilac_adi " +
            "inner join doktor on doktor.id=recete.doktor_id";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void Recete_Load(object sender, EventArgs e)
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

            cbxDoktorAdi.DisplayMember = "adsoyad";
            cbxDoktorAdi.ValueMember = "id";
            cbxDoktorAdi.DataSource = dt;

            baglanti.Close();
        }

        private void btnAddRecete_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("insert into recete (id,hasta_tc,doktor_id) values (@p1,@p2,@p5)", baglanti);
            SqlCommand komut2 = new SqlCommand("insert into recete_ilac (ilac_adi,recete_id) values (@p3,@p4)", baglanti);

            komut1.Parameters.AddWithValue("@p1", int.Parse(tbxReceteId.Text));
            komut2.Parameters.AddWithValue("@p4", int.Parse(tbxReceteId.Text));
            komut1.Parameters.AddWithValue("@p2", Convert.ToInt64(tbxHastaTC.Text));
            komut2.Parameters.AddWithValue("@p3", tbxIlacAdi.Text);
            komut1.Parameters.AddWithValue("@p5", int.Parse(cbxDoktorAdi.SelectedValue.ToString()));
            komut1.ExecuteNonQuery();
            komut2.ExecuteNonQuery();
            string sorgu = "select recete.hasta_tc, doktor.ad AS doktorAdi ,doktor.soyad AS doktorSoyadi , recete.id as receteID, recete_ilac.ilac_adi, ilac.kullanim_bilgi from recete " +
             "inner join recete_ilac ON recete.id=recete_ilac.recete_id " +
             "inner join ilac ON ilac.ilac_adi=recete_ilac.ilac_adi " +
             "inner join doktor on doktor.id=recete.doktor_id";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void btnDeleteRecete_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("delete from recete where id=@p1", baglanti);
            SqlCommand komut2 = new SqlCommand("delete from recete_ilac where recete_id=@p2", baglanti);

            komut1.Parameters.AddWithValue("@p1", int.Parse(tbxReceteId.Text));
            komut2.Parameters.AddWithValue("@p2", int.Parse(tbxReceteId.Text));
            komut1.ExecuteNonQuery();
            komut2.ExecuteNonQuery();
            string sorgu = "select recete.hasta_tc, doktor.ad AS doktorAdi ,doktor.soyad AS doktorSoyadi , recete.id as receteID, recete_ilac.ilac_adi, ilac.kullanim_bilgi from recete " +
             "inner join recete_ilac ON recete.id=recete_ilac.recete_id " +
             "inner join ilac ON ilac.ilac_adi=recete_ilac.ilac_adi " +
             "inner join doktor on doktor.id=recete.doktor_id";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void btnUpdateRecete_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("update recete set hasta_tc=@p2,doktor_id=@p5 where id=@p1", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(tbxReceteId.Text));
            komut1.Parameters.AddWithValue("@p2", Convert.ToInt64(tbxHastaTC.Text));
            komut1.Parameters.AddWithValue("@p5", int.Parse(cbxDoktorAdi.SelectedValue.ToString()));
            komut1.ExecuteNonQuery();
            string sorgu = "select recete.hasta_tc, doktor.ad AS doktorAdi ,doktor.soyad AS doktorSoyadi , recete.id as receteID, recete_ilac.ilac_adi, ilac.kullanim_bilgi from recete " +
             "inner join recete_ilac ON recete.id=recete_ilac.recete_id " +
             "inner join ilac ON ilac.ilac_adi=recete_ilac.ilac_adi " +
             "inner join doktor on doktor.id=recete.doktor_id";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void btnIlacEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("insert into recete_ilac (ilac_adi,recete_id) values (@p2,@p3)", baglanti);
            komut2.Parameters.AddWithValue("@p2", tbxIlacAdi.Text);
            komut2.Parameters.AddWithValue("@p3", int.Parse(tbxReceteId.Text));
            komut2.ExecuteNonQuery();
            string sorgu = "select recete.hasta_tc, doktor.ad AS doktorAdi ,doktor.soyad AS doktorSoyadi , recete.id as receteID, recete_ilac.ilac_adi, ilac.kullanim_bilgi from recete " +
            "inner join recete_ilac ON recete.id=recete_ilac.recete_id " +
            "inner join ilac ON ilac.ilac_adi=recete_ilac.ilac_adi " +
            "inner join doktor on doktor.id=recete.doktor_id";
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

        private void lblBrans_Click(object sender, EventArgs e)
        {
            Brans form = new Brans();
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
        private void lblRandevu_Click(object sender, EventArgs e)
        {
            Randevu form = new Randevu();
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
