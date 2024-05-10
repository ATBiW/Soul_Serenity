using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soul_Serenity
{
    public partial class SplashScreen1 : Form
    {
        public SplashScreen1()
        {
            InitializeComponent();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void splashScreen_4_Paint(object sender, PaintEventArgs e)
        {
        }

        private void splashScreen_2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void splashScreen_1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void label8_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
        }

        private void label10_Click(object sender, EventArgs e)
        {
        }

        private void label11_Click(object sender, EventArgs e)
        {
        }

        private void splashScreen_3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label9_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label13_Click(object sender, EventArgs e)
        {
        }

        private void label14_Click(object sender, EventArgs e)
        {
        }

        private void label15_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
        }

        private void label16_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {
        }

        private void splashScreen_4_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            splashScreen_1.Visible = false;
            splashScreen_2.Visible = true;
            splashScreen_3.Visible = false;
            splashScreen_4.Visible = false;

        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            splashScreen_1.Visible = false;
            splashScreen_2.Visible = false;
            splashScreen_3.Visible = true;
            splashScreen_4.Visible = false;
        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            splashScreen_1.Visible = false;
            splashScreen_2.Visible = false;
            splashScreen_3.Visible = false;
            splashScreen_4.Visible = true;
        }

        private void btnToLogin_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Close();
        }
    }
}
