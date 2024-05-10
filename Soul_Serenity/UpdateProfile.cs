using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soul_Serenity
{
    public partial class UpdateProfile : Form
    {
        public DashboardUser DashboardUserInstance { get; set; }

        private SqlCommand cmd;
        private SqlDataAdapter da;
        private SqlDataReader dr;
        private DataSet ds;
        private DataTable dt;
        private string imgLocation;

        HashPass Hp = new HashPass();

        Koneksi koneksi = new Koneksi();
        private byte[] selectedImageBytes;
        public UpdateProfile()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPilihGambar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;

                // Baca file gambar ke dalam byte array
                selectedImageBytes = File.ReadAllBytes(imagePath);

                // Tampilkan gambar di pictureBox1
                pictureBoxProfileUpdate.Image = Image.FromFile(imagePath);
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = koneksi.GetConn();
                conn.Open();

                // Perbarui hanya profil pengguna yang sedang diupdate
                cmd = new SqlCommand("UPDATE tbl_user SET email=@email, password=@password, gambar=@gambar WHERE username=@username", conn);
                cmd.Parameters.AddWithValue("@username", textBoxUsername.Text);
                cmd.Parameters.AddWithValue("@email", textBoxEmail.Text);
                cmd.Parameters.AddWithValue("@password", Hp.PassHash(textBoxPassword.Text));
                cmd.Parameters.AddWithValue("@gambar", selectedImageBytes);
                cmd.ExecuteNonQuery();

                if (DashboardUserInstance != null)
                {
                    // Perbarui tampilan profil di dashboard jika ada instance dashboard yang tersedia
                    DashboardUserInstance.labelUsernameCard.Text = textBoxUsername.Text;
                    DashboardUserInstance.labelUsernameCard2.Text = textBoxUsername.Text;
                    DashboardUserInstance.labelEmail.Text = textBoxEmail.Text;
                    DashboardUserInstance.labelPassword.Text = textBoxPassword.Text;
                    DashboardUserInstance.pictureBoxProfileCard.Image = pictureBoxProfileUpdate.Image;
                    DashboardUserInstance.labelUsername.Text = textBoxUsername.Text;
                    DashboardUserInstance.pictureBoxProfile.Image = pictureBoxProfileUpdate.Image;
                }

                MessageBox.Show("Success");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
