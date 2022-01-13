using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HospitalManagmentSystem
{
    public partial class Anasayfa : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=ASUS;Initial Catalog=HOSPITAL;User ID=sa;Password=burakkrky123");

        public Anasayfa()
        {
            InitializeComponent();
            baglanti.Open();
            string sorgu = "select dbo.personel_sayisi()";
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblPersonelSayisi.Text = dr.GetValue(0).ToString();
            }
            dr.Close();
            string sorgu2 = "select dbo.oda_sayisi()";
            SqlCommand komut2 = new SqlCommand(sorgu2, baglanti);
            dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                lblOdaSayisi.Text = dr.GetValue(0).ToString();
            }
            baglanti.Close();
        }

        private void pcExit_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
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

        private void lblResepsiyon_Click(object sender, EventArgs e)
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
            this.Close();
            Application.Exit();
        }
        private void lblPersonel_Click(object sender, EventArgs e)
        {
            Personel form = new Personel();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }
        private void lblDilek_Click(object sender, EventArgs e)
        {
            DilekSikayet form = new DilekSikayet();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void lblDuyurular_Click(object sender, EventArgs e)
        {
            Duyuru form = new Duyuru();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        
    }
}
