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
    public partial class Login : Form
    {

        SqlConnection baglanti = new SqlConnection("Data Source=ASUS;Initial Catalog=HOSPITAL;User ID=sa;Password=burakkrky123");

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select * from dbo.auth", baglanti);
            SqlDataReader dr = komut1.ExecuteReader();
            if (dr.Read())
            {
                if (textBox1.Text.Equals(dr["name"].ToString()) && textBox5.Text.Equals(dr["pass"].ToString()))
                {
                    Anasayfa form = new Anasayfa();
                    this.Hide();
                    form.ShowDialog();
                  
                }
                else
                {
                    textBox1.Text = "";
                    textBox5.Text = "";
                    MessageBox.Show("Yanlış şifre veya parola girdiniz !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            baglanti.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox5.Text = "";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
