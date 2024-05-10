using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Soul_Serenity
{
    public partial class Register : Form
    {
        private byte[] selectedImageBytes;

        Koneksi koneksi = new Koneksi();
        HashPass Hp = new HashPass();
        public Register()
        {
            InitializeComponent();
        }

        private void labelLogin_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Close();
        }

        private void btnCariGambar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;

                // Baca file gambar ke dalam byte array
                selectedImageBytes = File.ReadAllBytes(imagePath);

                // Tampilkan gambar di pictureBox1
                pictureProfile.Image = Image.FromFile(imagePath);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxUsername.Text) || string.IsNullOrEmpty(textBoxPassword.Text) || string.IsNullOrEmpty(textBoxEmail.Text) || string.IsNullOrEmpty(textBoxKonfirmasi.Text))
            {
                MessageBox.Show("Peringatan", "Harap isi semua kolom!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (textBoxPassword.Text == textBoxKonfirmasi.Text)
                {
                    using (SqlConnection conn = koneksi.GetConn())
                    {
                        conn.Open();

                        // Periksa apakah username sudah digunakan
                        SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tbl_user WHERE username = @username", conn);
                        cmd.Parameters.AddWithValue("@username", textBoxUsername.Text);
                        int count = (int)cmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Peringatan", "Username Sudah Digunakan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            // Insert data user ke dalam database
                            cmd = new SqlCommand("INSERT INTO tbl_user (username, email, password, gambar, role) VALUES (@username, @email, @password, @gambar, @role)", conn);
                            cmd.Parameters.AddWithValue("@username", textBoxUsername.Text);
                            cmd.Parameters.AddWithValue("@email", textBoxEmail.Text);
                            cmd.Parameters.AddWithValue("@password", Hp.PassHash(textBoxPassword.Text));
                            cmd.Parameters.AddWithValue("@gambar", selectedImageBytes); // Gunakan byte array gambar yang dipilih
                            cmd.Parameters.AddWithValue("@role", textBoxRole.Text);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Berhasil", "Akun Berhasil Terbuat!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Login lg = new Login();
                            lg.Show();
                            this.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Gagal", "Konfirmasi Password Anda Salah", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
