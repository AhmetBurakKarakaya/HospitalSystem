using System;
using System.Windows.Forms;

namespace HospitalManagmentSystem
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(5);

            if(progressBar1.Value == 100)
            {
                timer1.Stop();
                this.Close();
                Login form = new Login();
                form.Show();
            }
        }
    }
}
